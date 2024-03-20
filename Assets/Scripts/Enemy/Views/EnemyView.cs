using UnityEngine;

namespace Enemy.Views
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        [SerializeField] private float _MovementSpeed;
        [SerializeField] private SpriteRenderer _SpriteRenderer;

        public float MovementSpeed => _MovementSpeed;

        public Transform Transform => transform;

        public bool FlipSprite { get => _SpriteRenderer.flipX; set => _SpriteRenderer.flipX = value; }

    }
}
