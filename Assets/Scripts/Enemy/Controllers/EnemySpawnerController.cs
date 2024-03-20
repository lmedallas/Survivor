using Enemy.Views;

namespace Enemy.Controllers
{
    public class EnemySpawnerController : IEnemySpawnerController
    {
        private IEnemySpawnerView enemySpawnerView;

        public EnemySpawnerController(IEnemySpawnerView _enemySpawnerView)
        {
            enemySpawnerView = _enemySpawnerView;
        }
    }
}
