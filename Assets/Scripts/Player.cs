using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    

    //jump
    [SerializeField] private int maxjump;
    private int jump;

    //input
    private float inputHorizontal;

    //shot
    [SerializeField] private GameObject shotPref;
    [SerializeField] private float fireImpulse;
    [SerializeField] private float fireRate;
    [SerializeField] private Transform fireTransform;
    public bool canShot;
    private int rotationFire;


    void Start()
    {
        rotationFire = -1;
        rb = GetComponent<Rigidbody2D>();
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
        if (collision.collider.CompareTag("Enemy"))
        {
            //perder
            Debug.Log("Perdiste");
        }
    }
    public IEnumerator FireCD(float fireRate)
    {
        canShot = false;
        yield return new WaitForSeconds(1.0f/fireRate);
        canShot = true;
    }

}
