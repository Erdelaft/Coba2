using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTarget;
    public GameObject mapViewMode, playerViewMode;
    public float cameraSpeed;
     Vector3 mapView;
     Vector3 playerView;
    
    public Vector3 batas;
    
    void Start()
    {
      //batas = playerView;
    }

    void Update()
    {
        Vector3 playerPos = playerTarget.position + batas;
        Vector3 smoothPos = Vector3.Lerp(transform.position, playerPos, cameraSpeed);
        transform.position = smoothPos;

        transform.LookAt(playerTarget);
    }

    public void PlayerView(bool aktif)
    {
        playerViewMode.SetActive(!aktif);
        mapViewMode.SetActive(aktif);
        batas = playerView;
    }

    public void MapView(bool aktif)
    {
        mapViewMode.SetActive(!aktif);
        playerViewMode.SetActive(aktif);
        batas = mapView;
    }

    /*
	// Update is called once per frame
	void LateUpdate ()
    {
        playerPos = playerTarget.position + batas;
        smoothPos = Vector3.Lerp(transform.position, playerPos, cameraSpeed * Time.deltaTime);
        transform.position = smoothPos;
        
        transform.LookAt(playerTarget);
	}*/
}
