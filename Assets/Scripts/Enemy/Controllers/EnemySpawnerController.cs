using Cysharp.Threading.Tasks;
using Enemy.Views;
using Player.Views;
using UnityEngine;
using UnityEngine.Pool;
using Utils.AddressableLoader;

namespace Enemy.Controllers
{
    public class EnemySpawnerController : IEnemySpawnerController
    {
        private IEnemySpawnerView enemySpawnerView;
        private IEnemyView enemyView;
        private IObjectPool<GameObject> enemyPool;
        private IPlayerView playerTarget;
        private const int poolSize = 1000;

        public EnemySpawnerController(IEnemySpawnerView _enemySpawnerView, IPlayerView _playerTarget)
        {
            enemySpawnerView = _enemySpawnerView;
            playerTarget = _playerTarget;

            GenerateEnemies("Zombie_Default", 10).Forget();
            GenerateEnemies("Zombie_Variation", 10).Forget();
        }

        private async UniTaskVoid GenerateEnemies(string styleName, int enemyCount)
        {
            enemyView = await AddressableLoader.InstantiateAsync<IEnemyView>(styleName);

            enemyPool = new ObjectPool<GameObject>(
                CreatePooledItem,
                OnTakedFromPool,
                OnReturnedPool,
                OnDestroyPoolObject,
                true,
                enemyCount,
                poolSize
            );

            for (int i = 0; i < 10; i++)
            {
                enemyPool.Get();
            }
        }

        private GameObject CreatePooledItem()
        {
            var position = enemySpawnerView.Transform.position;
            var enemyPosition = (Vector2) position + Random.insideUnitCircle * enemySpawnerView.Radius;
            var enemy = Object.Instantiate(enemyView.GameObject, enemyPosition, Quaternion.identity);
            var zombieView = enemy.GetComponent<IEnemyView>();

            var enemyController = new EnemyController(zombieView, playerTarget);
            return enemy;
        }

        private void OnTakedFromPool(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        private void OnReturnedPool(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        private void OnDestroyPoolObject(GameObject gameObject)
        {
            Object.Destroy(gameObject);
        }
    }
}
