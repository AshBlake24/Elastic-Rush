using System;
using UnityEngine;

namespace ElasticRush.Core
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private bool _lockXAxis;
        [SerializeField] private bool _lockYAxis;
        [SerializeField] private bool _lockZAxis;

        private Vector3 _targetPosition;
        private Vector3 _positionOffset;

        private Action _updateTargetPosition;

        private void Start()
        {
            _positionOffset = transform.position - _target.position;

            _updateTargetPosition = ResetTargetPosition;

            if (_lockXAxis == false)
                _updateTargetPosition += AddXAxis;

            if (_lockYAxis == false)
                _updateTargetPosition += AddYAxis;

            if (_lockZAxis == false)
                _updateTargetPosition += AddZAxis;
        }

        private void LateUpdate()
        {
            Move();
        }

        private void Rotate()
        {
        }

        private void Move()
        {
            _updateTargetPosition.Invoke();
            transform.position = _targetPosition + _positionOffset;
        }

        private void AddXAxis()
        {
            _targetPosition = new Vector3(
                _target.position.x,
                _targetPosition.y,
                _targetPosition.z);
        }

        private void AddYAxis()
        {
            _targetPosition = new Vector3(
                _targetPosition.x,
                _target.position.y,
                _targetPosition.z);
        }

        private void AddZAxis()
        {
            _targetPosition = new Vector3(
                _targetPosition.x,
                _targetPosition.y,
                _target.position.z);
        }

        private void ResetTargetPosition()
        {
            _targetPosition = Vector3.zero;
        }
    }
}