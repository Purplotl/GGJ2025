using UnityEngine;
using System.Collections;

namespace Enemy.behaviour
{
    public class enemy_health : MonoBehaviour
    {
        [SerializeField] private float damageMultiplier;
        [SerializeField] private int points;
        private SpriteRenderer sprite;

        private void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
        }
        public void Damage(float damage)
        {
            damage = damage * damageMultiplier;
            sprite.color = new Color(sprite.color.r + damage, sprite.color.g + damage, sprite.color.b + damage);
            CleanCheck();
        }

        private void CleanCheck()
        {
            if(sprite.color.r >= 0.74901961f)
            {
                score.Score += points;
                sprite.color = new Color(1, 1, 1);
                var colliders = GetComponents<Collider2D>();
                colliders[0].enabled = false;
                colliders[1].enabled = false;
                GetComponent<enemy_movement>().enabled = false;
                StartCoroutine(wait());
            }
        }

        IEnumerator wait()
        {
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }

    }
}