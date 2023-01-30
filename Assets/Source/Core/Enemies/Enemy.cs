using UnityEngine;

namespace ElasticRush
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected TriggerObserver TriggerObserver;

        protected virtual void OnEnable()
        {
            TriggerObserver.TriggerEntered += OnTriggerEntered;
        }

        protected virtual void OnDisable()
        {
            TriggerObserver.TriggerEntered -= OnTriggerEntered;
        }

        protected abstract void OnTriggerEntered(Collider collider);
    }
}