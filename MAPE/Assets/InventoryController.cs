using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
    
public class InventoryController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inventory;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isController = false;
        if (Gamepad.all.Count > 0)
        {
            isController = true;
        }
        if (Input.GetKeyDown(KeyCode.E) || (isController && Gamepad.all[0].selectButton.wasPressedThisFrame))
        {
            if (isController)
            {
                inventory.SetActive(!inventory.activeSelf);
            }
            else
            {
                inventory.SetActive(true);
            }
            
        }
    }
}
