using ElasticRush.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ElasticRush
{
    public class Initializer : MonoBehaviour
    {
        private string _currentStage;

        private void Awake()
        {
            LoadPlayerData();

            SceneManager.LoadScene(_currentStage);
        }

        private void LoadPlayerData()
        {
            _currentStage = SaveSystem.Stage.Load();
        }
    }
}