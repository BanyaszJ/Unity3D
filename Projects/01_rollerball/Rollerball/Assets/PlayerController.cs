using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10;
    private Rigidbody rb;
    //    private 

    public float moveHorizontal;
    public float moveVertical;
    public float jumpHeight;
    public bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        jumpHeight = 0f;

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumpHeight = 100f;
            }
        }

        Vector3 Movement = new Vector3(moveHorizontal, jumpHeight, moveVertical);
        rb.AddForce(Movement * Speed);


    }
    private void OnGUI()
    {
        string message = jumpHeight.ToString();
        GUI.Label(new Rect(Screen.width / 5, Screen.height / 5, 200f, 200f), message);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
