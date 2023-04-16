using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerCamera : MonoBehaviour
    {
        public float sensX;
        public float sensY;
        public Transform orientation;
        public Transform gun;

        private float xRotation;
        private float yRotation;
        
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -45f, 45f);
            
            transform.rotation = Quaternion.Euler(xRotation,yRotation,0);
            gun.rotation = transform.rotation;
            orientation.rotation = Quaternion.Euler(0,yRotation,0);
        }
        
        
         
         
    }
}