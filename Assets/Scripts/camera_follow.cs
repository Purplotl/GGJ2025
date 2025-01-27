using UnityEngine;
public class camera_follow : MonoBehaviour
{
    [SerializeField] private float panTime = 0.25f;

    private Vector3 velocity = Vector3.zero;

    private Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, panTime);
    }
}