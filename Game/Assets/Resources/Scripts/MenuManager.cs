using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public GameObject PanelMenu, PanelQuitConfirmation;

	public void ChangeScene(string name)
	{
		SceneManager.LoadScene(name);
	}

	public void PanelQuit(bool active)
	{
		PanelQuitConfirmation.SetActive(active);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
