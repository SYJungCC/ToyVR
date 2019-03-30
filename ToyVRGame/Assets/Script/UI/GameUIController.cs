using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ToyShootingVr.UI
{
    public class GameUIController : MonoBehaviour
    {
        [Header("local")]
        public Text hp;
        public Text kill;
        public Text score;
        
        [Header("Share")]
        public Text userName;
        public Image hpBar;
        [SerializeField]
        private Image hpBarBackground;


        public void LocalShow(bool isActive)
        {
            hp.gameObject.SetActive(isActive);
            kill.gameObject.SetActive(isActive);
            score.gameObject.SetActive(isActive);
        }

        public void SetHealth(float value, int maxHealth)
        {
            hp.text = "HP :" + value;
            hpBar.rectTransform.sizeDelta = new Vector2(value * (hpBarBackground.rectTransform.sizeDelta.x / maxHealth), hpBarBackground.rectTransform.sizeDelta.y);
        }

    }
}