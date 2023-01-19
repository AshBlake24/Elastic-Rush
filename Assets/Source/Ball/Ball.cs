using System;
using UnityEngine;

namespace ElasticRush.Core
{
    public class Ball
    {
        private const int MinLevel = 1;
        private const float MinSize = 1f;
        private const float MaxSize = 3.5f;

        private int _level;
        private float _size;

        public Ball() : this(MinLevel) { }

        public Ball(int level)
        {
            _level = level;
        }

        public event Action<float> SizeChanged;

        public int Level => _level;
        public float Size => _size;

        public void SetLevel(int level)
        {
            if (level < MinLevel)
                throw new ArgumentOutOfRangeException(nameof(level), "level cannot be less than 1");

            _level = level;

            ChangeSize();
        }

        private void ChangeSize()
        {
            _size = Mathf.Lerp(MinSize, MaxSize, Mathf.Log10(_level) / Mathf.PI);

            SizeChanged?.Invoke(_size);
        }
    }
}