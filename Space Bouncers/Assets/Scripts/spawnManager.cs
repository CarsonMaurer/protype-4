using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public float Xrange = 5.5f;
    public GameObject EnemyPrefab;
    public float YRange = 2.5f;
    public int EnemyCount;
    public int WaveCount = 1;
    // Start is called before the first frame update
    void Start()
    {
       SpawnEnemyWave(WaveCount);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCount = FindObjectsOfType<Enemy>().Length;

        if(EnemyCount == 0)
        {
            WaveCount++;
            SpawnEnemyWave(WaveCount);
        }
        
    }
    private Vector2 GenerateSpawnPostion()
    {
        float spawnPosX = Random.Range(-Xrange, Xrange);
        float spawnPosY = Random.Range(-YRange, YRange);
        Vector2 randomPos = new Vector2(spawnPosX, spawnPosY);
        return randomPos;
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(EnemyPrefab, GenerateSpawnPostion(), EnemyPrefab.transform.rotation);
        }
        
    }
}
