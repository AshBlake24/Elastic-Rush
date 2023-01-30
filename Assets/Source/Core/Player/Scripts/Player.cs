using System;
using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(ElasticBall))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private ElasticBall _elasticBall;

        private int _score;

        public event Action ScoreChanged;
        public event Action Died;

        public IReadonlyElasticBall ElasticBall => _elasticBall;
        public int Score => _score;

        public void LevelUp(int level)
        {
            _elasticBall.LevelUp(level);
        }

        public void Die()
        {
            Debug.Log("Player Died");
            Died?.Invoke();
        }

        public void AddScore(int score)
        {
            _score += score;

            ScoreChanged?.Invoke();
        }
    }
}