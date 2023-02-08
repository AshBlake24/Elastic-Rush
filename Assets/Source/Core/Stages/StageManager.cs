using ElasticRush.Utilities;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ElasticRush
{
    public class StageManager : MonoBehaviour
    {
        public const string StartLevel = "Level 1";

        [SerializeField] private Scene[] _stages;

        private int _currentStageIndex;
        private Scene _currentStage;

        public Scene CurrentStage => _currentStage;

        public void SetNextStage()
        {
            _currentStageIndex++;

            if ((_currentStageIndex + 1) < _stages.Length)
                _currentStageIndex++;
            else
                _currentStageIndex = 0;

            _currentStage = _stages[_currentStageIndex];
        }

        private void LoadPlayerData()
        {
            string currentStage = SaveSystem.Stage.Load();

            for (int i = 0; i < _stages.Length; i++)
            {
                if (_stages[i].name == currentStage)
                {
                    _currentStage = _stages[i];
                    _currentStageIndex = i;
                    return;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(currentStage), "This scene doesn't exist");
        }
    }
}
