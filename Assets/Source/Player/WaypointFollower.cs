namespace ElasticRush.Core
{
    public class WaypointFollower
    {
        public Waypoint CurrentWaypoint { get; private set; }

        public WaypointFollower(Waypoint startWaypoint)
        {
            CurrentWaypoint = startWaypoint;
        }

        public void SetNextWaypoint()
        {
            if (CurrentWaypoint.NextWaypoint != null)
                CurrentWaypoint = CurrentWaypoint.NextWaypoint;
            else
                CurrentWaypoint = null;
        }
    }
}