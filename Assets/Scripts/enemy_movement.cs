using UnityEngine;

namespace Enemy.behaviour
{
    public class enemy_movement : MonoBehaviour
    {
        private Transform target;
        public float speed;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        private void Update()
        {
            LookAt(target.position);

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }
        protected void LookAt(Vector3 target)
        {
            float lookAngle = AngleBetweenTwoPoint(transform.position, target) + 90;

            transform.eulerAngles = new Vector3(0, 0, lookAngle);
        }

        private float AngleBetweenTwoPoint(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }
    }
}