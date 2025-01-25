using UnityEngine;

namespace Enemy.Health
{
    public class projectile_collision : MonoBehaviour
    {
        [SerializeField] private enemy_health enemyHealth;
        private void OnParticleCollision(GameObject particle)
        {
            enemyHealth.Damage(0.00392157f);
        }
    }
}