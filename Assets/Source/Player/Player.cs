using System;
using UnityEngine;

namespace ElasticRush.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField, Min(1)] private int _level;

        private Ball _ball = new Ball();

        private void OnValidate()
        {
            _ball.SetLevel(_level);

            OnSizeChanged(_ball.Size);
        }

        private void Awake()
        {
            _ball = new Ball(_level);

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

        public void LevelUp(int level = 1)
        {
            if (level < 1)
                throw new ArgumentOutOfRangeException(nameof(level), "level cannot be less than 1");

            _level += level;

            _ball.SetLevel(_level);
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