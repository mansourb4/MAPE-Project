using UnityEngine;

namespace Scenes
{
    public class Followcam : MonoBehaviour
    {
        public Transform playerHero;

        private void FixedUpdate()
        {
            var position = playerHero.position;
            transform.position = new Vector3(position.x, position.y, transform.position.z);
        }
    }
}
