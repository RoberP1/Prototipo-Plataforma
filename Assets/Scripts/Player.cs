using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    private bool graunded;

    //input
    private float inputHorizontal;


    void Start()
    {
        graunded = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        rb.AddRelativeForce(Vector2.right * inputHorizontal * speed * Time.deltaTime);

        if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Vertical")) && graunded)
        {
            rb.AddRelativeForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
