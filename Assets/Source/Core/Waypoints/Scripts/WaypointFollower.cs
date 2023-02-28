using ElasticRush.Utilities;
using System;
using System.Collections;
using UnityEngine;

namespace ElasticRush.Core
{
    public class WaypointFollower : MonoBehaviour
    {
        private const float DistanceToChangeWaypoint = 0.1f;

        [SerializeField] private Waypoint _startWaypoint;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationLerpDuration = 0.5f;

        private Waypoint _currentWaypoint;
        private Quaternion _targetRotation;
        private Quaternion _startRotation;
        private float _elapsedTime;
        private bool _isRotating;
        private bool _isPaused;

        public event Action MoveStoped;
        public event Action<bool> PauseChanged;

        public Waypoint CurrentWaypoint => _currentWaypoint;

        private void Start()
        {
            _isPaused = true;
            _currentWaypoint = _startWaypoint;
            TryStartRotation();
        }

        private void Update()
        {
            if (_currentWaypoint == null || _isPaused)
                return;

            if (Vector3.Distance(transform.position, _currentWaypoint.transform.position) < DistanceToChangeWaypoint)
            {
                SetNextWaypoint();
                TryStartRotation();
            }

            Move();


        }

        private void LateUpdate()
        {
            if (_isRotating)
                Rotate();
        }

        public IEnumerator StopMovingSlowly()
        {
            float duration = Config.Player.TimeToStopRolling;
            float maxSpeed = _speed;
            float elapsedTime = 0;

            while (elapsedTime < duration)
            {
                _speed = Mathf.Lerp(maxSpeed, 0, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            OnMoveStopped();
        }

        public void SetPause(bool isPaused)
        {
            if (isPaused)
                _isPaused = true;
            else
                _isPaused = false;

            PauseChanged?.Invoke(_isPaused);
        }

        public void StopMoving() => OnMoveStopped();

        private void OnMoveStopped()
        {
            _currentWaypoint = null;
            MoveStoped?.Invoke();
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                _currentWaypoint.transform.position,
                _speed * Time.deltaTime);
        }

        private void Rotate()
        {
            transform.rotation = Quaternion.Slerp(_startRotation, _targetRotation, _elapsedTime / _rotationLerpDuration);
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _rotationLerpDuration)
            {
                _elapsedTime = 0;
                _isRotating = false;
            }
        }

        private void SetNextWaypoint()
        {
            if (_currentWaypoint.NextWaypoint != null)
                _currentWaypoint = _currentWaypoint.NextWaypoint;
            else
                _currentWaypoint = null;
        }

        private void TryStartRotation()
        {
            if (_currentWaypoint == null)
                return;

            Vector3 direction = (_currentWaypoint.transform.position - transform.position).normalized;

            _elapsedTime = 0;
            _isRotating = true;
            _startRotation = transform.rotation;
            _targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }
}