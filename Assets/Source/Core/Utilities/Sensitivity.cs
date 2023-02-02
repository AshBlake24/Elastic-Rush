using System;

namespace ElasticRush.Utilities
{
    public class Sensitivity
    {
        public readonly float MinValue;
        public readonly float MaxValue;

        public Sensitivity(float minValue, float maxValue, float value)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            TryChangeSensitivity(value);
        }

        public float Value { get; private set; }

        public void TryChangeSensitivity(float value)
        {
            Value = Math.Clamp(value, MinValue, MaxValue);
        }
    }
}