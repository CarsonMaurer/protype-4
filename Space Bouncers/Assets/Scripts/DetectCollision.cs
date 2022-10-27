using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{public GameObject PlayerFX;
public GameObject EnemyFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(PlayerFX, other.transform.position, PlayerFX.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
