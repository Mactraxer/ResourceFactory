using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackPhysicsAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 _originStackStart;
    [SerializeField] private Vector3 _stackEnd;
    [SerializeField] private GameObject _target;
    private BoxCollider _targetBoxCollider;

    [SerializeField] private int _stackCount;


    private Vector3 _currentElementPosition;


    [ContextMenu("Stack")]
    public void Stack()
    {
        StartCoroutine(CoroutineMoveToPosition(_target, _stackEnd));
    }

    public void Setup(Vector3 originStackStart, Vector3 stackDistanse, GameObject target, int stackCount)
    {
        _originStackStart = originStackStart;
        _stackEnd = stackDistanse;
        _target = target;
        _stackCount = stackCount;

        _currentElementPosition = _stackEnd;
        _targetBoxCollider = target.GetComponent<BoxCollider>();
    }

    private void CalculateElementPosition(bool isFirst)
    {
        Vector3 newPosition = Vector3.zero;
        
        if (_currentElementPosition.x < _stackEnd.x)
        {
            newPosition = _currentElementPosition + new Vector3(_targetBoxCollider.size.x, 0, 0);
        }
        else if (_currentElementPosition.z < _stackEnd.z)
        {
            newPosition = new Vector3(_originStackStart.x, _currentElementPosition.y, _currentElementPosition.z + _targetBoxCollider.size.z);
        }
        else
        {
            newPosition = new Vector3(_originStackStart.x, _currentElementPosition.y + _targetBoxCollider.size.y, _originStackStart.z);
        }

        _currentElementPosition = newPosition;
        

    }

    private IEnumerator CoroutineMoveToPosition(GameObject target, Vector3 toTransform)
    {
        var waitFixedUpdate = new WaitForFixedUpdate();
        while (target.transform.position != toTransform)
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, toTransform, .2f);
            yield return waitFixedUpdate;
        }
    }

    private IEnumerator CoroutineSpawnTarget()
    {
        for (int i = 0; i < _stackCount; i++)
        {
            var instantedTarget = Instantiate(_target, _originStackStart, Quaternion.identity);
            CalculateElementPosition(i == 0);
            //StartCoroutine(CoroutineMoveToPosition(instantedTarget, _currentElementPosition));
            yield return new WaitForSeconds(0.2f);
            
        }
    }
}
