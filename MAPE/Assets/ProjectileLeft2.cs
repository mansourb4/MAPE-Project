using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLeft2 : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectilePrefab;
    public void FireProjectileLeft()
    {
        Instantiate(projectilePrefab, launchPoint.position, projectilePrefab.transform.rotation);
    }
}
