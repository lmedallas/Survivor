using UnityEngine;

namespace Enemy.Views
{
    public interface IEnemyView
    {
        Transform Transform { get; }

        GameObject GameObject { get; }

        float MovementSpeed { get; }

        bool FlipSprite { get; set; }
    }
}
