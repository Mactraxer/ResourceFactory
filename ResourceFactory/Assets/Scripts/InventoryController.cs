using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public static InventoryController instanse;
    public delegate void Completion();

    public void TransferItem(InventoryStack from, InventoryStack to, Completion action)
    {
        var item = from.GetItem();
        if (item == null)
        {
            action();
            return;
        }
        
        var position = to.PutItem(item);
        StackAnimationController.instanse.Animate(item, position);
    }

    private void Start()
    {
        instanse = this;
    }
}
