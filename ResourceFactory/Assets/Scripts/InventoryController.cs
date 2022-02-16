using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public void TransferItem(InventoryStack from, InventoryStack to)
    {
        var item = from.GetItem();
        to.PutItem(item);
        var position = to.GetPosition(item);
        StackAnimationController.instanse.Animate(item, position);
    }


}
