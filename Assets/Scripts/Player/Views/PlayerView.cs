using Utils.Bindings;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Views
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private Animator _Animator;
        [SerializeField] private SpriteRenderer _SpriteRenderer;
        [SerializeField] private PlayerInput _PlayerInput;
        [SerializeField] private Transform _SpawnerAnchor;
        [SerializeField] private float _MovementSpeed;
        private Vector2 _Direction;
        [SerializeField] private IntBinding _MoveBinding;

        public Vector2 Direction => _Direction;
        public Transform Transform => transform;
        public Transform SpawnerAnchor => _SpawnerAnchor;
        public Animator Animator => _Animator;
        public float MovementSpeed => _MovementSpeed;
        public bool FlipSprite { get => _SpriteRenderer.flipX; set => _SpriteRenderer.flipX = value; }
        public int MoveState { set => _MoveBinding.Value = value; }

        public void SetDirection(InputAction.CallbackContext ctx)
        {
            _Direction = ctx.ReadValue<Vector2>();
        }
        private void TranslateAllDirections(Vector2 axis) => transform.Translate(axis * Time.deltaTime * _MovementSpeed);
    }
}
