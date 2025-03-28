using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 3f;
    public float moveSpeed = 2f;
    public GameObject charSprite;

    public CameraMovement cameraMovement;

    private Rigidbody2D rb;

    private float screenLeft;
    private float screenRight;

    private bool leftbuttonInput = false;
    private bool rightbuttonInput = false;
    private SpriteRenderer charSpriteRend;

    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        charSpriteRend = charSprite.GetComponent<SpriteRenderer>();
        screenLeft = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        screenRight = Camera.main.ViewportToWorldPoint(Vector3.right).x;
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        Move();
        WrapAroundScreen();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        if (moveInput < 0.1 && moveInput > -0.1)
        {
            if (leftbuttonInput)
                moveInput = -1;
            else if (rightbuttonInput)
                moveInput = 1;
        }
        if (moveInput < 0)
        {
            charSpriteRend.flipX = true;
        }
        else if (moveInput > 0)
        {
            charSpriteRend.flipX = false;
        }
        transform.position += new Vector3(moveInput * moveSpeed * Time.deltaTime, 0, 0);
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Collider2D platformCollider = collision.GetComponent<Collider2D>();
            if (transform.position.y > collision.transform.position.y)
            {
                if (gameManager.Score < transform.position.y)
                    gameManager.Score = (int)transform.position.y;
                var obj = collision.gameObject.GetComponent<DropAndFade>();
                if (obj != null)
                {
                    obj.StartFalling();
                }
                cameraMovement.MoveVertical(transform.position.y);
                Jump();
            }
        }
    }

    void WrapAroundScreen()
    {
        Vector3 newPosition = transform.position;

        if (newPosition.x < screenLeft)
        {
            newPosition.x = screenRight;
        }
        else if (newPosition.x > screenRight)
        {
            newPosition.x = screenLeft;
        }

        transform.position = newPosition;
    }

    public void LeftButtonInput(bool newInput)
    {
        leftbuttonInput = newInput;
    }

    public void RightButtonInput(bool newInput)
    {
        rightbuttonInput = newInput;
    }
}

