using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class VirtualController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
	private Image bgImage, joystickImage;					// bgImage untuk area controller, joystickImage untuk controller
	public GameObject playerViewMode, mapsViewMode;	

	public Vector3 InputDirection { set; get; }

	private void Start()
	{
		bgImage = GetComponent<Image>();
		joystickImage = transform.GetChild(0).GetComponent<Image>();
		InputDirection = Vector3.zero;
	}

	public void OnDrag(PointerEventData ped)		// Memberikan nilai untuk joystickImage ketika digerakkan
	{
		Vector2 pos = Vector2.zero;

		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform, ped.position, ped.pressEventCamera, out pos))
		{
			pos.x = (pos.x / bgImage.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImage.rectTransform.sizeDelta.y);

			float x = (bgImage.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
			float y = (bgImage.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

			InputDirection = new Vector3(x, 0, y);
			InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;
			joystickImage.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (bgImage.rectTransform.sizeDelta.x / 3), InputDirection.z * (bgImage.rectTransform.sizeDelta.y / 3));
		}
	}

	public void OnPointerDown(PointerEventData ped)		// Ketika joystickImage digerakkan
	{
		OnDrag(ped);
	}

	public void OnPointerUp(PointerEventData ped)       // Ketika joystickImage dilepaskan
	{
		InputDirection = Vector3.zero;
		joystickImage.rectTransform.anchoredPosition = Vector3.zero;    // mengembalikan posisi joystickImage ke pusat/anchor
	}

	public void ViewMode(bool aktifButton)				// Berganti Mode View Maps-Player
	{
		playerViewMode.SetActive(!aktifButton);
		mapsViewMode.SetActive(aktifButton);
	}
}
