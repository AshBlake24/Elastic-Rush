using System;
using UnityEngine;

namespace ElasticRush.Core
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private bool _lockXAxis;
        [SerializeField] private bool _lockYAxis;
        [SerializeField] private bool _lockZAxis;

        private Vector3 _targetPosition;

        private Action _updateTargetPosition;

        private void Start()
        {
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
            _updateTargetPosition.Invoke();
            transform.position = _targetPosition + _offset;
        }

        private void AddXAxis()
        {
            _targetPosition = new Vector3(
                _targetTransform.position.x,
                _targetPosition.y,
                _targetPosition.z);
        }

        private void AddYAxis()
        {
            _targetPosition = new Vector3(
                _targetPosition.x,
                _targetTransform.position.y,
                _targetPosition.z);
        }

        private void AddZAxis()
        {
            _targetPosition = new Vector3(
                _targetPosition.x,
                _targetPosition.y,
                _targetTransform.position.z);
        }

        private void ResetTargetPosition()
        {
            _targetPosition = Vector3.zero;
        }
    }
}