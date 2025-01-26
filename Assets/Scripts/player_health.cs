using UnityEngine;

namespace Player.Movement
{
    public class player_health : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer renderer;
        private bool flashing;

        private void FixedUpdate()
        {
            if (player_collision.iFrames)
            {
                Flash();
            }
            else
            {
                renderer.enabled = true;
                flashing = false;
            }
        }
        public void Damage(float damage)
        {
            renderer.color = new Color(renderer.color.r - damage, renderer.color.g - damage, renderer.color.b - damage);
            CleanCheck();
        }

        private void CleanCheck()
        {
            if (renderer.color.r <= 0.01)
            {
                renderer.color = new Color(0, 0, 0);
                GetComponent<Collider2D>().enabled = false;
                GetComponent<player_input>().enabled = false;
            }
        }

        private void Flash()
        {
            if (flashing)
            {
                renderer.enabled = false;
                flashing = false;
            }
            else
            {
                renderer.enabled = true;
                flashing = true;
            }
        }
    }
}