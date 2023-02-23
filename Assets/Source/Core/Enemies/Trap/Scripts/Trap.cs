using UnityEngine;

namespace ElasticRush.Core
{
    public class Trap : Enemy
    {
        [SerializeField] private Waypoint _startWaypoint;
        [SerializeField] private float _speed;
        [SerializeField, Range(1, 100)] private int _playerDamagePercentage;

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

            if (player != null && player.IsActive)
            {
                int damage = player.ElasticBall.Level * _playerDamagePercentage / 100;
                damage = Mathf.Clamp(damage, 1, int.MaxValue);
                player.TakeDamage(damage);
            }
        }
    }
}