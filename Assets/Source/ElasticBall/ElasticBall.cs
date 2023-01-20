using System;
using UnityEngine;

namespace ElasticRush.Core
{
    public class ElasticBall
    {
        private const int MinLevel = 1;
        private const float MinSize = 1f;
        private const float MaxSize = 3.5f;

        private int _level;
        private float _size;

        public event Action<int> LevelChanged;
        public event Action<float> SizeChanged;

        public int Level => _level;
        public float Size => _size;

        public void SetLevel(int level)
        {
            if (level < MinLevel)
                throw new ArgumentOutOfRangeException(nameof(level), "level cannot be less than 1");

            _level = level;

            LevelChanged?.Invoke(_level);

            ChangeSize();
        }

        private void ChangeSize()
        {
            _size = Mathf.Lerp(MinSize, MaxSize, Mathf.Log10(_level) / Mathf.PI) + 1;

            SizeChanged?.Invoke(_size);
        }
    }
}