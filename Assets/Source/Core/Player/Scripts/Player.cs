using ElasticRush.Utilities;
using System;
using System.Collections;
using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(ElasticBall))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private WaypointFollower _originWaypointFollower;
        [SerializeField] private ElasticBall _elasticBall;

        private int _score;
        private bool _isFinished;

        public event Action LevelCompleted;
        public event Action EnemyAbsorbed;
        public event Action ScoreChanged;
        public event Action DamageReceived;
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

        public void AbsorbEnemy(int enemyLevel)
        {
            LevelUp(enemyLevel);
            EnemyAbsorbed?.Invoke();
        }

        public void TakeDamage(int damage)
        {
            if (damage >= _elasticBall.Level)
            {
                Destroy();
            }
            else
            {
                _elasticBall.TryReduceLevel(damage);
                DamageReceived?.Invoke();
            }
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
                Destroy();
            }
        }

        public void Destroy()
        {
            _camera.gameObject.transform.SetParent(null, true);
            StartCoroutine(_originWaypointFollower.StopMoving());

            if (_isFinished)
            {
                UpdatePlayerEntryBestScore();
                LevelCompleted?.Invoke();
            }
            else
            {
                Died?.Invoke();
            }
        }

        public void AddScore(int score)
        {
            _score += score;

            ScoreChanged?.Invoke();
        }

        public void AddExtraScore() => UpdatePlayerEntryBestScore();

        private void UpdatePlayerEntryBestScore()
        {
            int lastBestScore = SaveSystem.PlayerScore.Load();
            int newBestScore = lastBestScore + _score;
            SaveSystem.PlayerScore.Save(this, newBestScore);
            ScoreChanged?.Invoke();
        }
    }
}