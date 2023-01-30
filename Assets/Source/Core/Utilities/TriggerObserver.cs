using System;
using UnityEngine;

namespace ElasticRush
{
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> TriggerEntered;

        private void OnTriggerEnter(Collider other)
        {
            TriggerEntered?.Invoke(other);
        }
    }
}