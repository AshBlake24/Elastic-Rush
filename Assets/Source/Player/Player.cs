using System;
using TMPro;
using UnityEngine;

namespace ElasticRush.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField, Min(1)] private int _startLevel = 1;
        [SerializeField] private TMP_Text _levelFrame;

        private readonly ElasticBall _elsaticBall = new();

        private int _score;

        public event Action Died;
        public event Action LevelChanged;
        public event Action ScoreChanged;

        public int Score => _score;
        public int Level => _elsaticBall.Level;

        private void OnValidate()
        {
            _elsaticBall.SetLevel(_startLevel);
            _levelFrame.text = $"Lvl {Level}";

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
            _elsaticBall.LevelChanged += OnLevelChanged;
        }

        private void Start()
        {
            LevelChanged?.Invoke();
        }

        private void OnDisable()
        {
            _elsaticBall.SizeChanged -= OnSizeChanged;
            _elsaticBall.LevelChanged -= OnLevelChanged;
        }

        public void Die()
        {
            Died?.Invoke();
            Destroy(gameObject);
        }

        public void AddScore(int score)
        {
            _score += score;

            ScoreChanged?.Invoke();
        }

        public void LevelUp(int levels = 1)
        {
            if (levels < 1)
                throw new ArgumentOutOfRangeException(nameof(levels), "levels cannot be less than 1");

            int newLevel = Level + levels;

            _elsaticBall.SetLevel(newLevel);
        }

        private void OnSizeChanged(float size)
        {
            transform.localScale = Vector3.one * size;

            transform.localPosition = new Vector3(
                        transform.localPosition.x,
                        transform.localScale.y / 2,
                        transform.localPosition.z);
        }

        private void OnLevelChanged(int obj)
        {
            LevelChanged?.Invoke();

            _levelFrame.text = $"Lvl {Level}";
        }
    }
}