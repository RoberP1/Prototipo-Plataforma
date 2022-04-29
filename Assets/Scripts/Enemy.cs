using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [Range(0,10f)]
    [SerializeField] private float distanceMove;
    private Vector3 maxleft;
    private Vector3 maxright;
    private Vector3 dest;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxleft = new Vector3(transform.position.x - distanceMove, transform.position.y, 0);
        maxright = new Vector3(transform.position.x + distanceMove, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.MovePosition
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
