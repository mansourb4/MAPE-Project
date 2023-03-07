using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lader : MonoBehaviour
{
    public bool isInrange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Gentaro"))
        {
                isInrange = true;
        }
    } 
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Gentaro"))
        {
                isInrange = true;
        }
    } 
}
