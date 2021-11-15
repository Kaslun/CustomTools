using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;

namespace Manager {
    public class GameManager : MonoBehaviour
    {
        
        public bool debugMode;

        [SerializeField]
        float delay = 1;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

            StartCoroutine(LoadDelay(delay));
        }

        IEnumerator LoadDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            EventManager.TriggerEvent("Loaded");

        }
    }
}
