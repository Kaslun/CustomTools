using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomTools;
using Manager;
using TMPro;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private CheckpointManager checkpointManager;
        public InventoryObject inventory;

        void Start()
        {
            EventManager.StartListening("Loaded", Loaded);
        }

        private void Loaded()
        {
            checkpointManager = FindObjectOfType<CheckpointManager>();
        }

        void Update()
        {
#if UNITY_EDITOR
            //Debug Tools for testing features in PlayerController

            /*if (Input.GetButtonDown("Respawn"))
            {
                Respawn();
            }

            if (Input.GetButtonDown("Save"))
            {
                inventory.Save();
            }

            if (Input.GetButtonDown("Load"))
            {
                inventory.Load();
            }*/
#endif
        }

        public void Respawn()
        {
            gameObject.SetActive(false);
            transform.position = checkpointManager.activeCheckpoint.position;
            gameObject.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "PressurePad":
                    other.TryGetComponent(out Button interactScript);
                    interactScript.DoInteract();
                    break;

                //If other is Checkpoint, Update current checkpoint.
                case "Checkpoint":
                    checkpointManager.UpdateCheckpoint(other.transform);
                    print("hitting checkpoint");
                    break;

                //if other is an Item, add item to inventory object and destroy.
                case "Item":
                    Item item = other.GetComponent<Item>();
                    if (item)
                    {
                        inventory.AddItem(item.item, 1);
                        Destroy(other.gameObject);
                    }
                    break;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            switch (other.tag)
            {
                case "PressurePad":
                    other.TryGetComponent(out Button interactScript);
                    StartCoroutine(interactScript.Deactivate());
                    break;
            }
        }

        private void OnApplicationQuit()
        {
            inventory.Container.Clear();
        }
    }
}
