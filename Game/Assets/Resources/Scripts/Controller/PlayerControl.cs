using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public VirtualController joystick;
    public AmbilSampah ambilSampah;
    public float playerSpeed = 4f;
    public Animator playerAnim;

    Transform playerPos;
    int skor = 0;
    
	// Update is called once per frame
	void Update ()
    {
        playerPos = GetComponent<Transform>();
        ambilSampah = GetComponent<AmbilSampah>();

        transform.position = playerPos.position;

        if(joystick.InputDirection != Vector3.zero)
        {
            transform.position += joystick.InputDirection * playerSpeed;
            transform.Rotate(0f, 0f, 0f);
        }
        
	}

    void OnTriggerEnter(Collider ambil)
    {
        if (ambil.gameObject.tag == "Sampah")
        {
            Destroy(ambil.gameObject);

            skor++;

            ambilSampah.tempSkor[0] = skor.ToString();
            Debug.Log( "Skor : " + ambilSampah.tempSkor[0]);
        }
    }
}
