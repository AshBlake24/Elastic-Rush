using ElasticRush.UI;
using ElasticRush.Utilities;

namespace ElasticRush
{
    public class SoundToggle : AudioToggle
    {
        protected override void CheckVolume()
        {
            IsMuted = SaveSystem.Settings.LoadSound();
        }

        protected override void OnToggleClick(bool toggleState)
        {
            base.OnToggleClick(toggleState);
            SaveSystem.Settings.SaveSound(!toggleState);
        }
    }
}