using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private Vector3 offset = new Vector3(0f, 2f, 0f);
    
    [SerializeField] private bool offsetInTargetSpace = false; 

    private Quaternion _fixedRotation;

    private void Awake()
    {
        _fixedRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        if (!followTarget) return;

        Vector3 worldOffset = offsetInTargetSpace
            ? followTarget.TransformVector(offset)
            : offset;

        transform.position = followTarget.position + worldOffset;
        
        transform.rotation = _fixedRotation;
    }
}