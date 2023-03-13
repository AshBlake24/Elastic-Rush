using ElasticRush.Core;

namespace ElasticRush.Effects
{
    public class PlayerDestroyEffect : Effect
    {
        protected override void OnParticleSystemStopped()
        {
            Player.EffectPool.AddInstance(ParticleSystem);
        }
    }
}