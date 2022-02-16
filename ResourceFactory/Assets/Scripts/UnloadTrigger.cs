using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class UnloadTrigger : MonoBehaviour
{

    [SerializeField] private List<GameObject> _itemsInStack;

    private void OnTriggerEnter(Collider other)
    {
        var inventoryStackComponent = other.gameObject.GetComponent<InventoryStack>();
        if (inventoryStackComponent == null) return;

        StartCoroutine(CoroutineUnloadItems(inventoryStackComponent));
    }

    private void OnTriggerExit(Collider other)
    {
        var inventoryStackComponent = other.gameObject.GetComponent<InventoryStack>();
        if (inventoryStackComponent == null) return;

        
        StopAllCoroutines();
    }

    private IEnumerator CoroutineUnloadItems(InventoryStack receiver)
    {
        var waitForSeconds = new WaitForSeconds(.2f);

        while (true)
        {
            if (_itemsInStack.Count < 1)
            {
                StopAllCoroutines();
                break;
            }

            var itemForLoad = _itemsInStack[0];
            //receiver.StartLoad(itemForLoad);
            _itemsInStack.Remove(itemForLoad);

            yield return waitForSeconds;
        }
    }

}
