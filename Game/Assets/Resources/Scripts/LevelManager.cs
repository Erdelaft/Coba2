using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelBtn;
    
    void Start()
    {/*
        for (int i = 0; i < levelBtn.Length; i++)
        {
            levelBtn[i].interactable = true;
        }*/
    }

    public void LoadLevel(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
