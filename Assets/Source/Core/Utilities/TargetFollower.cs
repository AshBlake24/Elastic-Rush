using UnityEngine;

namespace ElasticRush
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private Vector3 _offset;

        private void Start()
        {
            _offset = transform.position - _target.position;
        }

        private void Update()
        {
            transform.position = _target.position + _offset;
        }
    }
}