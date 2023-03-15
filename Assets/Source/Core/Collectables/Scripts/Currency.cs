using ElasticRush.Core;
using ElasticRush.Effects;
using ElasticRush.Utilities;
using UnityEngine;

namespace ElasticRush.Collectables
{
    public class Currency : CollectableItem
    {
        [SerializeField] private int _levelsCost;
        [SerializeField] private int _scoreAmount;
        [SerializeField] private Effect _currencyEffect;

        public static ObjectPool<ParticleSystem> EffectPool { get; private set; }

        private void OnEnable()
        {
            if (EffectPool == null)
                EffectPool = new ObjectPool<ParticleSystem>(_currencyEffect.gameObject);
        }

        protected override void OnCollected(Player player)
        {
            if (player.IsActive)
            {
                EmitEffect();
                AudioPlayer.PlayClip();
                player.ExchageLevelsForScore(_levelsCost, _scoreAmount);
            }

            base.OnCollected(player);
        }

        private void EmitEffect()
        {
            ParticleSystem vfx = EffectPool.GetInstance();
            vfx.gameObject.SetActive(true);
            vfx.transform.SetLocalPositionAndRotation(transform.position, Quaternion.identity);
        }
    }
}