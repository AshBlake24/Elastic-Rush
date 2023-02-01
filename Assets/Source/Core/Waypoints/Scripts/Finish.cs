using UnityEngine;

namespace ElasticRush.Core
{
    public class Finish : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger");

            Player player = other.GetComponentInParent<Player>();

            if (player != null)
            {
                player.Finish();
                Debug.Log("Finish");
            }
        }
    }
}