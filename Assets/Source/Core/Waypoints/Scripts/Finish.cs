using UnityEngine;

namespace ElasticRush.Core
{
    public class Finish : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Player player = other.GetComponentInParent<Player>();

            if (player != null)
                player.Finish();
        }
    }
}