using UnityEngine;
using System.Collections;

namespace Player.Movement
{
    public class player_health : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;

        [SerializeField] private GameObject gameOver;
        static public bool dead;

        private void Update()
        {
            if (dead)
            {
                StartCoroutine(ShowGameover());
            }
        }

        public void Damage(float damage)
        {
            if (player_health.dead || player_collision.hit) return;

            Debug.Log("Damage player");

            sprite.color = new Color(sprite.color.r - damage, sprite.color.g - damage, sprite.color.b - damage, 1);
            CleanCheck();
        }

        private void CleanCheck()
        {
            if (sprite.color.r <= 0.01)
            {
                sprite.color = new Color(0, 0, 0);
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