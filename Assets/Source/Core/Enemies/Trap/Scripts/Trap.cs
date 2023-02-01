using UnityEngine;

namespace ElasticRush.Core
{
    public class Trap : Enemy
    {
        [SerializeField] private Waypoint _startWaypoint;
        [SerializeField] private float _speed;

        private Waypoint _currentWaypoint;

        private void Start()
        {
            _currentWaypoint = _startWaypoint;
        }

        private void Update()
        {
            if (_currentWaypoint == null)
                return;

            if (Vector3.Distance(transform.position, _currentWaypoint.transform.position) < 0.01f)
                SetNextWaypoint();

            transform.position = Vector3.MoveTowards(
                transform.position,
                _currentWaypoint.transform.position,
                _speed * Time.deltaTime);
        }

        private void SetNextWaypoint()
        {
            _currentWaypoint = _currentWaypoint.NextWaypoint;
        }

        protected override void OnTriggerEntered(Collider collider)
        {
            Player player = collider.GetComponentInParent<Player>();

            if (player != null)
            {
                player.Destroy();
            }
        }
    }
}