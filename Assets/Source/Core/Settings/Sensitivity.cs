using System;

namespace ElasticRush.Utilities
{
    public class Sensitivity
    {
        public const float DefaultValue = 0.6f;
        public readonly float MinValue;
        public readonly float MaxValue;

        public Sensitivity(float minValue, float maxValue, float startValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            TryChangeSensitivity(startValue);
        }

        public float Value { get; private set; }

        public void TryChangeSensitivity(float value)
        {
            Value = Math.Clamp(value, MinValue, MaxValue);
        }
    }
}