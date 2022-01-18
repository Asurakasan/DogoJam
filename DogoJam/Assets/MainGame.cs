using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    [SerializeField]
    private List<WaveManager> wavemanager;
    private WaveManager currentwave;



    // private bool isup;

    public float countdown = 2f;

    private int waveNumber = 1;

    public static MainGame instance;

    public List<Collider2D>TriggerRuelle;
    public List<Collider2D> TriggerArene;
    public bool isEnter;
    public GameObject ArenaWall;

    

    private void Awake()
    {
        instance = this;
    }

    IEnumerator WaveSpawn()
    {
        for (int h = 0; h < wavemanager.Count; )
        {
            currentwave = wavemanager[h];
            countdown = currentwave.CoolDownBeforeSpawn;
            yield return new WaitForSeconds(currentwave.CoolDownBeforeSpawn);
            for (int j = 0; j < currentwave.EnemyCount; j++)
            {

                SpawnEnemy(currentwave.Enemy,currentwave.spawnPoint);
                yield return new WaitForSeconds(0.5f);
            }

            currentwave.EnemyCount++;
            h++;
                
            
            
        }
        

    }

    private void Start()
    {
        
    }

    void Update()
    {
        if(isEnter == true)
        {
            StartCoroutine(WaveSpawn());
            isEnter = false;
        }
        
        if(countdown >= 0 )
        {
            countdown -= Time.deltaTime;

        }

    }



    void SpawnEnemy(GameObject enemyPrefab, Transform SpawnPoint)
    {

        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
