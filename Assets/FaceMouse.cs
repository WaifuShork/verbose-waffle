using UnityEngine;

namespace VB
{

    public class FaceMouse : MonoBehaviour
    {
        private new Camera camera;

        private void Awake()
        {
            camera = Camera.main;
        }

        private void Update()
        {   
            FollowMouse();
        }

        private void FollowMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = camera.ScreenToWorldPoint(mousePosition);

            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.up = direction;
        }
    }
}
