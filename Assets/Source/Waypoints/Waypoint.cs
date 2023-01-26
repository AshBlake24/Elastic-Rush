using UnityEngine;

namespace ElasticRush.Core
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] private Waypoint _nextWaypoint;

        public Waypoint NextWaypoint => _nextWaypoint;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out WaypointFollower follower))
                follower.SetNextWaypoint();
        }
    }
}