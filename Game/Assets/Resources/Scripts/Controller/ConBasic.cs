using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConBasic : MonoBehaviour {

	public float kecepatanPindah = 10f;
	public float kecepatanPutar = 40f;

	private CharacterController kontrol;

	// Use this for initialization
	void Start () {
		kontrol = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move ()
	{
		float gerakZ = Input.GetAxis ("Vertical") * kecepatanPindah * Time.deltaTime;
		float gerakX = Input.GetAxis ("Horinzontal") * kecepatanPutar * Time.deltaTime;

		Vector3 arah = new Vector3 (gerakX, 0f, gerakZ);

		kontrol.Move (arah);
	}
}
