using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class InventoryItemController: MonoBehaviour
{
    public Item item;
    public InstantiatePlayer instancePlayer;

    private void Start()
    {
        instancePlayer = InstantiatePlayer.Instance;
    }

    public void RemoveItem()
    {
        Debug.Log($"{item.itemName} supprimé");
        InventoryManager.instance.Remove(item);
        Destroy(gameObject);
    }

    public void AddItem(Item itemToAdd)
    {
        item = itemToAdd;
    }

    public void UseItem()
    {
        switch (item.itemName)
        {
            case "Attack Boost Potion":
                instancePlayer.nbAttackPotion += 1;
                Debug.Log("Attack Boost Potion");
                break;
            case "Health Potion":
                ToHeal(30);
                break;
            case "Full_heal_Potion":
                ToHeal(120);
                break;
            case "Armor":
                instancePlayer.armor = true;
                ToHeal(120);// the armor is also the Full heal potion, otherwise the user could think he loses health when he wears the armor
                Debug.Log("Armor utilisée");
                break;
            case "Boots":
                instancePlayer.boots = true;
                Debug.Log("Bottes utilisée");
                break;
        }
    }

    public void ToHeal(int PV)
    {
        instancePlayer.toHeal = PV;
    }
}
