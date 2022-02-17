using UnityEngine;

public class StackAnimationController : MonoBehaviour
{
    public static StackAnimationController instanse;

    private StackPhysicsAnimation _animator;

    void Start()
    {
        instanse = this;
        _animator = GetComponent<StackPhysicsAnimation>();
    }
    
    public void Animate(GameObject item, Vector3 distanse)
    {
        _animator.Setup(distanse, item);
        _animator.Stack();
    }

}
