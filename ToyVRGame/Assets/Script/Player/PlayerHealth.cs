using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour
{
    [SyncVar(hook = "OnHealthChanged")] public int health;
    private ToyPlayerController player;
    private int maxHealth = 13;

    // Use this for initialization
    void Start () {
        if(isLocalPlayer)
        {
            player = GetComponent<ToyPlayerController>();
            health = maxHealth;
        }
    }

    void OnHealthChanged(int value)
    {
        health = value;
    }

    [ServerCallback]
    void OnEnable()
    {
        health = maxHealth;
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
    void RpcTakeDamage(bool died)
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

    private IEnumerator DamageEffect()
    {
        yield return new WaitForFixedUpdate();

    }
}
