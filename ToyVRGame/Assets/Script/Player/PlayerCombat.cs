using System.Collections;
using System.Collections.Generic;
using ToyShootingVr.Items;
using UnityEngine;


namespace ToyShootingVr.Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [Header("SteamVR")]
        [SerializeField]private SteamVR_TrackedObject rightHandTrackObj;

        private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
        private SteamVR_Controller.Device rightController
        {
            get
            {
                return SteamVR_Controller.Input((int)rightHandTrackObj.index);
            }
        }

        private float ellapsedTime = 0f;
        private ItemBase onHandItemInfo;
        private GunController gun; 

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //if I don't have anything 
            if (!onHandItemInfo) return; 

            switch(onHandItemInfo.Type)
            {
                case eItemType.Gun:
                    UseGun();
                    break; 
            }

        }

        void UseGun()
        {
            if (rightController.GetPress(triggerButton) || Input.GetKeyDown(KeyCode.K))
            {
                rightController.TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, 1));
                switch(onHandItemInfo.Name)
                {
                    case "M5":
                        gun = onHandItemInfo.gameObject.GetComponent<M5Controller>();
                        break; 
                }

                if (ellapsedTime > gun.CoolTime)    //여기부분 쿨타임이 ...?! 몇초가 될지 확인해봐야함
                {
                    ellapsedTime = 0f;
                    if (gun != null)
                        gun.Fire(); //Cmd 인지 아닌지 확인.. 
                }
            }
        }
    }
}
