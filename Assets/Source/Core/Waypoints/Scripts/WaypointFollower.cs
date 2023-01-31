using UnityEngine;

namespace ElasticRush.Core
{
    public class WaypointFollower : MonoBehaviour
    {
        private const float DistanceToChangeWaypoint = 0.01f;

        [SerializeField] private Waypoint _startWaypoint;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationLerpDuration = 0.5f;

        private Waypoint _currentWaypoint;
        private Quaternion _targetRotation;
        private Quaternion _startRotation;
        private float _elapsedTime;
        private bool _isRotating;

        public Waypoint CurrentWaypoint => _currentWaypoint;

        private void Start()
        {
            _currentWaypoint = _startWaypoint;
            TryStartRotation();
        }

        private void Update()
        {
            if (_currentWaypoint == null)
                return;

            Move();

            if (Vector3.Distance(transform.position, _currentWaypoint.transform.position) < DistanceToChangeWaypoint)
            {
                SetNextWaypoint();
                TryStartRotation();
            }

            if (_isRotating)
                Rotate();
        }

        public void StopMoving()
        {
            _currentWaypoint = null;
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
                _isRotating = false;
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