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
        private bool _isFinished;

        public event Action LevelCompleted;
        public event Action ScoreChanged;
        public event Action Died;

        public IReadonlyElasticBall ElasticBall => _elasticBall;
        public int Score => _score;

        private void Start()
        {
            _isFinished = false;
            ScoreChanged?.Invoke();
        }

        public void Finish() => _isFinished = true;

        public void LevelUp(int level) => _elasticBall.LevelUp(level);

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
                Destroy();
            }
        }

        public void Destroy()
        {
            if (_isFinished)
                LevelCompleted?.Invoke();
            else
                Died?.Invoke();

            _originWaypointFollower.StopMoving();
            Destroy(gameObject);
        }

        public void AddScore(int score)
        {
            _score += score;

            ScoreChanged?.Invoke();
        }
    }
}