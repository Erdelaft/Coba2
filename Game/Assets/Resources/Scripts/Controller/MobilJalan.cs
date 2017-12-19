using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilJalan : MonoBehaviour
{
    public float mobilSpeed = 15;
    Transform mobil1, mobil2, mobil3, mobil4;
    float gerakAwal, ubahArah = 0;

	// Use this for initialization
	void Start ()
    {
		gameObject.SetActive (true);
		mobil1 = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        gerakAwal = mobilSpeed * Time.deltaTime;
        if (mobil1)
        {
            mobil1.transform.Translate(new Vector3(ubahArah, 0f, gerakAwal));
        }
        if (mobil2)
        {
            mobil2.transform.Translate(new Vector3(-gerakAwal, 0f, ubahArah));
        }
        if (mobil3)
        {
            mobil3.transform.Translate(new Vector3(ubahArah, 0f, -gerakAwal));
        }
        if (mobil4)
        {
            mobil4.transform.Translate(new Vector3(gerakAwal, 0f, ubahArah));
        }
    }
}
