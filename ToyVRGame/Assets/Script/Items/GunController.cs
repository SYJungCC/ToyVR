using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GunController : NetworkBehaviour
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
    protected float ammoCoolTime = 0.5f;

    [Header("Audio")]
    public AudioClip fireSound;
    public AudioClip reloadSound;
    public AudioClip dryFireSound;


    [ServerCallback]
    public void OnEnable()
    {
        ammoCurrentCount = ammoMaxCount;
    }

    // Use this for initialization
    void Start () {
		
	}

    [Command]
    void CmdFire()
    {

    }

    [ClientRpc]
    void RpcFire()
    {

    }

    void Fire()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
