using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class PlayerCamera : MonoBehaviour
    {
        public float sensX;
        public float sensY;
        public Transform orientation;
        [SerializeField] private InputActionReference rotating;

        private float xRotation;
        private float yRotation;
        
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            
            float mouseX = rotating.action.ReadValue<Vector2>().x * Time.deltaTime * sensX;
            float mouseY = rotating.action.ReadValue<Vector2>().y * Time.deltaTime * sensY;
            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -45f, 45f);
            
            transform.rotation = Quaternion.Euler(xRotation,yRotation,0);
            orientation.rotation = Quaternion.Euler(0,yRotation,0);
        }
        
        
         
         
    }
}