using UnityEngine;

namespace Player.Views
{
    public interface IPlayerView
    {
        Vector2 Direction { get; }

        Transform Transform { get; }

        float MovementSpeed { get; }
        bool FlipSprite { get; set; }

        int MoveState { set; }
    }
}