using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

namespace ToyShootingVr.Core
{
    [RequireComponent(typeof(Animator), typeof(NetworkAnimator))]
    [RequireComponent(typeof(NetworkTransform), typeof(AudioSource))]
    public class Character : NetworkBehaviour
    {
        [Header("Animator")]
        private NetworkAnimator animNetwork;

        [Header("Nav Mesh Agent")]
        private NavMeshAgent navMeshAgent;

        [Header("Sounds")]
        private List<AudioSource> audioList;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}