using UnityEngine;

namespace Enemy.behaviour
{
    public class enemy_health : MonoBehaviour
    {
        public void Damage(float damage)
        {
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r + damage, GetComponent<SpriteRenderer>().color.g + damage, GetComponent<SpriteRenderer>().color.b + damage);
        }

        private void Update()
        {
            
        }
    }
}