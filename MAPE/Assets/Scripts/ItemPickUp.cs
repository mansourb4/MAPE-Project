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
        InventoryManager.instance.Add(item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        PickUp();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
