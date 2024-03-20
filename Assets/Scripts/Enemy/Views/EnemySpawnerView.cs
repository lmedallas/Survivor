using UnityEngine;

namespace Enemy.Views
{
    public class EnemySpawnerView : MonoBehaviour, IEnemySpawnerView
    {
        [SerializeField] private float _Radius;

        public float Radius => _Radius;
        public Transform Transform => transform;
    }
}
