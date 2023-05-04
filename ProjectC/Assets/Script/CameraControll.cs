using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectC
{
    public class CameraControll : MonoBehaviour
    {
        [SerializeField]
        float offsetX = 5;
        [SerializeField]
        float offsetY = 6;
        [SerializeField]
        float offsetZ = 6;

        public float zoomSpeed;

        public GameObject player;

        private Camera mainCamera;

        private void Start()
        {
            mainCamera = GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(player.transform.position.x - offsetX, player.transform.position.y + offsetY, player.transform.position.z - offsetZ);
            ZoomInOut();
        }

        void ZoomInOut()
        {
            float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;

            if(distance != 0)
            {
                mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, 8, 53);
                mainCamera.fieldOfView += distance;
            }
        }
    }
}

