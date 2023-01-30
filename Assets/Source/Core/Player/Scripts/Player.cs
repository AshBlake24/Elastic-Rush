using System;
using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(ElasticBall))]
    public class Player : MonoBehaviour
    {
        private ElasticBall _elasticBall;
        private int _score;

        public event Action Died;
        public event Action ScoreChanged;

        public int Score => _score;

        private void Awake()
        {
            _elasticBall = GetComponent<ElasticBall>();
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