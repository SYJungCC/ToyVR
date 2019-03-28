using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

[System.Serializable]
public class ToggleEvent : UnityEvent<bool> { }

public class ToyPlayerController : NetworkBehaviour
{
    [SerializeField] GameObject mainCamera;

    [SerializeField] ToggleEvent onToggleShared;
    [SerializeField] ToggleEvent onToggleLocal;
    [SerializeField] ToggleEvent onToggleRemote;

    // Use this for initialization
    void Start()
    {
        EnablePlayer();
    }

    // Update is called once per frame
    void Update()
    {

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
