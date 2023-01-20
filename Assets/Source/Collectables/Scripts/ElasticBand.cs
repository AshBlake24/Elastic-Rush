using ElasticRush.Core;
using UnityEngine;

namespace ElasticRush.Collectables
{
    public class ElasticBand : CollectableItem
    {
        protected override void OnCollected(Player player)
        {
            player.LevelUp();

            Destroy(gameObject);
        }
    }
}