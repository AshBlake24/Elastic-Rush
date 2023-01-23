using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 3f)] private float _sensitivty;
        [SerializeField] private float _forwardSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _xAxisBounds;
        [SerializeField] private Waypoint _startWaypoint;

        private Vector3 _currentPosition;
        private WaypointFollower _waypointFollower;
        private Rigidbody _rigidbody;
        private PlayerInput _input;
        private bool _isDragging;
        private Vector3 _currentVelocity;

        private void Awake()
        {
            _input = new PlayerInput();
            _rigidbody = GetComponent<Rigidbody>();
            _waypointFollower = new WaypointFollower(_startWaypoint);
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
            float distanceToWaypoint = Vector3.Distance(
                transform.position,
                _waypointFollower.CurrentWaypoint.transform.position);

            if (distanceToWaypoint < 0.5f)
            {
                _waypointFollower.SetNextWaypoint();
                Debug.Log("Set new waypoint");
            }

            Vector3 direction = _waypointFollower.CurrentWaypoint.transform.position - transform.position;

            _rigidbody.velocity = direction.normalized * _forwardSpeed;
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
        }

        private void LateUpdate()
        {
            //if (_waypointFollower == null)
            //    return;

            //float distanceToWaypoint = Vector3.Distance(
            //    transform.position,
            //    _waypointFollower.CurrentWaypoint.transform.position);

            //if (distanceToWaypoint < 0.5f)
            //{
            //    _waypointFollower.SetNextWaypoint();
            //    Debug.Log("Set new waypoint");
            //}
            //else
            //    Rotate();
        }

        private void Rotate()
        {
            Vector3 direction = _waypointFollower.CurrentWaypoint.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);

            //float yAxisRotation = Mathf.SmoothDamp(
            //    transform.eulerAngles.y,
            //    lookRotation.eulerAngles.y,
            //    ref _currentVelocity,
            //    _rotationSpeed * Time.deltaTime);

            Vector3 rotation = Vector3.SmoothDamp(
                transform.eulerAngles,
                lookRotation.eulerAngles,
                ref _currentVelocity,
                _rotationSpeed);

            transform.rotation = Quaternion.Euler(rotation);
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