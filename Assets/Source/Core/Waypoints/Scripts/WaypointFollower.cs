using System;
using System.Collections;
using UnityEngine;

namespace ElasticRush.Core
{
    public class WaypointFollower : MonoBehaviour
    {
        [SerializeField] private Waypoint _startWaypoint;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationTime;
        [SerializeField] private float _lerpDuration = 0.5f;

        private Waypoint _currentWaypoint;
        private Coroutine _rotation;
        private Vector3 _direction;

        public Waypoint CurrentWaypoint => _currentWaypoint;

        private void Start()
        {
            _currentWaypoint = _startWaypoint; 
            UpdatePath();
        }

        private void LateUpdate()
        {
            if (_currentWaypoint != null)
                Move();
        }

        public void StopMoving()
        {
            _currentWaypoint = null;
        }

        public void UpdatePath()
        {
            SetNextWaypoint();

            if (_currentWaypoint != null)
            {
                SetDirection();
                StartRotation();
            }
        }

        private void SetNextWaypoint()
        {
            if (_currentWaypoint.NextWaypoint != null)
                _currentWaypoint = _currentWaypoint.NextWaypoint;
            else
                _currentWaypoint = null;
        }

        private void SetDirection()
        {
            _direction = (_currentWaypoint.transform.position - transform.position).normalized;
        }

        private void StartRotation()
        {
            if (_rotation != null)
                StopCoroutine(_rotation);

            _rotation = StartCoroutine(Rotate());
        }

        private void Move()
        {
            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
        }

        private IEnumerator Rotate()
        {
            float elapsedTime = 0;
            Quaternion startRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(_direction, Vector3.up);

            while (elapsedTime < _lerpDuration)
            {
                transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / _lerpDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.rotation = targetRotation;
        }
    }
}