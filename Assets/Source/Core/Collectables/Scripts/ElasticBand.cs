using ElasticRush.Core;
using ElasticRush.Effects;
using ElasticRush.Utilities;
using Unity.VisualScripting;
using UnityEngine;

namespace ElasticRush.Collectables
{
    public class ElasticBand : CollectableItem
    {
        [SerializeField, Min(1)] private int _level = 1;

        [Header("VFX")]
        [SerializeField] private PickUpEffect _pickUpEffect;
        [SerializeField] private Color _glowColor;
        [SerializeField] private Gradient _emitColor;

        public static ObjectPool<PickUpEffect> EffectPool { get; private set; }

        private void OnEnable()
        {
            if (EffectPool == null)
                EffectPool = new ObjectPool<PickUpEffect>(_pickUpEffect.gameObject);
        }

        protected override void OnCollected(Player player)
        {
            if (player.IsActive)
            {
                EmitEffect();
                AudioPlayer.PlayClip();
                player.LevelUp(_level);
            }

            base.OnCollected(player);
        }

        private void EmitEffect()
        {
            PickUpEffect vfx = EffectPool.GetInstance();

            var glowModule = vfx.Glow.main;
            glowModule.startColor = _glowColor;

            var emitModule = vfx.Emitter.colorOverLifetime;
            emitModule.enabled = true;
            emitModule.color = _emitColor;

            vfx.gameObject.SetActive(true);
            vfx.transform.SetLocalPositionAndRotation(transform.position, Quaternion.identity);
        }
    }
}