using System;
using UnityEngine;

namespace ElasticRush.Core
{
    public abstract class ElasticBall : MonoBehaviour
    {
        private const int MinLevel = 1;
        private const float MinSize = 1f;
        private const float MaxSize = 3.5f;

        [SerializeField, Min(1)] protected int Level;

        private float _size;

        private void OnValidate()
        {
            SetLevel(Level);
        }

        private void Awake()
        {
            SetLevel(Level);
        }

        public void SetLevel(int level)
        {
            if (level < MinLevel)
                throw new ArgumentOutOfRangeException(nameof(level), "level cannot be less than 1");

            Level = level;

            ChangeSize();
        }

        private void ChangeSize()
        {
            _size = Mathf.Lerp(MinSize, MaxSize, Mathf.Log10(Level) / Mathf.PI);

            transform.localScale = Vector3.one * _size;

            transform.position = new Vector3(
                        transform.position.x,
                        transform.localScale.y / 2,
                        transform.position.z);
        }
    }
}