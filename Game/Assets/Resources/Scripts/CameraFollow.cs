using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTarget;
    public float cameraSpeed = 7.5f;
    public Vector3 offset;
    Vector3 kameraPos;

	// Update is called once per frame
	void LateUpdate ()
    {
        Vector3 playerPos = playerTarget.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, playerPos, cameraSpeed * Time.deltaTime);
        transform.position = smoothPos;

        transform.LookAt(playerTarget);
	}
}
