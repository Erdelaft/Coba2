using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public GameObject modeAmbilSampah, modeTanamPohon, modeBangunSaluranAir, avatarBtn, progressAmbilSampah, panelAvatar, saveLoadDialog, backBtn, player, hujan, efekJatuhHujan, pesanIsu, pesanCaution, pesanDanger, pesanSelamat, interaksiMobil, mobil;
    public Transform sungai;
    public Text skorTeks;
    public int hari;
    public int[] rangeWaktuHujan;
    KontrolPlayer kontrolPlayer;
    TimeManager hariBerlalu;
    TanamPohon tanamPohon;
    ParticleSystem tetesanHujan;
    AmbilSampah ambilSampah;
    int tempInterval, kondisiCuaca, maxNilaiSampah, maxNilaiTanamPohon, maxNilaiPerbaikiSaluranAir, skorTotal, mobilMuncul;
    float kurangiketinggianSungai, ketinggianSungai, intensitasHujan;

    public float titikTerendahSungai = -10f, titikTertinggiSungai = -3f;

    // Use this for initialization
    void Start()
    {
        kontrolPlayer = player.GetComponent<KontrolPlayer>();
        tanamPohon = GetComponent<TanamPohon>();
        hujan = GetComponent<GameObject>();
        hariBerlalu = GetComponent<TimeManager>();
        sungai = GetComponent<Transform>();
        tetesanHujan = hujan.GetComponent<ParticleSystem>();
        intensitasHujan = tetesanHujan.emission.burstCount;
        ketinggianSungai = sungai.transform.position.y;

        Debug.Log(intensitasHujan);
    }

    // Update is called once per frame
    void Update()
    {
        mobilMuncul = UnityEngine.Random.Range(23000, 64000);

        if(hariBerlalu.time == mobilMuncul)
        {
            mobil = GameObject.FindGameObjectWithTag("Mobil");

            mobil.SetActive(true);
        }

        if (rangeWaktuHujan[0] > rangeWaktuHujan[1])
        {
            tempInterval = rangeWaktuHujan[1];
            rangeWaktuHujan[1] = rangeWaktuHujan[0];
            rangeWaktuHujan[0] = tempInterval;
        }

        tempInterval = UnityEngine.Random.Range(rangeWaktuHujan[0], rangeWaktuHujan[1]);

        if (hariBerlalu.days == hari)
        {
            if (Convert.ToInt32(hariBerlalu.time) == tempInterval)
            {
                hujan.SetActive(true);
                efekJatuhHujan.SetActive(true);
            }
        }
        if (tanamPohon.pohonFase1.activeInHierarchy)
        {
            kurangiketinggianSungai = tanamPohon.kurangiTinggiSungaiFase1;
        }
        if (tanamPohon.pohonFase2.activeInHierarchy)
        {
            kurangiketinggianSungai = tanamPohon.kurangiTinggiSungaiFase2;
        }
        if (tanamPohon.pohonFase3.activeInHierarchy)
        {
            kurangiketinggianSungai = tanamPohon.kurangiTinggiSungaiFase3;
        }

        ketinggianSungai += intensitasHujan + Convert.ToInt32(ambilSampah.tempSkor[0]) / 30 * Time.deltaTime;
        ketinggianSungai -= kurangiketinggianSungai * Time.deltaTime;

        string[] tempSkor = skorTeks.text.Split("/"[0]);
        maxNilaiSampah = 15 * (Convert.ToInt32(tempSkor[0]) / Convert.ToInt32(tempSkor[1]));
        maxNilaiTanamPohon = 45 * (GameObject.FindGameObjectsWithTag("Pohon").Length);
        maxNilaiPerbaikiSaluranAir = 35;

        skorTotal = maxNilaiPerbaikiSaluranAir + maxNilaiSampah + maxNilaiTanamPohon;

        if (skorTotal > 90)
        {
            pesanSelamat.SetActive(true);
            kontrolPlayer.enabled = false;
        }
        else if (skorTotal > 75)
        {
            pesanIsu.SetActive(true);
        }
        else if (skorTotal > 60)
        {
            pesanCaution.SetActive(true);
        }
        else
        {
            pesanDanger.SetActive(true);
        }
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

    // Interaksi mobil
    public void InteraksiMobil()
    {

    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    // Memperlihatkan tingkat kepedulian dan Options
    public void AvatarBtn()
    {
        panelAvatar.SetActive(true);
        kontrolPlayer.enabled = false;
    }

    public void Backbtn()
    {
        if (backBtn.activeInHierarchy)
        {
            kontrolPlayer.enabled = true;
            panelAvatar.SetActive(false);
        }
    }

    public void SaveLoadDialog(bool aktif)
    {
        saveLoadDialog.SetActive(!aktif);
    }

    public void SaveBtn()
    {
        
    }

    public void LoadBtn()
    {

    }
}
