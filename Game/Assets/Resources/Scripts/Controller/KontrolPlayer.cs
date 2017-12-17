using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KontrolPlayer : MonoBehaviour
{
    public KeyCode maju, mundur, kanan, kiri;
    public float kecepatanKontrol = 10f;
    public AmbilSampah ambilSampah;
    public Animator playerAnim;
    float inputV, inputH;

    Transform playerPos;
    int skor = 0;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetKey(maju))
        {
			transform.Translate(new Vector3(0f, 0f, kecepatanKontrol * Time.deltaTime));
            playerAnim.SetTrigger("walk_run");
        }
        else if (Input.GetKey(mundur))
        {
            playerAnim.SetTrigger("walk_run");
            transform.Translate(new Vector3(0f, 0f, -kecepatanKontrol * Time.deltaTime));
        }
        if (Input.GetKey(kanan))
        {
            transform.Rotate(new Vector3(0f, kecepatanKontrol / 2f, 0f));
        }
        if (Input.GetKey(kiri))
        {
            transform.Rotate(new Vector3(0f, -kecepatanKontrol / 2f, 0f));
        }
        playerAnim.Play("Idle", -1);
        /*
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        playerAnim.SetFloat("inputH", inputH);
        playerAnim.SetFloat("inputV", inputV);*/
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
