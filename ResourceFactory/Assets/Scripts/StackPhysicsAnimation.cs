using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackPhysicsAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 _stackEnd;
    [SerializeField] private GameObject _target;


    [ContextMenu("Stack")]
    public void Stack()
    {
        StartCoroutine(CoroutineMoveToPosition(_target, _stackEnd));
    }

    public void Setup(Vector3 stackDistanse, GameObject target)
    {
        _stackEnd = stackDistanse;
        _target = target;
    }

    private IEnumerator CoroutineMoveToPosition(GameObject target, Vector3 toTransform)
    {
        var waitFixedUpdate = new WaitForFixedUpdate();
        print($"Distance vector = {toTransform}  for {target.name}");
        while (target.transform.localPosition != toTransform)
        {
            target.transform.localPosition = Vector3.MoveTowards(target.transform.localPosition, toTransform, .2f);
            yield return waitFixedUpdate;
        }
        print($"Moved vector = {target.transform.position}  for {target.name}");
    }

}
