using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.DefenseBasic
{
    public class GameManager : MonoBehaviour, IComponentChecking
    {
        public float spawnTime;
        public Enemy[] enemyPrabs;
        public GUIManager guiMng;
        private bool m_isGameover;
        private int m_score;

        public int Score
        {
            get => m_score;
            set => m_score = value;
        }

        void Start()
        {
            if (IsComponentsNull())
            {
                return;
            }
            guiMng.ShowGameGUI(false);
            guiMng.UpdateMainCoins();
        }

        public void PlayGame()
        {
            StartCoroutine(SpawnEnemy());
            guiMng.ShowGameGUI(true);
            guiMng.UpdateMainCoins();
        }
        public bool IsComponentsNull()
        {
            return guiMng == null;
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
