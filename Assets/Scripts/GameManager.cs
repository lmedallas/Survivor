using Cysharp.Threading.Tasks;
using Enemy.Controllers;
using Enemy.Views;
using Maps.Views;
using Player.Controllers;
using Player.Views;
using UnityEngine;
using Utils.AddressableLoader;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private PlayerView playerViewSource;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CreateGame().Forget();
        }
    }

    private async UniTaskVoid CreateGame()
    {
        var mapView = await AddressableLoader.InstantiateAsync<IMapView>("Map_Default");
        var playerView = await AddressableLoader.InstantiateAsync<IPlayerView>("Player_Default");
        var enemyView = await AddressableLoader.InstantiateAsync<IEnemyView>("Zombie_Default");
        IPlayerController playerController = new PlayerController(playerView);
        IEnemyController enemyController = new EnemyController(enemyView, playerView);
    }
}
