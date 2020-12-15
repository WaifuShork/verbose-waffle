using UnityEngine;

namespace VB
{
    public class PlayerMovement : MonoBehaviour
    {
        private new Rigidbody2D rigidbody;
        private Animator animator;
        private Vector2 movement;
        
        [SerializeField] private float moveSpeed = 5.0f;

        private static int Horizontal;
        private static int Vertical;
        private static int Speed;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

            Horizontal = Animator.StringToHash("Horizontal");
            Vertical = Animator.StringToHash("Vertical");
            Speed = Animator.StringToHash("Speed");
        }
        private void FixedUpdate()
        {
            Movement();
        }

        private void Update()
        {
            GetInput();
            OnAnimate();
        }

        private void GetInput()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement.Normalize();
        }

        private void Movement()
        {
            rigidbody.MovePosition(rigidbody.position + movement * (moveSpeed * Time.fixedDeltaTime));
        }

        private void OnAnimate()
        {
            animator.SetFloat(Horizontal, movement.x);
            animator.SetFloat(Vertical, movement.y);
            animator.SetFloat(Speed, movement.sqrMagnitude);
        }
    }
}