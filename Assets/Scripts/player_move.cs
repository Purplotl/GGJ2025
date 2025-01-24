using UnityEngine;

namespace Player.Movement
{
    public class player_move : MonoBehaviour
    {
        [SerializeField] private float speed = 200f;
        [SerializeField] private float smoothSpeed = .45f;
        private Rigidbody2D rb;
        private Vector3 velocity = Vector3.zero;
        protected Vector2 input;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Vector3 targetVelocity = speed * input * Time.fixedDeltaTime;

            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, smoothSpeed);
        }
    }
}