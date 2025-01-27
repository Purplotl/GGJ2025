using System.Collections;
using UnityEngine;

namespace Player.Movement
{
    public class player_collision : MonoBehaviour
    {
        [SerializeField] private player_health playerHealth;

        [SerializeField] private float invincible;
        [SerializeField] private int flashNumber;
        [SerializeField] private SpriteRenderer sprite;

        static public bool hit;
        private Coroutine flashCoroutine;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (player_health.dead || hit) return;

            playerHealth.Damage(0.1f);

            Physics2D.IgnoreLayerCollision(6, 7, true);

            if (flashCoroutine != null)
            {
                StopCoroutine(flashCoroutine);
            }

            flashCoroutine = StartCoroutine(Flash());
        }

        private IEnumerator Flash()
        {
            for (int i = 0; i < flashNumber; i++)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
                yield return new WaitForSeconds(invincible / flashNumber);

                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
                yield return new WaitForSeconds(invincible / flashNumber);
            }

            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);

            flashCoroutine = null;

            hit = false;

            Physics2D.IgnoreLayerCollision(6, 7, false);
        }
    }
}