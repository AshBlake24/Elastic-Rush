using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(Collider))]
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] private Waypoint _nextWaypoint;

        public Waypoint NextWaypoint => _nextWaypoint;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger");
            if (other.TryGetComponent(out WaypointFollower follower))
                follower.SetNextWaypoint();
        }
    }
}