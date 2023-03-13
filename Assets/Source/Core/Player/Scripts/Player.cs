using ElasticRush.Effects;
using ElasticRush.Utilities;
using System;
using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(ElasticBall))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PathFollower _pathFollower;
        [SerializeField] private ElasticBall _elasticBall;

        [Header("VFX")]
        [SerializeField] private Transform _effectPoint;
        [SerializeField] private Effect _deathEffect;

        private int _score;
        private bool _isFinished;
        private bool _isActive;

        public event Action LevelCompleted;
        public event Action EnemyAbsorbed;
        public event Action ScoreChanged;
        public event Action DamageReceived;
        public event Action Destroying;
        public event Action Died;

        public static ObjectPool<ParticleSystem> EffectPool { get; private set; }
        public IReadonlyElasticBall ElasticBall => _elasticBall;
        public int Score => _score;
        public bool IsActive => _isActive;

        private void Start()
        {
            if (EffectPool == null)
                EffectPool = new ObjectPool<ParticleSystem>(_deathEffect.gameObject);

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
            Destroying?.Invoke();

            if (_isFinished)
            {
                StartCoroutine(_pathFollower.StopMovingSlowly());
                UpdatePlayerEntryBestScore();
                LevelCompleted?.Invoke();
            }
            else
            {
                _pathFollower.StopMoving();
                Died?.Invoke();
                EmitEffect();
            }
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

        private void EmitEffect()
        {
            ParticleSystem vfx = EffectPool.GetInstance();
            vfx.gameObject.SetActive(true);
            vfx.transform.SetLocalPositionAndRotation(_effectPoint.position, Quaternion.identity);
        }
    }
}