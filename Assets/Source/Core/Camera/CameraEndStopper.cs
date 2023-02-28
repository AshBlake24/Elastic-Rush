using Cinemachine;
using UnityEngine;

namespace ElasticRush.Core
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraEndStopper : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Transform _stopPoint;

        private CinemachineVirtualCamera _camera;

        private void Awake()
        {
            _camera = GetComponent<CinemachineVirtualCamera>();
        }

        private void OnEnable()
        {
            _player.Destroying += OnDestroying;
        }

        private void OnDisable()
        {
            _player.Destroying -= OnDestroying;
        }

        private void OnDestroying() => StopCamera();

        private void StopCamera()
        {
            Transform cameraStopPoint = new GameObject("Camera Stop Point").transform;
            cameraStopPoint.position = _stopPoint.position;
            _camera.Follow = cameraStopPoint;
        }
    }
}