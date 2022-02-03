using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackPhysicsAnimation : MonoBehaviour
{
    [SerializeField] private Transform _originStackStart;
    [SerializeField] private GameObject _target;
    [SerializeField] private int _stackCount;
    [SerializeField] private List<int> _dimentionSize;

    [SerializeField] private Vector3 _startPosition;
    private Vector3 _currentPosition;

    void Start()
    {
        _currentPosition = _startPosition;
    }

    [ContextMenu("Stack")]
    public void Stack()
    {
        StartCoroutine(CoroutineSpawnTarget());
    }

    private void CalculateNextPosition()
    {
        _currentPosition += new Vector3(_target.transform.localScale.x, 0, 0);
    }

    private IEnumerator CoroutineMoveToPosition(GameObject target, Vector3 toPosition)
    {
        var waitFixedUpdate = new WaitForFixedUpdate();
        while (target.transform.position != toPosition)
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, toPosition, .2f);
            yield return waitFixedUpdate;
        }
    }

    private IEnumerator CoroutineSpawnTarget()
    {
        for (int i = 0; i < _stackCount; i++)
        {
            var instantedTarget = Instantiate(_target, _originStackStart.position, Quaternion.identity);
            StartCoroutine(CoroutineMoveToPosition(instantedTarget, _currentPosition));
            yield return new WaitForSeconds(0.2f);
            CalculateNextPosition();
        }
    }
}
