using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public float Speed = 10;
    public GameObject PlayerFX;
    
    private Rigidbody2D _playerRb;
    public GameObject Powerupindicator;
    public float PowerupStrength = 5;
    public bool HasPowerup = false;
    private SpriteRenderer _playerSR;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerSR = GetComponent<SpriteRenderer>();
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
           StartCoroutine(GameOverRoutine());
        }
        if(other.gameObject.CompareTag("powerUp"))
        {
            Destroy(other.gameObject);
            Powerupindicator.gameObject.SetActive(true);
            HasPowerup = true;
            StartCoroutine(PowerupCountdownRoutine());
        }
    
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy") && HasPowerup)
        {
            Rigidbody2D enemyRb = other.gameObject.GetComponent<Rigidbody2D>();

            Vector2 awayFromPlayer = (other.gameObject.transform.position - transform.position);
            enemyRb.AddForce(awayFromPlayer* PowerupStrength, ForceMode2D.Impulse);

           // Powerupindicator.gameObject.SetActive(false);
           // HasPowerup = false;
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        Powerupindicator.gameObject.SetActive(false);
        HasPowerup = false;
    }
    IEnumerator GameOverRoutine()
    {
        Instantiate(PlayerFX, transform.position, PlayerFX.transform.rotation);
        //Destroy(this.gameObject);
        Powerupindicator.gameObject.SetActive(false);
        HasPowerup = false;
       _playerSR.enabled = false;
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(0);
        
        
    }
}
