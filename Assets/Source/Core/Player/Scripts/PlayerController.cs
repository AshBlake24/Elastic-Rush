using ElasticRush.Utilities;
using UnityEngine;

namespace ElasticRush.Core
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _minSensitivty = 0.1f;
        [SerializeField] private float _maxSensitivty = 3.0f;
        [SerializeField] private float _startSensitivty;
        [SerializeField] private float _xAxisBounds;

        private PlayerInput _input;
        private Sensitivity _sensitivity;
        private bool _isDragging;

        public Sensitivity Sensitivity => _sensitivity;
        public PlayerInput Input => _input;

        private void Awake()
        {
            _input = new PlayerInput();
            _sensitivity = new Sensitivity(_minSensitivty, _maxSensitivty, _startSensitivty);
        }

        private void OnEnable()
        {
            _input.Enable();

            _input.Player.Click.started += (ctx) => OnClickStarted();
            _input.Player.Click.canceled += (ctx) => OnClickCanceled();
        }

        private void OnDisable()
        {
            _input.Disable();

            _input.Player.Click.started -= (ctx) => OnClickStarted();
            _input.Player.Click.canceled -= (ctx) => OnClickCanceled();
        }

        private void Update()
        {
            if (_isDragging)
                TryDrag();
        }

        private void TryDrag()
        {
            float moveDeltaAlongX = _input.Player.Drag.ReadValue<Vector2>().x;

            if (moveDeltaAlongX != 0)
            {
                float scaledMoveDeltaAlongX = moveDeltaAlongX * _sensitivity.Value * Time.deltaTime;

                var localPosition = new Vector3(
                    Mathf.Clamp(transform.localPosition.x + scaledMoveDeltaAlongX, -_xAxisBounds, _xAxisBounds),
                    transform.localPosition.y,
                    transform.localPosition.z);

                transform.localPosition = localPosition;
            }
        }

        private void OnClickStarted()
        {
            _isDragging = true;
        }

        private void OnClickCanceled()
        {
            _isDragging = false;
        }
    }
}