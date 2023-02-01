using UnityEngine.SceneManagement;

namespace ElasticRush
{
    public class RestartButton : UnityEngine.UI.Extensions.Button
    {
        protected override void OnButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}