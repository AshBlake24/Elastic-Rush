using ElasticRush.Audio;
using UnityEngine;

namespace ElasticRush.Core
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected TriggerObserver TriggerObserver;
        [SerializeField] protected AudioPlayer AudioPlayer;

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