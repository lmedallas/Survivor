using Cysharp.Threading.Tasks;
using Enemy.Controllers;
using Enemy.Views;
using Player.Views;
using UnityEngine;
using Utils.AddressableLoader;

namespace Player.Controllers
{
    public class PlayerController : IPlayerController
    {
        private IPlayerView playerView;
        private IEnemySpawnerView enemySpawnerView;
        private IEnemySpawnerController enemySpawnerController;

        public PlayerController(IPlayerView _playerView)
        {
            playerView = _playerView;
            StartMovementCycle().Forget();
            LoadEnemySpawner().Forget();
        }

        private async UniTaskVoid LoadEnemySpawner()
        {
            enemySpawnerView = await AddressableLoader.InstantiateAsync<IEnemySpawnerView>("Spawner_Default", playerView.SpawnerAnchor);
            enemySpawnerController = new EnemySpawnerController(enemySpawnerView, playerView);
        }

        private async UniTask StartMovementCycle()
        {
            var transform = playerView.Transform;
            var movementSpeed = playerView.MovementSpeed;
            int isMoving = 0;

            while (true)
            {
                var direction = playerView.Direction;
                var horizontal = direction.x;

                if (direction != Vector2.zero) isMoving = 1;
                else isMoving = 0;

                playerView.Animator.SetInteger("Move", isMoving);

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
