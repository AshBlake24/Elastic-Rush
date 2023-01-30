using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(BoxCollider))]
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