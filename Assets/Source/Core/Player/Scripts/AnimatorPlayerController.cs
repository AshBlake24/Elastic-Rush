using UnityEngine;

namespace ElasticRush.Core
{
    public class AnimatorPlayerController : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private MoveStarter _playerMoveStarter;
        [SerializeField] private PathFollower _playerPathFollower;

        private void OnEnable()
        {
            _playerMoveStarter.MoveStarted += OnMoveStarted;
            _playerPathFollower.MoveStoped += OnMoveStoped;
            _playerPathFollower.PauseChanged += OnPauseChanged;
        }

        private void OnDisable()
        {
            _playerMoveStarter.MoveStarted -= OnMoveStarted;
            _playerPathFollower.MoveStoped -= OnMoveStoped;
            _playerPathFollower.PauseChanged -= OnPauseChanged;
        }

        private void ChangeRollingState(bool isRolling)
        {
            _playerAnimator.SetBool(States.Rolling, isRolling);
        }

        private void OnPauseChanged(bool isPaused) => ChangeRollingState(!isPaused);

        private void OnMoveStoped() => ChangeRollingState(false);

        private void OnMoveStarted() => ChangeRollingState(true);

        private static class States
        {
            public const string Rolling = nameof(Rolling);
        }
    }
}