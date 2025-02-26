using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace EntilandVR.DosCinco.DAM_AJEI.G_Ocho { 
    public class ScoreTextLogic : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;
        private int _score;
    
        private void UpdateScoreText(int _score)
        {
            scoreText.text = _score.ToString();
        }
    
        void Start()
        {
            scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        }
    
        void Update()
        {
            _score = ScoreManagerSingleton.Instance.score;
            UpdateScoreText(_score);
        }
    
    }
}