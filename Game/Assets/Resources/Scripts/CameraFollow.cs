using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTarget;
    public float cameraSpeed = 7.5f;
    public Vector3 batas;
    int countTouched = 0;
    Vector3 playerPos, smoothPos;
    
    void Start()
    {

    }

    void Update()
    {
        
    }

    /*
    Vector3 KameraRotasi(int n)
    {
        // kameraRotasi = transform.RotateAround(playerPos, transform.rotation.eulerAngles, 5f);

        return kameraRotasi;
    }
    */

	// Update is called once per frame
	void LateUpdate ()
    {
        playerPos = playerTarget.position + batas;
        smoothPos = Vector3.Lerp(transform.position, playerPos, cameraSpeed * Time.deltaTime);
        transform.position = smoothPos;
        
        transform.LookAt(playerTarget);
	}
}
