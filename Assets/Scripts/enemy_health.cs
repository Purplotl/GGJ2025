using Player.Movement;
using UnityEngine;

namespace Enemy.behaviour
{
    public class enemy_health : MonoBehaviour
    {
        [SerializeField] private float damageMultiplier;
        private SpriteRenderer renderer;

        private void Awake()
        {
            renderer = GetComponent<SpriteRenderer>();
        }
        public void Damage(float damage)
        {
            damage = damage * damageMultiplier;
            renderer.color = new Color(renderer.color.r + damage, renderer.color.g + damage, renderer.color.b + damage);
            CleanCheck();
        }

        private void CleanCheck()
        {
            if(renderer.color.r >= 0.74901961f)
            {
                score.Score += 1;
                renderer.color = new Color(1, 1, 1);
                var colliders = GetComponents<Collider2D>();
                colliders[0].enabled = false;
                colliders[1].enabled = false;
                GetComponent<enemy_movement>().enabled = false;
                Destroy(this.gameObject);
            }
        }
    }
}