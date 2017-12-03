using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public VirtualController joystick;
    public float playerSpeed = 4f;
    Transform playerPos;
    
	// Update is called once per frame
	void Update ()
    {
        playerPos = GetComponent<Transform>();

        transform.position = playerPos.position;

        if(joystick.InputDirection != Vector3.zero)
        {
            transform.position += joystick.InputDirection * playerSpeed;
        }
	}
}
