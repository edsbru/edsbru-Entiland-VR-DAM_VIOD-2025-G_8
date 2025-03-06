using EntilandVR.DosCinco.DAM_AJEI.G_Ocho;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public TextMeshProUGUI winTime;
    public TextMeshProUGUI scoreCurrentValue;
    public TextMeshProUGUI scoreMaxValue;
    public TimerController timerController;

    void Start()
    {
        scoreCurrentValue.text = 0.ToString();
        scoreMaxValue.text = "/ " + ScoreManagerSingleton.Instance.maxScore.ToString();
        winText.gameObject.SetActive(false);
        winTime.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManagerSingleton.Instance.score == ScoreManagerSingleton.Instance.maxScore)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        winText.gameObject.SetActive(true);
        winTime.gameObject.SetActive(true);
        winTime.text = timerController.timerText.text;
    }
}
