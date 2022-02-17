using System.Collections;
using System;
using UnityEngine;

public class InventoryStack : MonoBehaviour
{
    [SerializeField] private BoxCollider _inventoryCollider;
    [SerializeField] private GameObject _inventroryGameObject;
    [SerializeField] private BoxCollider _WorkWithItem;//For test
    private Inventory _inventory;

    private Vector3 _currentElementPosition;



    private void Start()
    {
        _inventory = new Inventory(20);
        _currentElementPosition = new Vector3(-_inventoryCollider.size.x / 2 + _WorkWithItem.size.x / 2,-_inventoryCollider.size.y / 2 + _WorkWithItem.size.y / 2, -_inventoryCollider.size.z / 2 + _WorkWithItem.size.z / 2);

        //For tests
        for (int i = 0; i < _inventroryGameObject.transform.childCount; i++)
        {
            _inventory.LoadItem();
        }
    }


    public GameObject GetItem()
    {
        _inventory.UploadItem();
        if (_inventroryGameObject.transform.childCount < 1) return null;
        var firstItem = _inventroryGameObject.transform.GetChild(0);
        return firstItem.gameObject;
    }
    
    public Vector3 PutItem(GameObject item)
    {
        var itemPosition = Vector3.zero;

        if (_inventory.CurrentCapacity == 0)
        {
            itemPosition = _currentElementPosition;
        }
        else
        {
            CalculatePosition(item);
            itemPosition = _currentElementPosition;
        }

        _inventory.LoadItem();
        item.transform.parent = _inventroryGameObject.transform;
        return itemPosition;
    }

    public void CalculatePosition(GameObject item)
    {
        if (_currentElementPosition.x + item.transform.localScale.x < _inventoryCollider.size.x)
        {
            _currentElementPosition = _currentElementPosition + new Vector3(item.transform.lossyScale.x, 0, 0);
        }
        else if (_currentElementPosition.z + item.transform.localScale.z < _inventoryCollider.size.z)
        {
            _currentElementPosition = new Vector3(0, _currentElementPosition.y, _currentElementPosition.z + item.transform.localScale.z);
        }
        else
        {
            _currentElementPosition = new Vector3(0, _currentElementPosition.y + item.transform.localScale.y, 0);
        }

    }
}
