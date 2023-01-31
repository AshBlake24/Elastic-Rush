using ElasticRush.Core;
using UnityEngine;

namespace ElasticRush.Collectables
{
    public class Currency : CollectableItem
    {
        [SerializeField] private int _levelsCost;
        [SerializeField] private int _scoreAmount;

        protected override void OnCollected(Player player)
        {
            player.ExchageLevelsForScore(_levelsCost, _scoreAmount);
        }
    }
}