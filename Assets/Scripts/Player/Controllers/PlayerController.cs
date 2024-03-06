using Cysharp.Threading.Tasks;
using Player.Views;
using UnityEngine;

namespace Player.Controllers
{
    public class PlayerController : IPlayerController
    {
        private IPlayerView playerView;

        public PlayerController(IPlayerView _playerView)
        {
            playerView = _playerView;
            StartMovementCycle().Forget();
        }

        private async UniTask StartMovementCycle()
        {
            var transform = playerView.Transform;
            var movementSpeed = playerView.MovementSpeed;

            while (true)
            {
                var direction = playerView.Direction;
                var horizontal = direction.x;

                var flipX = playerView.FlipSprite;
                flipX = !(horizontal > 0f) && (horizontal < 0f || flipX);
                playerView.FlipSprite = flipX;

                playerView.MoveState = (int)Mathf.Abs(direction.magnitude);
                transform.Translate(direction * movementSpeed * Time.deltaTime);
                await UniTask.NextFrame();
            }
        }
    }
}
