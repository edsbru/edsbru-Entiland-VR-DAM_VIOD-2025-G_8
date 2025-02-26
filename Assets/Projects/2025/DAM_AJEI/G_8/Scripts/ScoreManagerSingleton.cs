using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EntilandVR.DosCinco.DAM_AJEI.G_Ocho { 
    public class ScoreManagerSingleton : MonoBehaviour
    {
        // Declaramos instacia del Singleton T = ScoreManager
        public int score = 0;
    
        public static ScoreManagerSingleton Instance { get; private set; } // Otras clases pueden obterner una referencia pero no modificarla
    
        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else 
            {
                Destroy(gameObject);        
            }
        }
    
        public void AddScore(int _scoreAmount)
        {
            score += _scoreAmount;
        }
    
    }
}
