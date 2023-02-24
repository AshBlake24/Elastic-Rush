using System;
using TMPro;

namespace ElasticRush.Core
{
    public interface IReadonlyElasticBall
    {
        int Level { get; }
        TMP_Text LevelFrame { get; }

        event Action LevelChanged;
        event Action<float> SizeChanged;
    }
}