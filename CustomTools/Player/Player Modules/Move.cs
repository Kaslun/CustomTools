using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Move : MonoBehaviour
    {
        [SerializeField, Header("Speed Settings")]
        private float baseSpeed;
        public float gravity = 9.81f;
        public float speedMultiplier;

        [SerializeField, Header("Jump Settings")]
        private float jumpForce;
        private float verticalDir;

        private PlayerInputActions playerActions;
        private InputAction movement, run, jump;

        private CharacterController player;
        private Vector3 moveDir;

        private void Awake()
        {
            playerActions = new PlayerInputActions();
        }

        private void Start()
        {
            player = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            moveDir = (transform.forward * movement.ReadValue<Vector2>().y + transform.right * movement.ReadValue<Vector2>().x);

            if (player.isGrounded)
            {
                if (jump.triggered)
                {
                    Debug.Log("jumping");
                    verticalDir = jumpForce;
                }

                if (run.phase == InputActionPhase.Performed)
                {
                    Debug.Log("Running");
                    moveDir *= speedMultiplier;
                }
            }

            verticalDir -= gravity * Time.deltaTime;
            moveDir *= baseSpeed;
            moveDir.y = verticalDir;
            player.Move(moveDir * Time.deltaTime);
        }

        private void OnEnable()
        {
            movement = playerActions.Player.Move;
            movement.Enable();

            jump = playerActions.Player.Jump;
            jump.Enable();

            run = playerActions.Player.Run;
            run.Enable();
        }

        private void OnDisable()
        {
            movement.Disable();
            jump.Disable();
            run.Disable();
        }
    }
}
