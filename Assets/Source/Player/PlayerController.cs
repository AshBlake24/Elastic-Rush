using UnityEngine;

namespace ElasticRush.Core
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 3f)] private float _sensitivty;
        [SerializeField] private float _xAxisBounds;

        private PlayerInput _input;
        private bool _isDragging;


        private void Awake()
        {
            _input = new PlayerInput();
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
                float scaledMoveDeltaAlongX = moveDeltaAlongX * _sensitivty * Time.deltaTime;

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