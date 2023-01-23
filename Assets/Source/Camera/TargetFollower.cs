using UnityEngine;

namespace ElasticRush.Core
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private Vector3 _lastTargetRotation;
        private Vector3 _positionOffset;

        private void Start()
        {
            UpdatePositionOffset();
        }

        private void LateUpdate()
        {
            Move();
            RotateAroundTarget();
        }

        private void Move()
        {
            transform.position = _target.position + _positionOffset;
        }

        private void UpdatePositionOffset()
        {
            _positionOffset = transform.position - _target.position;
        }

        private void RotateAroundTarget()
        {
            float delta = _target.rotation.eulerAngles.y - _lastTargetRotation.y;
            _lastTargetRotation = _target.rotation.eulerAngles;

            transform.RotateAround(_target.position, Vector3.up, delta);

            UpdatePositionOffset();
        }
    }
}