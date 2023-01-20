using System;
using UnityEngine;

namespace ElasticRush.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField, Min(1)] private int _startLevel;

        private readonly Ball _ball = new();

        private int _score;

        public int Score => _score;
        public int Level => _ball.Level;

        private void OnValidate()
        {
            _ball.SetLevel(_startLevel);

            OnSizeChanged(_ball.Size);
        }

        private void Awake()
        {
            _ball.SetLevel(_startLevel);

            OnSizeChanged(_ball.Size);
        }

        private void OnEnable()
        {
            _ball.SizeChanged += OnSizeChanged;
        }

        private void OnDisable()
        {
            _ball.SizeChanged -= OnSizeChanged;
        }

        public void AddScore(int score)
        {
            _score += score;
        }

        public void LevelUp(int level = 1)
        {
            if (level < 1)
                throw new ArgumentOutOfRangeException(nameof(level), "level cannot be less than 1");

            int newLevel = Level + level;

            _ball.SetLevel(newLevel);
        }

        private void OnSizeChanged(float size)
        {
            transform.localScale = Vector3.one * size;

            transform.position = new Vector3(
                        transform.position.x,
                        transform.localScale.y / 2,
                        transform.position.z);
        }
    }
}