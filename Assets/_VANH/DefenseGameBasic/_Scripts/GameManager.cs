using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.DefenseBasic
{
    public class GameManager : MonoBehaviour
    {
        public float spawnTime;
        public Enemy[] enemyPrabs;
        private bool m_isGameover;
        void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator SpawnEnemy()
        {
            while (!m_isGameover){
                
                if (enemyPrabs != null && enemyPrabs.Length > 0)
                {
                    int randIdx = Random.Range(0, enemyPrabs.Length);
                    Enemy enemyPrefab = enemyPrabs[randIdx];
                    if (enemyPrabs != null)
                    {
                        Instantiate(enemyPrefab, new Vector3(8, 0, 0), Quaternion.identity);
                    }
                }
                yield return new WaitForSeconds(spawnTime);
            }
        }
    }
}
