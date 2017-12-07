using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
	public GameObject modeAmbilSampah, modeTanamPohon, modeBangunSaluranAir, avatarBtn, progressAmbilSampah, rumah;
    public GameObject[] kumpulanRumah;
    public int jumlahRumah;

    // Use this for initialization
    void Start ()
	{
        float num = 5;
        int i = 0;
        foreach(GameObject inRumah in kumpulanRumah)
        {
            rumah = Instantiate(kumpulanRumah[i], new Vector3( num, 0f, 24f), Quaternion.Euler(-90f, 0f, 0f));
            rumah.AddComponent<Rigidbody>();
            rumah.AddComponent<Collider>();

            i++;
            num += 4;
        }
        
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
