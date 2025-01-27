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
        private bool isCooldown = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (player_health.dead || hit || isCooldown) return;

            isCooldown = true;
            StartCoroutine(ResetCooldown());

            Debug.Log("Collision enter");

            playerHealth.Damage(0.1f);

            Physics2D.IgnoreLayerCollision(6, 7, true);

            Debug.Log("Collision disabled");

            if (flashCoroutine != null)
            {
                Debug.Log("coroutine isnt null");

                StopCoroutine(flashCoroutine);
            }
            flashCoroutine = StartCoroutine(Flash());
        }

        private IEnumerator Flash()
        {
            Debug.Log("start coroutine");

            for (int i = 0; i < flashNumber; i++)
            {
                Debug.Log("for loop "+i);

                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
                yield return new WaitForSecondsRealtime(invincible / flashNumber);

                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
                yield return new WaitForSecondsRealtime(invincible / flashNumber);
            }

            Debug.Log("for loop end");

            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);

            flashCoroutine = null;

            hit = false;

            Physics2D.IgnoreLayerCollision(6, 7, false);

            Debug.Log("player reset");
        }

        private IEnumerator ResetCooldown()
        {
            Debug.Log("resetting cooldown");
            yield return new WaitForSeconds(0.1f);
            isCooldown = false;
            Debug.Log("cooldown reset");
        }
    }
}