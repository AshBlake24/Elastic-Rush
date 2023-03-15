using ElasticRush.Collectables;

namespace ElasticRush.Effects
{
    public class CurrencyEffect : Effect
    {
        protected override void OnParticleSystemStopped()
        {
            Currency.EffectPool.AddInstance(ParticleSystem);
        }
    }
}