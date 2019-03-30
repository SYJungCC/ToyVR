using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
namespace ToyShootingVr.Items
{
    public class GunController : WeaponController
    {
        [Header("Prefabs")]
        public GameObject ammoPref;
        //   public GameObject shellPref;
        public GameObject ImpactEffect;

        [Header("AmmoStatus")]
        //  [SerializeField] protected Transform muzzle;
        //  [SerializeField] protected Transform ejectionPort; //ejection
        [SerializeField] protected const float gunCooldown = .2f;

        [SerializeField] protected float ammoSpeed = 13f;
        [SyncVar] public int ammoPower = 1;
        [SyncVar] public int ammoCurrentCount = 100;
        protected const int ammoMaxCount = 100;
        protected float coolTime = 0.5f;
        public float CoolTime
        {
            get
            {
                return coolTime;
            }
        }

        [Header("Audio")]
        public AudioClip fireSound;
        public AudioClip reloadSound;
        public AudioClip dryFireSound;

        [ServerCallback]
        public void OnEnable()
        {
            ammoCurrentCount = ammoMaxCount;
        }

    
        [Command]
        void CmdFire()
        {

        }

        [ClientRpc]
        void RpcFire()
        {

        }

        public void Fire()
        {

        }

    }
}