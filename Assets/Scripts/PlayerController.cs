using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    [SerializeField] private float JumpForce = 500;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    // Moves the player
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    // Sets count for Pickup items. Adds Win Text when max objects have been picked up. 
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 15)
        {
            winTextObject.SetActive(true);
        }
    }

    // Moves player and sets speed
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
        Restart();
    }

    // Increments count when Pickup is touched.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }

    }

    // Sets boolean to true if ball is touching the ground
    private void OnCollisionStay(Collision collision)
    {
        string nameOfCollisonObject = collision.gameObject.name;
        if(nameOfCollisonObject == "Ground")
        {
            isOnGround = true;
        }
    }

    // Sets boolean to false if ball isn't touching the ground
    private void OnCollisionExit(Collision collision)
    {
        string nameOfCollisonObject = collision.gameObject.name;
        if (nameOfCollisonObject == "Ground")
        {
            isOnGround = false;
        }

    }

    // Makes ball jump up when space is pressed
    void OnJump()
    {
        if(isOnGround)
        {
            rb.AddForce(new Vector3(0, JumpForce, 0));
        }
    }

    // Resets world if ball falls off of ground
    void Restart()
    {
        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("MiniGame");
        }
    }
    
    // Resets world if key r is pressed
    void OnLose()
    {
        SceneManager.LoadScene("MiniGame");
    }
}
