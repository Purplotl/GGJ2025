using UnityEngine;

namespace Player.Movement
{
    public class player_move : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody2D rb;
        protected Vector2 input;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rb.linearVelocity = speed * input * Time.fixedDeltaTime;
        }
    }
}