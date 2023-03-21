using System;
using UnityEngine;
using ElasticRush.UI;
using Lean.Localization;
using TMPro;

namespace ElasticRush.Core
{
    public class ElasticBall : MonoBehaviour, IReadonlyElasticBall
    {
        private const int MinLevel = 1;
        private const float MinSize = 1f;
        private const float MaxSize = 3f;
        private const string BallLevelPhrase = "Ball Level";

        [SerializeField, Min(MinLevel)] private int _level = MinLevel;
        [SerializeField] private TMP_Text _levelFrame;

        private float _size;

        public event Action LevelChanged;
        public event Action<float> SizeChanged;

        public int Level => _level;
        public TMP_Text LevelFrame => _levelFrame;

        private void OnValidate()
        {
            SetLevel(_level);
            ChangeSize();
        }

        private void OnEnable()
        {
            ChangeLanguageButton.LanguageChanged += OnLanguageChanged;
        }

        private void OnDisable()
        {
            ChangeLanguageButton.LanguageChanged -= OnLanguageChanged;
        }

        private void Start()
        {
            LevelChanged?.Invoke();
            TrySetText();
        }

        public void LevelUp(int levels = 1)
        {
            if (levels < MinLevel)
                throw new ArgumentOutOfRangeException(nameof(levels), $"levels cannot be less than {MinLevel}");

            int newLevel = _level + levels;

            SetLevel(newLevel);
            ChangeSize();
        }

        public bool TryReduceLevel(int levels)
        {
            if (levels < MinLevel)
                throw new ArgumentOutOfRangeException(nameof(levels), $"levels cannot be less than {MinLevel}");

            int newLevel = _level - levels;

            if (newLevel >= MinLevel)
            {
                SetLevel(newLevel);
                ChangeSize();

                return true;
            }
            else
            {
                return false;
            }
        }

        public void ResetLevel()
        {
            SetLevel(MinLevel);
            ChangeSize();
        }

        private void SetLevel(int level)
        {
            _level = level;

            TrySetText();

            LevelChanged?.Invoke();
        }

        private void TrySetText()
        {
            if (_levelFrame != null)
            {
                string translation = LeanLocalization.GetTranslationText(BallLevelPhrase);
                _levelFrame.text = $"{translation} {_level}";
            }
        }

        private void ChangeSize()
        {
            _size = Mathf.Lerp(MinSize, MaxSize, Mathf.Log10(_level) / Mathf.PI);

            transform.localScale = Vector3.one * _size;

            SizeChanged?.Invoke(_size);
        }

        private void OnLanguageChanged() => TrySetText();
    }
}