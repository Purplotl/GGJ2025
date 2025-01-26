using UnityEngine;
using System.Collections;

namespace Player.Movement
{
    public class player_health : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer renderer;
        [SerializeField] private GameObject gameOver;
        private bool flashing;
        static public bool dead;

        private void FixedUpdate()
        {
            if (dead)
            {
                StartCoroutine(ShowGameover());
            }

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
            if (player_health.dead) return;

            renderer.color = new Color(renderer.color.r - damage, renderer.color.g - damage, renderer.color.b - damage);
            CleanCheck();
        }

        private void CleanCheck()
        {
            if (renderer.color.r <= 0.01)
            {
                renderer.color = new Color(0, 0, 0);
                dead = true;
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

        private IEnumerator ShowGameover()
        {
            yield return new WaitForSeconds(2.5f);

            gameOver.SetActive(true);
        }
    }
}