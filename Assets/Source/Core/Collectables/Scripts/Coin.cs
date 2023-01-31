using ElasticRush.Core;
using UnityEngine;

namespace ElasticRush.Collectables
{
    public class Coin : CollectableItem
    {
        [SerializeField] private int _scoreAmount;

        protected override void OnCollected(Player player)
        {
            player.AddScore(_scoreAmount);
            Destroy(gameObject);
        }
    }
}