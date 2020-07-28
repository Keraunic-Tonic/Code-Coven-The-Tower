using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    
    public float speed;
    public float jumpHeight;
    public Sprite idleSprite;
    public Sprite jumpSprite;
    public Sprite hurtSprite;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private bool onGround;
    private bool canJump;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the player is on the ground. If the player is on the ground, they can jump.
        if (onGround == true){
            canJump = true;
        }
        
        //If the user presses the space key and the player is on the ground, the player jumps
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true){
            spriteRenderer.sprite = jumpSprite;
            rb.velocity = Vector2.up * jumpHeight;
        }
        else {
            canJump = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            spriteRenderer.flipX = true;
        }

        else if (Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = new Vector2(+speed, rb.velocity.y);
            spriteRenderer.flipX = false;
        }

        else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //If the character falls off the screen, the sprite will reload on the current scene
        if (rb.transform.position.y < -10){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If we collide with an object tagged "ground" then our jump resets and we can now jump.
        if (collision.gameObject.tag == "ground")
        {
            onGround = true;
            spriteRenderer.sprite = idleSprite;
            //This will print the value of onGround, which is a boolean, so either True or False.
            print(onGround);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //If we exit our collision with the "ground" object, then we are unable to jump.
        if (collision.gameObject.tag == "ground")
        {
            onGround = false;
            print(onGround);
        }
    }
}

    