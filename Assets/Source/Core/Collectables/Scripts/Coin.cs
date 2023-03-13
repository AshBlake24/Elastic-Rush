using ElasticRush.Core;
using ElasticRush.Utilities;
using ElasticRush.Effects;
using UnityEngine;

namespace ElasticRush.Collectables
{
    public class Coin : CollectableItem
    {
        [SerializeField] private int _scoreAmount;
        [SerializeField] private Effect _coinEffect;

        public static ObjectPool<ParticleSystem> EffectPool { get; private set; }

        private void OnEnable()
        {
            if (EffectPool == null)
                EffectPool = new ObjectPool<ParticleSystem>(_coinEffect.gameObject);
        }

        protected override void OnCollected(Player player)
        {
            if (player.IsActive)
            {
                EmitEffect();
                AudioPlayer.PlayClip();
                player.AddScore(_scoreAmount);
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