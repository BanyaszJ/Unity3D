using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ------------Variables--------------

    private Rigidbody rb;

    public float Speed = 4.0f;
    public float moveHorizontal;
    public float moveVertical;
    public float jumpHeight = 2.0f;

    public bool isGrounded;

    //------------------------------------

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (isGrounded)
        {
            if (Input.GetButton("Jump"))
            {

                rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);

            }
        }
        else if (!isGrounded)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += new Vector3(0, 1 * Physics.gravity.y * 5.0f * Time.deltaTime, 0);
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {

                rb.velocity += new Vector3(0, 1 * Physics.gravity.y * 5.0f * Time.deltaTime, 0);

            }
        }

        Vector3 Movement = new Vector3(moveHorizontal * Speed, 0.0f, moveVertical * Speed);
        rb.AddForce(Movement * Speed);

    }
    private void OnGUI()
    {
        //string message = jumpHeight.ToString();
        string velocity = rb.velocity.ToString();
        //GUI.Label(new Rect(Screen.width / 5, Screen.height / 5, 200f, 200f), message);
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 5, 200f, 200f), velocity);
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
