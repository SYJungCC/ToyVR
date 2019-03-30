using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ToyShootingVr.Player
{
    public class PlayerHealth : NetworkBehaviour
    {
        [SyncVar(hook = "OnHealthChanged")]
        public int health;
        private PlayerController player; //character 
        private const int MAX_HEALTH = 13;

        // Use this for initialization
        void Start()
        {
            if (isLocalPlayer)
            {
                player = GetComponent<PlayerController>();
                health = MAX_HEALTH;   // have to call one more time for UI. 
            }
        }

        [ServerCallback]
        private void OnEnable()
        {
            health = MAX_HEALTH;
        }


        private void OnHealthChanged(int value)
        {
            health = value;
            if (isLocalPlayer)
            {
                player.gameUI.SetHealth(value, MAX_HEALTH);
            }
        }

 
        [Server]
        public bool TakeDamage()
        {
            bool died = false;

            health--;
            if (health <= 0)
            {
                health = 0;
                died = true;
            }

            RpcTakeDamage(died);

            return died;
        }

        [ClientRpc]
        public void RpcTakeDamage(bool died)
        {
            if (isLocalPlayer)
            {
                StartCoroutine(DamageEffect());
            }

            if (died)
            {
                player.Die();
            }
        }
   
        private  IEnumerator DamageEffect()
        {
            yield return new WaitForFixedUpdate();

        }
    }
}