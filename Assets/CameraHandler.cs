using UnityEngine;

namespace VB
{
    public class CameraHandler : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);
        private new static Camera camera;
        
        [SerializeField] private float smoothFactor = 3.0f;

        private void Awake()
        {
            camera = camera == null ? gameObject.AddComponent<Camera>() : GetComponent<Camera>();
            target = FindObjectOfType<PlayerMovement>().transform;
        }

        private void FixedUpdate()
        {
           FollowPlayer();
        }

        private void FollowPlayer()
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = smoothPosition;
        }
    }
}
