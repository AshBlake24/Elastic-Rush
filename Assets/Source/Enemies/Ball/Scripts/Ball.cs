using UnityEngine;

namespace ElasticRush.Core
{
    public class Ball : Enemy
    {
        [SerializeField, Min(1)] private int _startLevel = 1;

        private readonly ElasticBall _elsaticBall = new();

        public int Level => _elsaticBall.Level;

        private void OnValidate()
        {
            _elsaticBall.SetLevel(_startLevel);

            ChangeSize(_elsaticBall.Size);
        }

        private void Awake()
        {
            _elsaticBall.SetLevel(_startLevel);

            ChangeSize(_elsaticBall.Size);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                if (player.Level >= Level)
                {
                    player.LevelUp(Level);
                    Destroy(gameObject);
                }
                else
                {
                    player.Die();
                }
            }
        }

        private void ChangeSize(float size)
        {
            transform.localScale = Vector3.one * size;

            transform.position = new Vector3(
                        transform.position.x,
                        transform.localScale.y / 2,
                        transform.position.z);
        }
    }
}