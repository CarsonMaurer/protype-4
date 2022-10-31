using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float Speed = 10;
    public GameObject PlayerFX;
    
    private Rigidbody2D _playerRb;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 direction = new Vector2(horizontalInput, verticalInput);
        _playerRb.AddForce(direction * Speed);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            Instantiate(PlayerFX, transform.position, PlayerFX.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
