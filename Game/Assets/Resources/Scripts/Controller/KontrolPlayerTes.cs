using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KontrolPlayer : MonoBehaviour
{
    public float kecepatanKontrol = 10f;
    public AmbilSampah ambilSampah;
    public Animator playerAnim;

    Transform playerPos;
    int skor = 0;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.UpArrow))
        {
			transform.Translate(new Vector3(0f, 0f, kecepatanKontrol * Time.deltaTime));    
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0f, 0f, -kecepatanKontrol * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0f, kecepatanKontrol / 2f, 0f));
        }
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0f, -kecepatanKontrol / 2f, 0f));
        }
        playerAnim.Play("Idle", -1);


    }

    void OnTriggerEnter(Collider ambil)
    {
        if (ambil.gameObject.tag == "Sampah")
        {
            Destroy(ambil.gameObject);

            skor++;

            ambilSampah.tempSkor[0] = skor.ToString();
            Debug.Log("Skor : " + ambilSampah.tempSkor[0]);

            ambilSampah.jumlahSampahDiAmbil.text = ambilSampah.tempSkor[0] + " / " + ambilSampah.tempSkor[1];
        }
    }
}
