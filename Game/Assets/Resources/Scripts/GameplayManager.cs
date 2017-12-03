using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
	public GameObject modeAmbilSampah, modeTanamPohon, modeBangunSaluranAir, avatarBtn, progressAmbilSampah;
    
    // Use this for initialization
    void Start ()
	{
        
        
    }
	
	// Update is called once per frame
	void Update ()
	{
        
    }

	// Mode Menanam Pohon
	public void ModeTanamPohon()
	{
        modeAmbilSampah.SetActive(false);
        modeBangunSaluranAir.SetActive(false);
        modeTanamPohon.SetActive(true);
        progressAmbilSampah.SetActive(false);

    }

	// Mode Mengambil Sampah
	public void ModeAmbilSampah()
	{
        modeAmbilSampah.SetActive(true);
        modeBangunSaluranAir.SetActive(false);
        modeTanamPohon.SetActive(false);
        progressAmbilSampah.SetActive(true);
    }

	// Mode Membangun Saluran Air
	public void ModeBangunSaluranAir()
	{
        modeAmbilSampah.SetActive(false);
        modeBangunSaluranAir.SetActive(true);
        modeTanamPohon.SetActive(false);
        progressAmbilSampah.SetActive(false);
    }

	// Memperlihatkan tingkat kepedulian dan Options
	public void AvatarBtn()
	{

	}
}
