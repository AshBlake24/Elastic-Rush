using ElasticRush.UI;
using ElasticRush.Utilities;

namespace ElasticRush
{
    public class MusicToggle : AudioToggle
    {
        protected override void CheckVolume()
        {
            IsMuted = SaveSystem.Settings.LoadMusic();
        }

        protected override void OnToggleClick(bool toggleState)
        {
            base.OnToggleClick(toggleState);
            SaveSystem.Settings.SaveMusic(!toggleState);
        }
    }
}