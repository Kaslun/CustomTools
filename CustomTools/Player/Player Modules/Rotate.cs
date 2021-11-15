using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Rotate : MonoBehaviour
    {
        public Transform followTransform;
        [Range(0,.1f)]
        public float camSensitivity;

        private PlayerInputActions playerActions;
        private InputAction mouseMovement;

        private void Awake()
        {
            playerActions = new PlayerInputActions();
        }

        void Update()
        {
            //Rotate the Follow Target transform based on the player input
            followTransform.rotation *= Quaternion.AngleAxis(mouseMovement.ReadValue<Vector2>().x * camSensitivity, Vector3.up);

            followTransform.rotation *= Quaternion.AngleAxis(mouseMovement.ReadValue<Vector2>().y * camSensitivity, Vector3.right);

            var angles = followTransform.localEulerAngles;
            angles.z = 0;

            var angle = followTransform.localEulerAngles.x;

            //Clamping rotation
            if (angle > 180 && angle < 340)
            {
                angles.x = 340;
            }
            else if (angle < 180 && angle > 40)
            {
                angles.x = 40;
            }

            followTransform.localEulerAngles = angles;

            transform.rotation = Quaternion.Euler(0, followTransform.rotation.eulerAngles.y, 0);

            followTransform.localEulerAngles = new Vector3(angles.x, 0, 0);
        }

        private void OnEnable()
        {
            mouseMovement = playerActions.Player.Look;
            mouseMovement.Enable();
        }
    }
}
