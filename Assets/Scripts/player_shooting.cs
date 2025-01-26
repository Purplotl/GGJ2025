using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Movement
{
    public class player_shooting : MonoBehaviour
    {
        [SerializeField] private ParticleSystem bubbles;
        private void OnFire(InputValue value)
        {
            if (player_health.dead)
            {
                bubbles.Stop();
                return;
            }

            if (value.isPressed)
            {
                bubbles.Play();
            }
            else
            {
                bubbles.Stop();
            }
        }

        private void OnLook(InputValue value)
        {
            if (player_health.dead) return;

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
            LookAt(mousePosition);
        }
        protected void LookAt(Vector3 target)
        {
            if (player_health.dead) return;

            float lookAngle = AngleBetweenTwoPoint(transform.position, target) + 90;

            transform.eulerAngles = new Vector3(0, 0, lookAngle);
        }

        private float AngleBetweenTwoPoint(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }
    }
}