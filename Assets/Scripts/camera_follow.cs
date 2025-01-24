using UnityEngine;

public class camera_follow : MonoBehaviour
{

    [SerializeField] private float cameraMaxRight;
    [SerializeField] private float cameraMaxLeft;
    [SerializeField] private float cameraMaxTop;
    [SerializeField] private float cameraMaxBottom;
    private Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, -10f);

        CameraRestraintsX(targetPos);
        CameraRestraintsY(targetPos);
    }

    private void CameraRestraintsX(Vector3 pos)
    {
        if (pos.x >= cameraMaxRight || pos.x <= cameraMaxLeft)
        {
        }
        else
        {
            transform.position = new Vector3(pos.x, transform.position.y, transform.position.z);
        }
    }

    private void CameraRestraintsY(Vector3 pos)
    {
        if (pos.y >= cameraMaxTop || pos.y <= cameraMaxBottom)
        {
        }
        else
        {
            transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);
        }
    }
}