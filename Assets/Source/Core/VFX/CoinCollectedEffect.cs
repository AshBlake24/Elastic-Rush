using ElasticRush.Collectables;

namespace ElasticRush.Effects
{
    public class CoinCollectedEffect : Effect
    {
        protected override void OnParticleSystemStopped()
        {
            Coin.EffectPool.AddInstance(ParticleSystem);
        }
    }
}