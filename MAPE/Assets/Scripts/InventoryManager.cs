using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static InventoryManager instance;
    public List<Item> items = new List<Item>();
    public Transform itemContent;
    public GameObject inventoryItem;
    public Toggle enableRemove;
    public InventoryItemController[] inventoryItems;

    private void Awake()
    {
        instance = this;
    }

    public void Add(Item itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public void Remove(Item itemToRemove)
    {
        items.Remove(itemToRemove);
    }

    public void ListItems()
    {
        // Clean the content before opening the inventory
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (Item item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("Item Name").GetComponent<Text>();
            var itemIcon = obj.transform.Find("Item Icon").GetComponent<Image>();
            var removeButton = obj.transform.Find("Remove Item Button").GetComponent<Button>(); 

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            if (enableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
        }
        SetInventoryItems();
    }

    public void EnableItemsRemove()
    {
        if (enableRemove.isOn)
        {
            foreach (Transform item in itemContent)
            {
                item.Find("Remove Item Button").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in itemContent)
            {
                item.Find("Remove Item Button").gameObject.SetActive(false);
            } 
        }
    }

    public void SetInventoryItems()
    {
        inventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>();
        for (int i = 0; i < items.Count; i++)
        {
            inventoryItems[i].AddItem(items[i]);
        }
    }
}
