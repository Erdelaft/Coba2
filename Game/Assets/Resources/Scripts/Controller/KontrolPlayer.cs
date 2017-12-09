using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            playerAnim.Play("walk_run", -1, 0f);
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

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        playerAnim.SetFloat("inputH", inputH);
        playerAnim.SetFloat("inputV", inputV);
    }

    void OnTriggerEnter(Collider ambil)
    {
        if (ambil.gameObject.tag == "Sampah")
        {
            Destroy(ambil.gameObject);

            skor++;

            ambilSampah.tempSkor[0] = skor.ToString();
            Debug.Log("Skor : " + ambilSampah.tempSkor[0]);
        }
    }
}
