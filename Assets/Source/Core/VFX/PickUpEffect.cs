using ElasticRush.Collectables;
using UnityEngine;

namespace ElasticRush.Effects
{
    public class PickUpEffect : Effect
    {
        [SerializeField] private ParticleSystem _glow;
        [SerializeField] private ParticleSystem _emitter;

        public ParticleSystem Glow => _glow;
        public ParticleSystem Emitter => _emitter;

        protected override void OnParticleSystemStopped()
        {
            ElasticBand.EffectPool.AddInstance(this);
        }
    }
}