using UnityEngine;

public class FollowerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _follower;
    private Vector3 _offsetFollowing;

    private void Start()
    {
        _offsetFollowing = _follower.transform.position - _target.transform.position;    
    }

    private void Update()
    {
        
        _follower.transform.position = _offsetFollowing + _target.transform.position;
    }
}
