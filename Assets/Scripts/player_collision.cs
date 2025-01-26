using System.Collections;
using UnityEngine;

namespace Player.Movement
{
    public class player_collision : MonoBehaviour
    {
        [SerializeField] private player_health playerHealth;

        static public bool iFrames;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (player_health.dead) return;

            if (iFrames) return;

            playerHealth.Damage(0.1f);
            iFrames = true;

            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(1);
            iFrames = false;
        }
    }
}