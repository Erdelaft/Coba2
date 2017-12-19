using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UbahArah : MonoBehaviour
{
    MobilJalan mobilJalan;

	// Use this for initialization
	void Start ()
    {
        mobilJalan = GetComponent<MobilJalan>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider mobil)
    {
        if(mobil.name == "Mobil1")
        {
            mobil.transform.Rotate(new Vector3(0f, -90, 0f));
            mobilJalan.ubahArah = -mobilJalan.gerakAwal;
            mobilJalan.gerakAwal = 0;
        }
        if(mobil.name == "Mobil2")
        {
            int num = Random.Range(0, 1);
            if (num == 0)
                mobil.transform.Rotate(new Vector3(0f, -90, 0f));
            else
                mobil.transform.Rotate(new Vector3(0f, 0f, 0f));
        }
        if(mobil.name == "Mobil3")
        {
            mobil.transform.Rotate(new Vector3(0f, -90, 0f));
        }
        if(mobil.name == "Mobil4")
        {
            int num = Random.Range(0, 1);
            if (num == 0)
                mobil.transform.Rotate(new Vector3(0f, -90, 0f));
            else
                mobil.transform.Rotate(new Vector3(0f, 0f, 0f));
        }
    }
}
