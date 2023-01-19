using UnityEngine;

namespace ElasticRush.Core
{
    public class Ball : MonoBehaviour
    {
        private const float MinSize = 1f;
        private const float MaxSize = 10f;

        [SerializeField, Min(1)] private int _level;

        private float _size;

        public float Size => _size;

        private void OnValidate()
        {
            ChangeSize();

            transform.position = new Vector3(
                transform.position.x,
                transform.localScale.y / 2,
                transform.position.z);
        }

        private void ChangeSize()
        {
            _size = Mathf.Clamp(Mathf.Log10(_level), MinSize, MaxSize);
            transform.localScale = Vector3.one * _size;
        }
    }
}