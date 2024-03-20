using Cysharp.Threading.Tasks;
using Enemy.Views;
using Player.Views;
using UnityEngine;

namespace Enemy.Controllers
{
    public class EnemyController : IEnemyController
    {
        private IEnemyView enemyView;
        private IPlayerView playerView;

        public EnemyController(IEnemyView _enemyView, IPlayerView _playerView)
        {
            enemyView = _enemyView;
            playerView = _playerView;
            StartMovementCycle().Forget();
        }

        private async UniTask StartMovementCycle()
        {
            var enemyTransform = enemyView.Transform;
            var movementSpeed = enemyView.MovementSpeed;
            var playerTransform = playerView.Transform;
            var step = movementSpeed * Time.deltaTime;
            enemyTransform.position = enemyTransform.position - Vector3.right;

            while (true)
            {
                enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, playerTransform.position, step);
                if (enemyTransform.position.x > playerTransform.position.x) enemyView.FlipSprite = true;
                else enemyView.FlipSprite = false;

                await UniTask.NextFrame();
            }
        }
    }
}
