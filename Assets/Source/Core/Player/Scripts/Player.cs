using Cinemachine;
using ElasticRush.Utilities;
using System;
using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(ElasticBall))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private WaypointFollower _originWaypointFollower;
        [SerializeField] private ElasticBall _elasticBall;

        private int _score;
        private bool _isFinished;
        private bool _isActive;

        public event Action LevelCompleted;
        public event Action EnemyAbsorbed;
        public event Action ScoreChanged;
        public event Action DamageReceived;
        public event Action Died;

        public IReadonlyElasticBall ElasticBall => _elasticBall;
        public int Score => _score;
        public bool IsActive => _isActive;

        private void Start()
        {
            _isActive = true;
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
            _isActive = false;
            

            if (_isFinished)
            {
                StopCamera();
                StartCoroutine(_originWaypointFollower.StopMovingSlowly());
                UpdatePlayerEntryBestScore();
                LevelCompleted?.Invoke();
            }
            else
            {
                _originWaypointFollower.StopMoving();
                Died?.Invoke();
            }
        }

        private void StopCamera()
        {
            Transform cameraStopPoint = new GameObject("Camera Stop Point").transform;
            cameraStopPoint.position = _originWaypointFollower.transform.position;
            _camera.Follow = cameraStopPoint;
        }

        public void AddScore(int score)
        {
            _score += score;

            ScoreChanged?.Invoke();
        }

        public void AddExtraScore()
        {
            UpdatePlayerEntryBestScore();
            _score += _score;
            ScoreChanged?.Invoke();
        }

        private void UpdatePlayerEntryBestScore()
        {
            int lastBestScore = SaveSystem.PlayerScore.Load();
            int newBestScore = lastBestScore + _score;
            SaveSystem.PlayerScore.Save(this, newBestScore);            
        }
    }
}