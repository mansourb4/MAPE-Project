using UnityEngine;

public class Followcam : MonoBehaviour
{
    public Transform playerTransform;
    
    private void Update()
    {
        playerTransform = InstantiatePlayer.Instance.playerTransform;
        var position = playerTransform.position;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}