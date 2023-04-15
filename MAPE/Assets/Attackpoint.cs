using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AttackPointleft : MonoBehaviour
{
    private Collider2D collider;

    private void OnEnable()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = true;
    }

    private void OnDisable()
    {
        collider.enabled = false;
    }
}


