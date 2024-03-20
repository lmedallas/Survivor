using UnityEngine;

namespace Player.Views
{
    public interface IPlayerView
    {
        Vector2 Direction { get; }

        Animator Animator { get; }

        Transform Transform { get; }

        Transform SpawnerAnchor { get; }

        float MovementSpeed { get; }

        bool FlipSprite { get; set; }

        int MoveState { set; }
    }
}