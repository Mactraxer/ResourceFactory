using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTrigger : MonoBehaviour
{
    [SerializeField] private List<GameObject> _inventory;
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
            
            yield return waitForSeconds;
        }
    }



}
