using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform followTransform;
    public Vector3 offset;
    
    void LateUpdate()
    {
        transform.position = followTransform.position + offset;
    }
}
