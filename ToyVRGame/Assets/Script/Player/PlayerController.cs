using System.Collections;
using System.Collections.Generic;
using ToyShootingVr.Core;
using ToyShootingVr.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

[System.Serializable]
public class ToggleEvent : UnityEvent<bool> { }

namespace ToyShootingVr.Player
{
    public class PlayerController : NetworkBehaviour
    {
        [Header("UI")]
        public LogUIController log;
        public GameUIController gameUI;

        [Header("Game")]
        [SerializeField] GameObject mainCamera;

        [SerializeField] ToggleEvent onToggleShared;
        [SerializeField] ToggleEvent onToggleLocal;
        [SerializeField] ToggleEvent onToggleRemote;

        private void Reset()
        {
            log = this.GetComponent<LogUIController>();
            gameUI = this.GetComponent<GameUIController>();
        }

        // Use this for initialization
        void Start()
        {
            EnablePlayer();
            if (isLocalPlayer)
            {
                log.Show(true);
            }
        }
         

        void DisablePlayer()
        {
            onToggleShared.Invoke(false);

            if (isLocalPlayer)
            {
                onToggleLocal.Invoke(false);
            }

            else
                onToggleRemote.Invoke(false);
        }

        void EnablePlayer()
        {
            onToggleShared.Invoke(true);

            if (isLocalPlayer)
            {
                onToggleLocal.Invoke(true);
            }
            else
                onToggleRemote.Invoke(true);
        }

        public void Die()
        {
            if (isLocalPlayer)
            {
                //Show die popup 
                //Death Audio.
            }

            DisablePlayer();
        }
    }

}