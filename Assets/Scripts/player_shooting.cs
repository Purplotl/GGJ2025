using UnityEngine;
using static UnityEngine.GraphicsBuffer;
public class player_shooting : MonoBehaviour
{
    private void Update()
    {
        //add player swivel to mouse pos
    }
    private void FixedUpdate()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(transform.up), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(transform.up) * hit.distance, Color.green);
            Debug.Log("Hit "+hit.rigidbody.gameObject.name);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(transform.up) * 1000, Color.red);
            Debug.Log("Didnt hit");
        }
    }
}
