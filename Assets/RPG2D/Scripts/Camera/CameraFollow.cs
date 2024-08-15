using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetTrans;
    [SerializeField] private float followSpeed;
    [SerializeField] private Vector3 offsetCamera;

    private void FixedUpdate()
    {
        Vector3 targetPos = targetTrans.position + offsetCamera;
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.fixedDeltaTime);

        smoothPos.z = -10;
        transform.position = smoothPos;
    }
}