using System.Collections;
using UnityEngine;

public class LoadTrigger : MonoBehaviour
{

    [SerializeField] private InventoryStack _inventoryComponent;    

    private void OnTriggerEnter(Collider other)
    {
        var inventoryStackComponent = other.gameObject.GetComponent<InventoryStack>();
        if (inventoryStackComponent == null) return;

        StartCoroutine(CoroutineLoadItems(inventoryStackComponent));
    }

    private void OnTriggerExit(Collider other)
    {
        var inventoryStackComponent = other.gameObject.GetComponent<InventoryStack>();
        if (inventoryStackComponent == null) return;

        
        StopAllCoroutines();
    }

    private IEnumerator CoroutineLoadItems(InventoryStack source)
    {
        var waitForSeconds = new WaitForSeconds(.2f);

        while (true)
        {
            InventoryController.instanse.TransferItem(source, _inventoryComponent, StopLoad);
            yield return waitForSeconds;
        }
    }

    private void StopLoad()
    {
        StopAllCoroutines();
    }

}
