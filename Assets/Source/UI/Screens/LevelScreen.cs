using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ElasticRush
{
    public class LevelScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelScreen;

        private void Start()
        {
            _levelScreen.text = SceneManager.GetActiveScene().name;
        }
    }
}