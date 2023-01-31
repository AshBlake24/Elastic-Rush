using UnityEngine;

namespace ElasticRush.Core
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] private Waypoint _nextWaypoint;

        public Waypoint NextWaypoint => _nextWaypoint;
    }
}