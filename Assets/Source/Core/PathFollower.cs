using UnityEngine;
using PathCreation;
using System;
using ElasticRush.Utilities;
using System.Collections;

namespace ElasticRush.Core
{
    public class PathFollower : MonoBehaviour
    {
        [SerializeField] private PathCreator _pathCreator;
        [SerializeField] private EndOfPathInstruction _endOfPathInstruction;
        [SerializeField] private float _speed;

        private float _distanceTravelled;
        private float _currentSpeed;
        private bool _isPaused;

        public event Action MoveStoped;
        public event Action<bool> PauseChanged;

        private void OnEnable()
        {
            _pathCreator.pathUpdated += OnPathUpdated;
        }

        private void OnDisable()
        {
            _pathCreator.pathUpdated -= OnPathUpdated;
        }

        private void Start()
        {
            _isPaused = true;
        }

        private void Update()
        {
            if (_isPaused)
                return;

            _distanceTravelled += _speed * Time.deltaTime;
            transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled, _endOfPathInstruction);
            transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled, _endOfPathInstruction);
        }

        public void SetPause(bool isPaused)
        {
            if (isPaused)
                _isPaused = true;
            else
                _isPaused = false;

            PauseChanged?.Invoke(_isPaused);
        }

        public IEnumerator StopMovingSlowly()
        {
            float duration = Config.Player.TimeToStopRolling;
            float maxSpeed = _speed;
            float elapsedTime = 0;

            while (elapsedTime < duration)
            {
                _speed = Mathf.Lerp(maxSpeed, 0, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            MoveStoped?.Invoke();
        }

        public void StopMoving()
        {
            _speed = 0;
            MoveStoped?.Invoke();
        }

        private void OnPathUpdated()
        {
            _distanceTravelled = _pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}