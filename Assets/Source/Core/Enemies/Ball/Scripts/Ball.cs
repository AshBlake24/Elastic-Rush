using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(ElasticBall))]
    public class Ball : Enemy
    {
        [SerializeField] private Player _player;
        [SerializeField] private ElasticBall _elasticBall;

        protected override void OnEnable()
        {
            base.OnEnable();
            _player.ElasticBall.LevelChanged += OnPlayerLevelChanged;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _player.ElasticBall.LevelChanged -= OnPlayerLevelChanged;
        }

        protected override void OnTriggerEntered(Collider collider)
        {
            if (collider.GetComponentInParent<Player>() == null)
                return;

            if (_player.ElasticBall.Level >= _elasticBall.Level)
            {
                AudioPlayer.PlayClip();
                _player.AbsorbEnemy(_elasticBall.Level);
                Destroy(gameObject);
            }
            else
            {
                _player.Destroy();
            }
        }

        private void OnPlayerLevelChanged()
        {
            if (_player.ElasticBall.Level >= _elasticBall.Level)
                _elasticBall.LevelFrame.color = Color.green;
            else
                _elasticBall.LevelFrame.color = Color.red;
        }
    }
}