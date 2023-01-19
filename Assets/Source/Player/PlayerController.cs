using UnityEngine;
using UnityEngine.EventSystems;

namespace ElasticRush.Core
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 3f)] private float _sensitivty;
        [SerializeField] private float _xAxisBounds;

        private PlayerInput _input;
        private bool _isDragging;
        private Vector3 _currentPosition;

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
            {
                float xAxisMoveDelta = _input.Player.Drag.ReadValue<Vector2>().x;

                if (xAxisMoveDelta != 0)
                {
                    float xAxisScaledMoveDelta = xAxisMoveDelta * _sensitivty * Time.deltaTime;

                    _currentPosition = new Vector3(
                        Mathf.Clamp(_currentPosition.x + xAxisScaledMoveDelta, -_xAxisBounds, _xAxisBounds),
                        transform.position.y,
                        transform.position.z);

                    transform.position = _currentPosition;
                }
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
