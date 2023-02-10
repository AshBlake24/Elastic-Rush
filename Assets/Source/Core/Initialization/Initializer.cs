using ElasticRush.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ElasticRush
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private string _startScene;

        private void Start()
        {
            SceneLoader.Instance.LoadScene(_startScene);
        }
    }
}