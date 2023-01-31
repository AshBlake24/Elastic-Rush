using ElasticRush.Core;
using UnityEngine;

namespace ElasticRush.Collectables
{
    [RequireComponent(typeof(Collider))]
    public abstract class CollectableItem : MonoBehaviour
    {
        private void OnValidate()
        {
            Collider collider = GetComponent<Collider>();

            if (!collider.isTrigger)
                collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            Player player = other.GetComponentInParent<Player>();

            if (player == null)
                return;

            OnCollected(player);
        }

        protected abstract void OnCollected(Player player);
    }
}