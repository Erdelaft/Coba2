using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTarget;
    public GameObject mapViewMode, playerViewMode, cameraPlayer, cameraMap;
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
        cameraPlayer.SetActive(true);
        cameraMap.SetActive(false);
    }

    public void MapView(bool aktif)
    {
        mapViewMode.SetActive(!aktif);
        playerViewMode.SetActive(aktif);
        cameraMap.SetActive(true);
        cameraPlayer.SetActive(false);
    }
    
}
