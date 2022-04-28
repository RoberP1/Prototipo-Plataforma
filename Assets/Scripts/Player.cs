using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    [SerializeField] private int maxjump;
    private int jump;

    //input
    private float inputHorizontal;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        rb.AddRelativeForce(Vector2.right * inputHorizontal * speed * Time.deltaTime);

        if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Vertical")) && jump < maxjump)
        {
            rb.AddRelativeForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Graund"))
        {
            jump = 0;
        }
    }

}
