using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
	// Public Variables
	public RectTransform panelLevelMenu, objekPusat;	// Variabel untuk objek Panel Level Menu dan objek Pusat
	public Button[] btnLevelSelect;						// Variabel Button untuk Level Menu 

	// Private Variables
	private float[] distances;			// Jarak setiap Button (Level) dengan objek pusat
	private bool dragging = false;      // Akan menjadi True, jika menggeser (dragging) panel Level Menu
	private int btnDistance;            // Menyimpan jarak setiap Button dengan objek pusat
	private int minBtnDistance;			// Akan menyimpan nilai terkecil dari jarak setiap Button

	// Use this for initialization
	void Start ()
	{
		int btnLenght = btnLevelSelect.Length;
		distances = new float[btnLenght];

		// Mendapatkan jarak dari tiap Button
		btnDistance = (int)Mathf.Abs(btnLevelSelect[1].GetComponent<RectTransform>().anchoredPosition.x - btnLevelSelect[0].GetComponent<RectTransform>().anchoredPosition.x);
		print(btnDistance);
	}
	
	// Update is called once per frame
	void Update ()
	{
		float minDistance = Mathf.Min(distances);   // Mendapatkan nilai terkecil dari jarak setiap Button dengan objek pusat

		for(int i = 0; i < btnLevelSelect.Length; i++)
		{
			distances[i] = Mathf.Abs(objekPusat.transform.position.x - btnLevelSelect[i].transform.position.x);
		}

		for(int i = 0; i < btnLevelSelect.Length; i++)
		{
			if(minDistance == distances[i])
			{
				minBtnDistance = i;
			}
		}

		if(!dragging)			// ketika tidak menggeser (Dragging)
		{
			LerpToBtn(minBtnDistance * -btnDistance);
		}
	}

	void LerpToBtn(int posistion)		// Menggerakkan Button yg memiliki jarak terdekat dengan objek Pusat, menuju objek Pusat
	{
		float newX = Mathf.Lerp(panelLevelMenu.anchoredPosition.x, posistion, Time.deltaTime * 4f);
		Vector2 newPosistion = new Vector2(newX, panelLevelMenu.anchoredPosition.y);
		panelLevelMenu.anchoredPosition = newPosistion;
	}

	public void StartDrag()			// Ketika menggeser (Dragging)
	{
		dragging = true;
	}

	public void EndDrag()			// Ketika tidak menggeser (Dragging)
	{
		dragging = false;
	}
}
