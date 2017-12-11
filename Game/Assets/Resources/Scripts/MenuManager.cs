using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public GameObject panelMenu, panelQuitConfirmation, panelSetting,
                      panelOption, panelAbout, panelLoading, background;
    

	public void ChangeScene(string name)
	{
		SceneManager.LoadScene(name);
	}

    public void PanelAbout(bool aktif)
    {
        panelAbout.SetActive(!aktif);
        panelOption.SetActive(aktif);
    }

    public void PanelMenu(bool aktif)
    {
        panelMenu.SetActive(!aktif);
        panelMenu.SetActive(aktif);
    }

    public void PanelSetting(bool aktif)
    {
        panelSetting.SetActive(!aktif);
        panelOption.SetActive(aktif);
    }

    public void PanelOption(bool aktif)
    {
        panelOption.SetActive(!aktif);
        panelMenu.SetActive(aktif);
    }

    public void BackButton()
    {
        if (panelOption.activeInHierarchy == true)
        {
            panelOption.SetActive(false);
            panelMenu.SetActive(true);
        }
        else if(panelSetting.activeInHierarchy == true)
        {
            panelOption.SetActive(true);
            panelSetting.SetActive(false);
        }
        else if(panelQuitConfirmation.activeInHierarchy == true)
        {
            panelQuitConfirmation.SetActive(false);
        }
    }

	public void PanelQuit(bool aktif)
	{
        panelQuitConfirmation.SetActive(!aktif);
	}

    public void Loading(bool aktif)
    {
        panelLoading.SetActive(!aktif);
        panelMenu.SetActive(aktif);
        background.SetActive(aktif);
    }

	public void Quit()
	{
		Application.Quit();
	}
}
