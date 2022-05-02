using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [Range(0,10f)]
    [SerializeField] private float distanceMove;
    private float maxleft;
    private float maxright;

    private Rigidbody2D rb;

    [SerializeField] private AudioSource audio;

    //shot
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private GameObject shotPref;
    [SerializeField] private float fireImpulse;
    [SerializeField] private float fireRate;
    [SerializeField] private Transform fireTransform;
    public bool canShot;
    private int rotationFire;

    private GameManager gamemanager;

    void Start()
    {
        canShot = true;
        rb = GetComponent<Rigidbody2D>();
        gamemanager = FindObjectOfType<GameManager>();
        maxleft = transform.position.x - distanceMove;
        maxright = transform.position.x + distanceMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= maxleft)
        {
            transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 0);
            rotationFire = -1;
        }
        if (transform.position.x >= maxright)
        {
            transform.rotation = transform.rotation = Quaternion.Euler(0, 180, 0);
            rotationFire = 1;
        }
        rb.AddRelativeForce(transform.right * speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(fireTransform.position, Vector2.left * rotationFire, 9f);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            rb.velocity = new Vector2(0,0);
            if (canShot)
            {
                StartCoroutine(FireCD(fireRate));
                GameObject temp = Instantiate(shotPref, fireTransform.position, Quaternion.identity);
                temp.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * fireImpulse * rotationFire, ForceMode2D.Impulse);
                audio.clip = fireSound;
                audio.Play();
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            gamemanager.EnemyDie();
            Destroy(gameObject);
        }
    }
    public IEnumerator FireCD(float fireRate)
    {
        canShot = false;
        yield return new WaitForSeconds(1.0f / fireRate);
        canShot = true;
    }
}
