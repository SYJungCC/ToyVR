using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
namespace ToyShootingVr.Core
{
    public class GameNetworkManager : NetworkManager
    {

        private void Start()
        {
            Debug.Log("Start");
        }

        public override void OnServerConnect(NetworkConnection conn)
        {
            Debug.Log("OnServerConnect :" + spawnPrefabs.Count);
        }
        public override void OnServerReady(NetworkConnection conn)
        {
            Debug.Log("OnServerReady :" + spawnPrefabs.Count);
        }

        public override void OnStartServer()
        {
            Debug.Log("OnStartServer :" + spawnPrefabs.Count);
        }

        public override void OnStartClient(NetworkClient client)
        {
            Debug.Log("OnStartClient :" + spawnPrefabs.Count);
        }

        private void Update()
        {
        }

        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {
            base.OnServerAddPlayer(conn, playerControllerId);
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            base.OnClientConnect(conn);
        }

        public override void OnServerRemovePlayer(NetworkConnection conn, PlayerController player)
        {
            Debug.Log("ServerRemovePlayer");
            base.OnServerRemovePlayer(conn, player);
        }

    }
}