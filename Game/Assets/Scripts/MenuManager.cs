using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public GameObject panelMainMenu, panelOptions, panelQuit;

	// Use this for initialization
	void Start ()
	{
		panelMainMenu.SetActive(true);
		panelOptions.SetActive(false);
		panelQuit.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void ChangeScene(string name)
	{
		SceneManager.LoadScene(name);
	}

	public void MainMenuActive()
	{
		panelMainMenu.SetActive(true);
		panelOptions.SetActive(false);
		panelQuit.SetActive(false);
	}

	public void QuitActive()
	{
		panelQuit.SetActive(true);
	}
	
	public void OptionsActive()
	{
		panelMainMenu.SetActive(false);
		panelOptions.SetActive(true);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
