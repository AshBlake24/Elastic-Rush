using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(Rigidbody), typeof(WaypointFollower))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 3f)] private float _sensitivty;
        [SerializeField] private float _movingSpeed;
        //[SerializeField] private float _rotationSpeed;
        [SerializeField] private float _xAxisBounds;

        private PlayerInput _input;
        private Rigidbody _rigidbody;
        private WaypointFollower _waypointFollower;
        private Vector3 _currentPosition;
        private Vector3 _direction;
        private bool _isDragging;


        private void Awake()
        {
            _input = new PlayerInput();
            _rigidbody = GetComponent<Rigidbody>();
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

        private void FixedUpdate()
        {
            //Vector3 velocity = _direction.normalized * _movingSpeed;
            //Vector3 newVelocity = Vector3.MoveTowards(_rigidbody.velocity, velocity, _rotationSpeed * Time.deltaTime);

            _rigidbody.velocity = _direction.normalized * _movingSpeed;
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
                        transform.localScale.y / 2,
                        transform.position.z);

                    transform.position = _currentPosition;
                }
            }

            CalculateDirection();
        }

        private void CalculateDirection()
        {
            _direction = _waypointFollower.CurrentWaypoint.transform.position - transform.position;
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