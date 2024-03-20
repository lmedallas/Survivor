using UnityEngine;

namespace Enemy.Views
{
    public interface IEnemyView
    {
        Transform Transform { get; }

        float MovementSpeed { get; }

        bool FlipSprite { get; set; }
    }
}
