using ElasticRush.Utilities;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(Player))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _minSensitivty = 0.01f;
        [SerializeField] private float _maxSensitivty = 1.00f;
        [SerializeField] private float _xAxisBounds;

        private Player _player;
        private PlayerInput _input;
        private Sensitivity _sensitivity;
        private bool _isDragging;
        private bool _isMoving;

        public Sensitivity Sensitivity => _sensitivity;
        public PlayerInput Input => _input;

        private void Awake()
        {
            float sensitivity = SaveSystem.Settings.LoadSensitivity();
            _sensitivity = new Sensitivity(_minSensitivty, _maxSensitivty, sensitivity);
            _input = new PlayerInput();
            _player = GetComponent<Player>();
        }

        private void OnEnable()
        {
            _input.Enable();

            _input.Player.Click.started += (ctx) => OnClickStarted();
            _input.Player.Click.canceled += (ctx) => OnClickCanceled();
            _input.Player.Move.started += (ctx) => OnMoveStarted();
            _input.Player.Move.canceled += (ctx) => OnMoveCanceled();
        }

        private void OnDisable()
        {
            _input.Disable();

            _input.Player.Click.started -= (ctx) => OnClickStarted();
            _input.Player.Click.canceled -= (ctx) => OnClickCanceled();
            _input.Player.Move.started -= (ctx) => OnMoveStarted();
            _input.Player.Move.canceled -= (ctx) => OnMoveCanceled();
        }

        private void Update()
        {
            if (_player.IsActive == false)
                return;

            if (_isMoving)
                TryMove(_input.Player.Move.ReadValue<float>());
            else if (_isDragging && Helpers.IsOverUI() == false)
                TryMove(_input.Player.Drag.ReadValue<Vector2>().x);
        }

        private void TryMove(float moveDelta)
        {
            if (moveDelta != 0)
            {
                float scaledMoveDelta = moveDelta * _sensitivity.Value * Time.deltaTime;

                var localPosition = new Vector3(
                    Mathf.Clamp(transform.localPosition.x + scaledMoveDelta, -_xAxisBounds, _xAxisBounds),
                    transform.localPosition.y,
                    transform.localPosition.z);

                transform.localPosition = localPosition;
            }
        }

        private void OnMoveStarted() => _isMoving = true;

        private void OnMoveCanceled() => _isMoving = false;

        private void OnClickStarted() => _isDragging = true;

        private void OnClickCanceled() => _isDragging = false;
    }
}