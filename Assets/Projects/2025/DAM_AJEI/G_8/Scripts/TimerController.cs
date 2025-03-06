using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Ocho
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private float timeCounter;
        [SerializeField] private int minutes;
        [SerializeField] private int seconds;
        public TextMeshProUGUI timerText;
        
        void Update()
        {
            timeCounter += Time.deltaTime;
            minutes = Mathf.FloorToInt(timeCounter / 60);
            seconds = Mathf.FloorToInt(timeCounter - minutes * 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
