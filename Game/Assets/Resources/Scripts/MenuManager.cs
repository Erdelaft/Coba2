using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public GameObject panelMenu, panelQuitConfirmation, panelSetting,
                      panelOption, panelAbout, panelLoading, background;
    public Slider volumeBGM, volumeSFX;
    public AudioSource bgMusic, soundFx;

    void Start()
    {
        PlayerPrefs.SetFloat("VolumeSFX", soundFx.volume);
        PlayerPrefs.Save();
        soundFx.volume = PlayerPrefs.GetFloat("VolumeSFX");
    }

    void OnEnable()
    {
        volumeSFX.onValueChanged.AddListener(delegate { ChangeVolumeSfx(); });
    }

    void Update()
    {
        bgMusic.volume = volumeBGM.value;
    }

    void ChangeVolumeSfx()
    {
        soundFx.volume = volumeSFX.value;
    }

    public void ChangeScene(string name)
	{
        soundFx.Play();
		SceneManager.LoadScene(name);
	}

    public void PanelAbout(bool aktif)
    {
        soundFx.Play();
        panelAbout.SetActive(!aktif);
        panelOption.SetActive(aktif);
    }

    public void PanelMenu(bool aktif)
    {
        soundFx.Play();
        panelMenu.SetActive(!aktif);
        panelMenu.SetActive(aktif);
    }

    public void PanelSetting(bool aktif)
    {
        soundFx.Play();
        panelSetting.SetActive(!aktif);
        panelOption.SetActive(aktif);
    }

    public void PanelOption(bool aktif)
    {
        soundFx.Play();
        panelOption.SetActive(!aktif);
        panelMenu.SetActive(aktif);
    }

    public void BackButton()
    {
        soundFx.Play();
        if (panelOption.activeInHierarchy == true)
        {
            panelOption.SetActive(false);
            panelMenu.SetActive(true);
        }
        if(panelSetting.activeInHierarchy == true)
        {
            panelOption.SetActive(true);
            panelSetting.SetActive(false);
        }
        if(panelQuitConfirmation.activeInHierarchy == true)
        {
            panelQuitConfirmation.SetActive(false);
        }
        if(panelAbout.activeInHierarchy == true)
        {
            panelAbout.SetActive(false);
            panelOption.SetActive(true);
        }
    }

	public void PanelQuit(bool aktif)
	{
        soundFx.Play();
        panelQuitConfirmation.SetActive(!aktif);
	}

    public void Loading(bool aktif)
    {
        soundFx.Play();
        panelLoading.SetActive(!aktif);
        panelMenu.SetActive(aktif);
        background.SetActive(aktif);
    }

	public void Quit()
	{
        soundFx.Play();
        PlayerPrefs.SetFloat("VolumeSFX", soundFx.volume);
        PlayerPrefs.Save();
        Application.Quit();
	}
}
