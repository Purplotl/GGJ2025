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

        private void Update()
        {
            if (dead)
            {
                StartCoroutine(ShowGameover());
            }

            if (player_collision.iFrames)
            {
                StartCoroutine(Flash());
            }
            else
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1);
                flashing = false;
            }

        }

        private IEnumerator Flash()
        {
            if (!flashing)
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0);
                flashing = true;
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1);
                flashing = false;
                yield return new WaitForSeconds(0.1f);
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
        private IEnumerator ShowGameover()
        {
            yield return new WaitForSeconds(2.5f);

            gameOver.SetActive(true);
        }
    }
}