using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ToyShootingVr.Core
{
    public class EnemyManager : SingletoneMonoBehaviour<EnemyManager>
    {
        [Header("SpawnPoint")]
        [SerializeField] private List<GameObject> spawnPointList = new List<GameObject>();
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