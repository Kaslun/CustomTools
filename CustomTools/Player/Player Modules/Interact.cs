using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using CustomTools;

namespace Player
{
    public class Interact : MonoBehaviour
    {
        public float reach;
        private PlayerInputActions playerActions;

        private void Awake()
        {
            playerActions = new PlayerInputActions();
        }

        private void DoInteract(InputAction.CallbackContext obj)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, reach);

            print("interacting...");
            if(hits.Length > 0)
            {
                print("found interactable");
                foreach(Collider col in hits)
                {
                    if (col.transform.TryGetComponent(out InteractBase intBase))
                    {
                        print("interacting with " + col.transform.name);
                        intBase.DoInteract();
                        return;
                    }
                }
            }
        }

        private void OnEnable()
        {
            playerActions.Player.Interact.performed += DoInteract;
            playerActions.Player.Interact.Enable();
        }

    }
}
