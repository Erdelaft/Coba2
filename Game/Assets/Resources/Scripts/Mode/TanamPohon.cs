using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanamPohon : MonoBehaviour
{
    public GameObject pohonFase1, pohonFase2, pohonFase3, hujan;
    public TimeManager jumlahHari;
    public float kurangiTinggiSungaiFase1, kurangiTinggiSungaiFase2, kurangiTinggiSungaiFase3;

	// Use this for initialization
	void Start ()
    {
        hujan = GetComponent<GameObject>();
        jumlahHari = GetComponent<TimeManager>();
	}

    void OnTriggerEnter(Collider pohon)
    {
        if(pohonFase1.activeInHierarchy == false)
        {
            pohonFase1.SetActive(true);
        }
        if(pohonFase2.activeInHierarchy == false)
        {
            pohonFase1.SetActive(false);
            pohonFase2.SetActive(true);
        }
        if(pohonFase3.activeInHierarchy == false)
        {
            pohonFase2.SetActive(false);
            pohonFase3.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
