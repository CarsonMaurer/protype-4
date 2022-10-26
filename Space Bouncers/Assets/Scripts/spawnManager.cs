using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public float Xrange = 5.5f;
    public GameObject EnemyPrefab;
    public float YRange = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        float spawnPosX = Random.Range(-Xrange, Xrange);
        float spawnPosY = Random.Range(-YRange, YRange);
        Instantiate(EnemyPrefab, new Vector2(spawnPosX, spawnPosY), EnemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
