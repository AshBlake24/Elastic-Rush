using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace ElasticRush.Core
{
    public class WaypointFollower : MonoBehaviour
    {
        [SerializeField] private Waypoint _startWaypoint;
        [SerializeField] private float _waypointChangeDistance;

        private Waypoint _currentWaypoint;

        public Waypoint CurrentWaypoint => _currentWaypoint;


        private void Start()
        {
            _currentWaypoint = _startWaypoint;
        }

        private void Update()
        {
            if (_currentWaypoint == null)
                return;

            float distanceToWaypoint = Vector3.Distance(transform.position, _currentWaypoint.transform.position);

            if (distanceToWaypoint < _waypointChangeDistance)
                SetNextWaypoint();
        }

        private void SetNextWaypoint()
        {
            if (_currentWaypoint.NextWaypoint != null)
                _currentWaypoint = _currentWaypoint.NextWaypoint;
            else
                _currentWaypoint = null;
        }
    }
}