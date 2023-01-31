using UnityEngine;

namespace ElasticRush.Core
{
    public class WaypointFollower : MonoBehaviour
    {
        [SerializeField] private Waypoint _startWaypoint;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationTime;

        private Waypoint _currentWaypoint;
        private Vector3 _direction;

        public Waypoint CurrentWaypoint => _currentWaypoint;

        private void Start()
        {
            _currentWaypoint = _startWaypoint;
        }

        private void Update()
        {
            if (_currentWaypoint != null)
            {
                _direction = (_currentWaypoint.transform.position - transform.position).normalized;

                Move();
                Rotate();
            }
        }

        public void SetNextWaypoint()
        {
            if (_currentWaypoint.NextWaypoint != null)
                _currentWaypoint = _currentWaypoint.NextWaypoint;
            else
                _currentWaypoint = null;
        }

        public void StopMoving()
        {
            _currentWaypoint = null;
        }

        private void Move()
        {
            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
        }

        private void Rotate()
        {
            Quaternion lookRotation = Quaternion.LookRotation(_direction);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                lookRotation,
                _rotationTime * Time.deltaTime);
        }
    }
}