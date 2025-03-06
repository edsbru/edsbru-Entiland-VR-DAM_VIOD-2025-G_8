using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EntilandVR.DosCinco.DAM_AJEI.G_Ocho
{
    public class TargetSpawner : MonoBehaviour
    {
        public GameObject objectToSpawn; // Reference to the prefab
        public float spawnInterval = 2f; // Time interval between spawns (in seconds)
        public Transform spawnAreaMin; // Minimum bounds of the spawn area
        public Transform spawnAreaMax;  // Maximum bounds of the spawn area
        public int targetsToSpawn = 10;  // Number of objects to spawn every interval


        private void Start()
        {
            // Start the repeated spawning at a specified interval
            StartCoroutine(SpawnObjectsCoroutine());
        }

        private IEnumerator SpawnObjectsCoroutine()
        {
            while(true){
                for (int i = 0; i < targetsToSpawn; i++)
                {
                    // Generate random position within the specified bounds
                    float randomX = Random.Range(spawnAreaMin.position.x, spawnAreaMax.position.x);
                    float randomY = Random.Range(spawnAreaMin.position.y, spawnAreaMax.position.y);
                    float randomZ = Random.Range(spawnAreaMin.position.z, spawnAreaMax.position.z);
                    Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

                    // Instantiate the object at the random position
                    if (objectToSpawn != null)
                    {
                        GameObject spawnedObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
                        Destroy(spawnedObject, spawnInterval);
                    }
                }
                yield return new WaitForSecondsRealtime(spawnInterval);
            }

        }

    }
}