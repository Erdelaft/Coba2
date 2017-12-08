using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolPlayer : MonoBehaviour
{
    public KeyCode maju, mundur, kanan, kiri;
    public float kecepatanKontrol = 10f;
    
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(maju))
        {
            transform.Translate(new Vector3(0f, 0f, kecepatanKontrol * Time.deltaTime));
        }

        if (Input.GetKey(mundur))
        {
            transform.Translate(new Vector3(0f, 0f, -kecepatanKontrol * Time.deltaTime));
        }

        if (Input.GetKey(kanan))
        {
            transform.Rotate(new Vector3(0f, -3f, 0f));
        }

        if (Input.GetKey(kiri))
        {
            transform.Rotate(new Vector3(0f, 3f, 0f));
        }
    }
}
