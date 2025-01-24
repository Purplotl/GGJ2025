using UnityEngine;

public class camera_follow : MonoBehaviour
{

    [SerializeField] private float cameraMaxRight;
    [SerializeField] private float cameraMaxLeft;
    [SerializeField] private float cameraMaxTop;
    [SerializeField] private float cameraMaxBottom;
    [SerializeField] private float panTime = 0.25f;

    private Vector3 velocity = Vector3.zero;

    private Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y, -10f);

        CameraRestraintsX(pos);
        CameraRestraintsY(pos);
    }

    private void CameraRestraintsX(Vector3 pos)
    {
        if (pos.x >= cameraMaxRight || pos.x <= cameraMaxLeft)
        {
        }
        else
        {
            Vector3 targetPos = new Vector3(pos.x, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, panTime);
        }
    }

    private void CameraRestraintsY(Vector3 pos)
    {
        if (pos.y >= cameraMaxTop || pos.y <= cameraMaxBottom)
        {
        }
        else
        {
            Vector3 targetPos = new Vector3(transform.position.x, pos.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, panTime);
        }
    }
}