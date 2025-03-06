using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EntilandVR.DosCinco.DAM_AJEI.G_Ocho
{
    public class BallSpawner : MonoBehaviour
    {
        public Transform ballSpawnPoint;
        public GameObject ball;
        private void OnTriggerExit(Collider other)
        {
            if(other.tag == "Ball")
            {
                Instantiate(ball,ballSpawnPoint.position, Quaternion.identity);
            }
        }
    }
}