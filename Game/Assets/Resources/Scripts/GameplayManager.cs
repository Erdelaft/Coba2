using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
	public Button modeAmbilSampah, modeTanamPohon, modeBangunSaluranAir, avatarBtn;
    public RectTransform objekRange;
    public Image areaImage;
    GameObject objekSampah = null;
    Vector3 areaSampah;
    float areaSampahX;
    float areaSampahZ;


    // Use this for initialization
    void Start ()
	{

        areaSampahX = objekRange.rect.max.x;
        areaSampahZ = objekRange.rect.max.y;

        areaSampah = new Vector3();
        objekSampah = Instantiate(Resources.Load("Enviro/Bahan/Sampah"), new Vector3(Random.Range(4, areaSampahX), 2, Random.Range(4, areaSampahZ)), Quaternion.identity) as GameObject;
    }
	
	// Update is called once per frame
	void Update ()
	{
        Debug.Log("x = " + Random.Range(4f, areaSampahX) + "/nz = " + Random.Range(4f, areaSampahZ));
    }

	// Mode Menanam Pohon
	public void ModeTanamPohon()
	{

	}

	// Mode Mengambil Sampah
	public void ModeAmbilSampah()
	{

	}

	// Mode Membangun Saluran Air
	public void ModeBangunSaluranAir()
	{

	}

	// Memperlihatkan tingkat kepedulian dan Options
	public void AvatarBtn()
	{

	}
}
