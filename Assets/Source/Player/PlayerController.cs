using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(WaypointFollower))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 3f)] private float _sensitivty;
        [SerializeField] private float _movingSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _xAxisBounds;

        private PlayerInput _input;
        private WaypointFollower _waypointFollower;
        private Vector3 _currentPosition;
        private bool _isDragging;


        private void Awake()
        {
            _input = new PlayerInput();
            _waypointFollower = GetComponent<WaypointFollower>();
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

            if (_waypointFollower.CurrentWaypoint != null)
                Rotate();

            transform.Translate(transform.forward * _movingSpeed * Time.deltaTime, Space.World);
        }

        private void Rotate()
        {
            var direction = _waypointFollower.CurrentWaypoint.transform.position - transform.position;
            var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
        }

        private void TryDrag()
        {
            float xAxisMoveDelta = _input.Player.Drag.ReadValue<Vector2>().x;

            if (xAxisMoveDelta != 0)
            {
                float xAxisScaledMoveDelta = xAxisMoveDelta * _sensitivty * Time.deltaTime;

                var direction = new Vector3(xAxisScaledMoveDelta, 0, 0);

                transform.position += transform.TransformDirection(direction);
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