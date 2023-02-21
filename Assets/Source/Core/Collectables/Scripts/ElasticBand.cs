using ElasticRush.Core;
using UnityEngine;

namespace ElasticRush.Collectables
{
    public class ElasticBand : CollectableItem
    {
        [SerializeField, Min(1)] private int _level = 1;

        protected override void OnCollected(Player player)
        {
            if (player.IsActive)
            {
                AudioPlayer.PlayClip();
                player.LevelUp(_level);
            }

            base.OnCollected(player);
        }
    }
}