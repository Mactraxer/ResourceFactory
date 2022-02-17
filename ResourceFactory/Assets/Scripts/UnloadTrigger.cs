using System.Collections;
using UnityEngine;

public class UnloadTrigger : MonoBehaviour
{

    [SerializeField] private InventoryStack _inventoryComponent;

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
            InventoryController.instanse.TransferItem(_inventoryComponent, receiver, StopLoad);
            yield return waitForSeconds;
        }
    }

    private void StopLoad()
    {
        StopAllCoroutines();
    }

}
