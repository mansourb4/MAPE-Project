using UnityEngine;

public class Followcam : MonoBehaviour
{
    public Transform playerTransform;
    
    private void FixedUpdate()
    {
        playerTransform = InstantiatePlayer.instance.playerTransform;
        var position = playerTransform.position;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}