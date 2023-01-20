using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(Collider))]
    public class Enemy : MonoBehaviour
    {
        private void OnValidate()
        {
            Collider collider = GetComponent<Collider>();

            if (!collider.isTrigger)
                collider.isTrigger = true;
        }
    }
}