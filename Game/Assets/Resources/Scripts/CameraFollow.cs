using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTarget;
    public float cameraSpeed;
    public Vector3 batas;

    Vector3 playerPos, smoothPos;


    void Start()
    {
      //batas = playerView;
    }

    void Update()
    {
        playerPos = playerTarget.position + batas;
        smoothPos = Vector3.Lerp(transform.position, playerPos, cameraSpeed);
        transform.position = smoothPos;

        transform.LookAt(playerTarget);
    }
    
}
