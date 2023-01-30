using System;
using TMPro;
using UnityEngine;

namespace ElasticRush.Core
{
    public class ElasticBall : MonoBehaviour, IReadonlyElasticBall
    {
        private const float MinSize = 1f;
        private const float MaxSize = 3f;

        [SerializeField, Min(1)] private int _level = 1;
        [SerializeField] private TMP_Text _levelFrame;

        private float _size;

        public event Action LevelChanged;

        public int Level => _level;
        public TMP_Text LevelFrame => _levelFrame;

        private void OnValidate()
        {
            SetLevel(_level);
            ChangeSize();
        }

        private void Start()
        {
            LevelChanged?.Invoke();
        }

        public void LevelUp(int levels = 1)
        {
            if (levels < 1)
                throw new ArgumentOutOfRangeException(nameof(levels), "levels cannot be less than 1");

            int newLevel = _level + levels;

            SetLevel(newLevel);
            ChangeSize();
        }

        private void SetLevel(int level)
        {
            _level = level;

            if (_levelFrame != null)
                _levelFrame.text = $"Lvl {_level}";

            LevelChanged?.Invoke();
        }

        private void ChangeSize()
        {
            _size = Mathf.Lerp(MinSize, MaxSize, Mathf.Log10(_level) / Mathf.PI);

            transform.localScale = Vector3.one * _size;
        }
    }
}