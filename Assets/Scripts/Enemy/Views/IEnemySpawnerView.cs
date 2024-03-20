using UnityEngine;

namespace Enemy.Views
{
    public interface IEnemySpawnerView
    {
        float Radius { get; }
        Transform Transform { get; }
    }
}
