using System;
using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(ElasticBall))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private WaypointFollower _originWaypointFollower;
        [SerializeField] private ElasticBall _elasticBall;

        private int _score;

        public event Action ScoreChanged;
        public event Action Died;

        public IReadonlyElasticBall ElasticBall => _elasticBall;
        public int Score => _score;

        private void Start()
        {
            ScoreChanged?.Invoke();
        }

        public void LevelUp(int level)
        {
            _elasticBall.LevelUp(level);
        }

        public void ExchageLevelsForScore(int levels, int score)
        {
            if (_elasticBall.TryReduceLevel(levels))
            {
                _score += score;
                ScoreChanged?.Invoke();
            }
            else
            {
                _score += score;
                ScoreChanged?.Invoke();
                Die();
            }
        }

        public void Die()
        {
            _originWaypointFollower.StopMoving();

            Debug.Log("Player Died");
            Died?.Invoke();
            Destroy(gameObject);
        }

        public void AddScore(int score)
        {
            _score += score;

            ScoreChanged?.Invoke();
        }
    }
}