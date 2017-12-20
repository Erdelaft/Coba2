using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilJalan : MonoBehaviour
{
    public float mobilSpeed = 15;
    Transform mobil1, mobil2, mobil3, mobil4;
    public float gerakAwal, ubahArah = 0;

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
            mobil1.transform.Translate(Vector3.forward * gerakAwal * Time.deltaTime);
        }
        if (mobil2)
        {
            mobil2.transform.Translate(Vector3.forward * gerakAwal * Time.deltaTime);
        }
        if (mobil3)
        {
            mobil3.transform.Translate(Vector3.forward * gerakAwal * Time.deltaTime);
        }
        if (mobil4)
        {
            mobil4.transform.Translate(Vector3.forward * gerakAwal * Time.deltaTime);
        }
    }
}
