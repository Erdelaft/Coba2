using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KontrolPlayer : MonoBehaviour
{
    public float kecepatanKontrol = 5f;
    public AmbilSampah ambilSampah;
    public Animator playerAnim;

    Transform playerPos;
    int skor = 0;
    
    public float kecepatanPindah = 10f;
    public float kecepatanPutar = 40f;

    private CharacterController kontrol;

    void Start()
    {
        playerAnim = GetComponent<Animator>();

        kontrol = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update ()
    {
        Vector3 idlePos = new Vector3(0f, 0f, 0f);
        /*
        Move();
        if (kontrol.velocity.magnitude > 0)
        {
            anim.Play("walk_run");
        }
        else
        {
            anim.Play("Idle");
        }
        */
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.Translate(new Vector3(0f, 0f, kecepatanKontrol * Time.deltaTime));
            playerAnim.Play("walk_run");
            transform.Translate(Vector3.forward * kecepatanKontrol * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.Translate(new Vector3(0f, 0f, -kecepatanKontrol * Time.deltaTime));
            playerAnim.Play("walk_run");
            transform.Translate(Vector3.back * kecepatanKontrol * Time.deltaTime);
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
            playerAnim.Play("ambil_sampah");

            Destroy(ambil.gameObject);

            skor++;

            ambilSampah.tempSkor[0] = skor.ToString();
            Debug.Log("Skor : " + ambilSampah.tempSkor[0]);

            ambilSampah.jumlahSampahDiAmbil.text = ambilSampah.tempSkor[0] + " / " + ambilSampah.tempSkor[1];
        }
    }
    
	void Move ()
	{
		float gerakZ = Input.GetAxis ("Vertical") * kecepatanPindah * Time.deltaTime;
		float gerakX = Input.GetAxis ("Horinzontal") * kecepatanPutar * Time.deltaTime;

		Vector3 arah = new Vector3 (gerakX, 0f, gerakZ);

		kontrol.Move (arah);
	}
}