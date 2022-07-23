using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class CameraFollow2D : MonoBehaviour
{
    [SerializeField]
    private GameObject targetToFollow;

    [SerializeField]
    private bool follow = true;

    [SerializeField]
    private float cameraZOffset = -10f;
    [SerializeField]
    private float cameraXOffset = -5f;

    private void Start()
    {
        if (targetToFollow != null) return;
        Debug.Log("No target set - Camera follow disabled");
        follow = false;
    }

    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        if (follow)
        {
            transform.position = new Vector3(targetToFollow.transform.position.x + cameraXOffset, 0, cameraZOffset);
        }
    }
}
