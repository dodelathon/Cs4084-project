
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5.0f;
    public Vector3 offset;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(target.position, desiredPos, smoothSpeed);

        transform.position = smoothPos;

        transform.LookAt(target);

	}
}
