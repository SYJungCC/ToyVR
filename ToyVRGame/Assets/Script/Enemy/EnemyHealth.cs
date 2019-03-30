using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ToyShootingVr.Enemy
{
    public class EnemyHealth : NetworkBehaviour
    {
        [SyncVar(hook = "OnHealthChanged")]
        public int health;

        private void Damage(string name, int power)
        {

        }

        private void OnHealthChanged(int value)
        {
            health = value;
        }

        ////NetworkInstanceId
        [Command]
        public void CmdDamage(string name, int power)
        {
            Damage(name, power);
            RpcDamage(name, power);
        }

        [ClientRpc]
        public void RpcDamage(string name, int power)
        {
            // if (!isServer)
            {
                Debug.Log("Rpc Player give Damage :" + name);
                Damage(name, power);
            }
        }
    }
}