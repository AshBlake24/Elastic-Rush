using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI.Extensions;

namespace ElasticRush
{
    public class ChangeSceneButton : Button
    {
        [SerializeField] private string _nextSceneName;

        protected override void OnButtonClick()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneLoader.Instance.ChangeScene(_nextSceneName, currentSceneName);
        }
    }
}