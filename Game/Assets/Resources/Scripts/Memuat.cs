using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Memuat : MonoBehaviour
{
    public Image imageLoad;
    public float kecepatanMuat;

	// Use this for initialization
	void Start ()
    {
        imageLoad.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        imageLoad.fillAmount += kecepatanMuat * Time.deltaTime;

        if(imageLoad.fillAmount == 1)
        {
            SceneManager.LoadScene("LevelMenu");
        }
	}
}
