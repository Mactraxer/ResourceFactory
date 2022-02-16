using System.Collections;
using System;
using UnityEngine;

public class InventoryStack : MonoBehaviour
{
    [SerializeField] private BoxCollider _inventoryCollider;
    [SerializeField] private GameObject _inventroryGameObject;
    private Inventory _inventory;

    private Vector3 _currentElementPosition;



    private void Start()
    {
        _inventory = new Inventory(20);
        _currentElementPosition = Vector3.zero;
    }

    public GameObject GetItem()
    {
        _inventory.UploadItem();
        if (_inventroryGameObject.transform.childCount < 1) return null;
        var firstItem = _inventroryGameObject.transform.GetChild(0);
        return firstItem.gameObject;
    }
    
    public void PutItem(GameObject item)
    {
        _inventory.LoadItem();
        item.transform.parent = _inventroryGameObject.transform;
    }

    public Vector3 GetPosition(GameObject item)
    {
        Vector3 newPosition = Vector3.zero;

        if (_currentElementPosition.x < _inventoryCollider.size.x)
        {
            newPosition = _currentElementPosition + new Vector3(item.transform.lossyScale.x, 0, 0);
        }
        else if (_currentElementPosition.z < _inventoryCollider.size.z)
        {
            newPosition = new Vector3(0, _currentElementPosition.y, _currentElementPosition.z + item.transform.lossyScale.z);
        }
        else
        {
            newPosition = new Vector3(0, _currentElementPosition.y + item.transform.lossyScale.y, 0);
        }

        _currentElementPosition = newPosition;
        return _currentElementPosition;
    }
}
