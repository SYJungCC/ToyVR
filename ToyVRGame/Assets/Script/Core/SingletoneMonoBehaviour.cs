using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyShootingVr.Core
{
    public class SingletoneMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T _instance;

        public static T Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = (T)FindObjectOfType(typeof(T));
                    if (null == _instance)
                    {
                        GameObject obj = new GameObject(typeof(T).ToString());
                        _instance = obj.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }

        private void OnApplicationQuit()
        {
            _instance = null;
        }

    }
}