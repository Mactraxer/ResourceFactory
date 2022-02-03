using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{

    [SerializeField] private GameObject _handler;
    [SerializeField] private float _borderMoveRadius;
    private Vector3 _joystickNormalizedPosition;

    public delegate void JoystickMoved(Vector3 position);
    static public event JoystickMoved OnJoystickMoved;

    private void Awake()
    {
        _joystickNormalizedPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var canvasPlaneDistance = 100f;
        var eventVectorPosition = new Vector3(eventData.position.x, eventData.position.y, canvasPlaneDistance);

        var inputPosition = Camera.main.ScreenToWorldPoint(eventVectorPosition);
        var offset = inputPosition - gameObject.transform.position;

        var joystickPosition = gameObject.transform.position + Vector3.ClampMagnitude(offset, _borderMoveRadius);
        _handler.transform.position = joystickPosition;

        _joystickNormalizedPosition = (_handler.transform.position - gameObject.transform.position).normalized;  
    }



    public void OnEndDrag(PointerEventData eventData)
    {
        _handler.transform.localPosition = Vector3.zero;
        StopAllCoroutines();
    }

    private IEnumerator CoroutineSendPosition()
    {
        var waitForFixedUpdate = new WaitForFixedUpdate();

        while (true)
        {
            yield return waitForFixedUpdate;
            OnJoystickMoved(_joystickNormalizedPosition);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        StartCoroutine(CoroutineSendPosition());
    }

}
