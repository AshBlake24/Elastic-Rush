using UnityEngine;

namespace ElasticRush.Core
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private Vector3 _positionOffset;
        private float _lastTargetRotationAlongY;

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
            float delta = _target.rotation.y - _lastTargetRotationAlongY;
            _lastTargetRotationAlongY = _target.rotation.y;

            transform.RotateAround(_target.position, Vector3.up, delta);

            UpdatePositionOffset();
        }
    }
}