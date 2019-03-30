using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ToyShootingVr.Player
{
    public class VRSync : NetworkBehaviour
    {
        const float lerpRate = 10.0f;
        const float posThreshold = 0.1f;
        const float rotThreshold = 5.0f;

        public Transform head;
        [SerializeField] Transform leftHand;
        [SerializeField] Transform rightHand;

        [SerializeField] Transform headTarget;
        [SerializeField] Transform leftHandTarget;
        [SerializeField] Transform rightHandTarget;

        [SyncVar] Vector3 syncHeadPos;
        [SyncVar] Vector3 syncLeftHandPos;
        [SyncVar] Vector3 syncRightHandPos;

        [SyncVar] Quaternion syncHeadRot;
        [SyncVar] Quaternion syncLeftHandRot;
        [SyncVar] Quaternion syncRightHandRot;


        Vector3 lastHeadPos;
        Vector3 lastLeftHandPos;
        Vector3 lastRightHandPos;

        Quaternion lastHeadRot;
        Quaternion lastLeftHandRot;
        Quaternion lastRightHandRot;


        GameObject cameraRig;

        void Start()
        {
        }
        // Update is called once per frame
        void Update()
        {

            if (isLocalPlayer)
            {
                TrackingCamera();
                TransmitMotion();
            }
            else
            {
                LerpMotion();
            }

        }

        private void TrackingCamera()
        {
            headTarget.position = head.position;
            headTarget.rotation = head.rotation;

            leftHandTarget.position = leftHand.position;
            leftHandTarget.rotation = leftHand.rotation;

            rightHandTarget.position = rightHand.position;
            rightHandTarget.rotation = rightHand.rotation;
        }

        private void TransmitMotion()
        {
            //head
            if (Vector3.Distance(headTarget.position, lastHeadPos) > posThreshold)
            {
                CmdProviderHeadPosToServer(headTarget.position);
                lastHeadPos = headTarget.position;
            }
            if (Quaternion.Angle(headTarget.rotation, lastHeadRot) > rotThreshold)
            {
                CmdProvideHeadRotToServer(headTarget.rotation);
                lastHeadRot = headTarget.rotation;
            }

            //leftHand
            if (Vector3.Distance(leftHandTarget.position, lastLeftHandPos) > posThreshold)
            {
                CmdProviderLeftHandPosToServer(leftHandTarget.position);
                lastLeftHandPos = leftHandTarget.position;
            }
            if (Quaternion.Angle(leftHandTarget.rotation, lastLeftHandRot) > rotThreshold)
            {
                CmdProvideLeftHandRotToServer(leftHandTarget.rotation);
                lastLeftHandRot = leftHandTarget.rotation;
            }

            //right hand
            if (Vector3.Distance(rightHandTarget.position, lastRightHandPos) > posThreshold)
            {
                CmdProviderRightHandPosToServer(rightHandTarget.position);
                lastRightHandPos = rightHandTarget.position;
            }
            if (Quaternion.Angle(rightHandTarget.rotation, lastRightHandRot) > rotThreshold)
            {
                CmdProvideRightHandRotToServer(rightHandTarget.rotation);
                lastRightHandRot = rightHandTarget.rotation;
            }

        }

        private void LerpMotion()
        {
            float t = Time.deltaTime * lerpRate;

            //head
            headTarget.position = Vector3.Lerp(headTarget.position, syncHeadPos, t);
            headTarget.rotation = Quaternion.Lerp(headTarget.rotation, syncHeadRot, t);

            //left
            leftHandTarget.position = Vector3.Lerp(leftHandTarget.position, syncLeftHandPos, t);
            leftHandTarget.rotation = Quaternion.Lerp(leftHandTarget.rotation, syncLeftHandRot, t);

            //right
            rightHandTarget.position = Vector3.Lerp(rightHandTarget.position, syncRightHandPos, t);
            rightHandTarget.rotation = Quaternion.Lerp(rightHandTarget.rotation, syncRightHandRot, t);
        }

        [Command]
        private void CmdProviderHeadPosToServer(Vector3 pos)
        {
            syncHeadPos = pos;
        }
        [Command]
        private void CmdProvideHeadRotToServer(Quaternion rot)
        {
            syncHeadRot = rot;
        }

        [Command]
        private void CmdProviderLeftHandPosToServer(Vector3 pos)
        {
            syncLeftHandPos = pos;
        }
        [Command]
        private void CmdProvideLeftHandRotToServer(Quaternion rot)
        {
            syncLeftHandRot = rot;
        }

        [Command]
        private void CmdProviderRightHandPosToServer(Vector3 pos)
        {
            syncRightHandPos = pos;
        }
        [Command]
        private void CmdProvideRightHandRotToServer(Quaternion rot)
        {
            syncRightHandRot = rot;
        }
    }
}