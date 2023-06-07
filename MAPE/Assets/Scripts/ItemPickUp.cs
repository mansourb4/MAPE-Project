using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public Item item;

    void PickUp()
    {
        if (InventoryManager.instance.nbItem < InventoryManager.instance.capacity)
        {
            InventoryManager.instance.Add(item);
            Debug.Log($"{item.itemName} ramassé");
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        PickUp();
    }
}
