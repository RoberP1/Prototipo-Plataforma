using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    

    //jump
    public int maxjump;
    private int jump;

    //input
    private float inputHorizontal;

    //shot
    [SerializeField] private GameObject shotPref;
    [SerializeField] private float fireImpulse;
    [SerializeField] private Transform fireTransform;
    public float fireRate;
    private bool canShot;
    private int rotationFire;

    //Vida
    public int Vida;
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;

    private GameManager gamemanager;

    //coins
    public int addcoin;

    void Start()
    {
        canShot = true;
        addcoin = 1;
        rotationFire = -1;
        rb = GetComponent<Rigidbody2D>();
        gamemanager = FindObjectOfType<GameManager>();

        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        inputHorizontal = Input.GetAxis("Horizontal");
        rb.AddRelativeForce(Vector2.right * inputHorizontal * speed * Time.deltaTime);
        if (inputHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rotationFire = 1;
        }
        if (inputHorizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rotationFire = -1;
        }

        if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Vertical")) && jump < maxjump)
        {
            rb.AddRelativeForce(Vector2.up * jumpForce , ForceMode2D.Impulse);
            jump++;
        }

        if (Input.GetButtonDown("Fire1") && canShot)
        {
            StartCoroutine(FireCD(fireRate));
            GameObject temp = Instantiate(shotPref, fireTransform.position, Quaternion.identity);
            temp.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * fireImpulse * rotationFire, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Graund") && Physics2D.Raycast(transform.position - new Vector3(0, 1.5f, 0), Vector2.down, 0.1f) != null)
        {
            jump = 0;
        }
        if (collision.collider.CompareTag("Spike"))
        {
            LossHealth();
            rb.AddRelativeForce(Vector2.up * 30, ForceMode2D.Impulse);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            LossHealth();
        }
        if (collision.CompareTag("Coin"))
        {
            gamemanager.AddCoin(addcoin);
            Destroy(collision.gameObject);
        }
    }

    private void LossHealth()
    {
        Vida--;
        switch (Vida)
        {
            case 2:
                heart3.SetActive(false);
                break;
            case 1:
                heart2.SetActive(false);
                break;
            default:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                gamemanager.Lose();
                break;
        }
    }

    public IEnumerator FireCD(float fireRate)
    {
        canShot = false;
        yield return new WaitForSeconds(1.0f/fireRate);
        canShot = true;
    }


}
