using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    
    void Start()
    {
        Joystick.OnJoystickMoved += ReceiveJoystickPosition;
    }

    
    void Update()
    {
        
    }

    private void ReceiveJoystickPosition(Vector3 position)
    {
        gameObject.transform.position = new Vector3(position.x + gameObject.transform.position.x, position.y + gameObject.transform.position.y, position.z); 
    }
}
