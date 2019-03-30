using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ToyShootingVr.UI
{
    public class LogUIController : MonoBehaviour
    {
        public GameObject LogUI;
        public Text entire;
        public Text rightSide;
        public Text leftSide;

        public void Show(bool isActive)
        {
            if (!LogUI.activeSelf) LogUI.SetActive(true);
            entire.gameObject.SetActive(isActive);
        }

        public void ShowLeftSide(bool isActive)
        {
            if (!LogUI.activeSelf) LogUI.SetActive(true);
            leftSide.gameObject.SetActive(isActive);
            entire.gameObject.SetActive(false);
        }

        public void ShowRightSide(bool isActive)
        {
            if (!LogUI.activeSelf) LogUI.SetActive(true);
            rightSide.gameObject.SetActive(isActive);
            entire.gameObject.SetActive(false);
        }

        public void WriteRightSide(string str)
        {
            rightSide.text = str;
        }

        public void WriteLeftSide(string str)
        {
            leftSide.text = str;
        }

        public void Write(string str)
        {
            entire.text = str;
        }
    }
}

