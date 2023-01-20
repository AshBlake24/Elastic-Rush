using System;
using UnityEngine;

namespace ElasticRush.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField, Min(1)] private int _startLevel;

        private readonly ElasticBall _elsaticBall = new();

        private int _score;

        public int Score => _score;
        public int Level => _elsaticBall.Level;

        private void OnValidate()
        {
            _elsaticBall.SetLevel(_startLevel);

            OnSizeChanged(_elsaticBall.Size);
        }

        private void Awake()
        {
            _elsaticBall.SetLevel(_startLevel);

            OnSizeChanged(_elsaticBall.Size);
        }

        private void OnEnable()
        {
            _elsaticBall.SizeChanged += OnSizeChanged;
        }

        private void OnDisable()
        {
            _elsaticBall.SizeChanged -= OnSizeChanged;
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

            _elsaticBall.SetLevel(newLevel);
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