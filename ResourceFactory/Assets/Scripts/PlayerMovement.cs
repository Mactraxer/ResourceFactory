using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;


    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveTo(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveTo(Vector3.right);
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveTo(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveTo(Vector3.back);
        }

    }

    private void MoveTo(Vector3 direction)
    {
        _player.transform.position += direction * Time.deltaTime * _speed;
    }
}
