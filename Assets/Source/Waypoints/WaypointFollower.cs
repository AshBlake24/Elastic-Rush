using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class WaypointFollower : MonoBehaviour
    {
        [SerializeField] private Waypoint _startWaypoint;
        [SerializeField] private float _waypointChangeDistance;

        private Waypoint _currentWaypoint;
        private Waypoint _lastWaypoint;

        public Waypoint CurrentWaypoint => _currentWaypoint;
        public Vector3 Direction { get; private set; }

        private void Start()
        {
            _currentWaypoint = _startWaypoint;

            Direction = _currentWaypoint.transform.position - transform.position;
        }

        public void SetNextWaypoint()
        {
            if (_currentWaypoint.NextWaypoint != null)
            {
                _lastWaypoint = _currentWaypoint;
                _currentWaypoint = _currentWaypoint.NextWaypoint;

                Direction = _currentWaypoint.transform.position - _lastWaypoint.transform.position;
            }
            else
            {
                _currentWaypoint = null;
            }
        }
    }
}