using UnityEngine;

namespace Enemy.behaviour
{
    public class enemy_health : MonoBehaviour
    {
        [SerializeField] private float damageMultiplier;
        public void Damage(float damage)
        {
            damage = damage * damageMultiplier;
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r + damage, GetComponent<SpriteRenderer>().color.g + damage, GetComponent<SpriteRenderer>().color.b + damage);
            CleanCheck();
        }

        private void CleanCheck()
        {
            if(GetComponent<SpriteRenderer>().color.r >= 0.74901961f)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                GetComponent<Collider2D>().enabled = false;
                GetComponent<enemy_movement>().enabled = false;
            }
        }
    }
}