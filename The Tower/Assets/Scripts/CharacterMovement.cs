using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    
    public float speed;
    public float jumpHeight;

    private Rigidbody2D rb;
    private Sprite sprite;
    private SpriteRenderer spriteRenderer;

    private bool onGround;
    private bool canJump;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<Sprite>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround == true){
            canJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true){
            canJump = false;
            rb.velocity = Vector2.up * jumpHeight;
        }

        if (Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            spriteRenderer.flipX = true;
            //sprite.Equals("HazelPlaceholder_1");
        }

        else if (Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = new Vector2(+speed, rb.velocity.y);
            spriteRenderer.flipX = false;
        }

        else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (rb.transform.position.y < -10){
            SceneManager.LoadScene("LaurenTestingMovement");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If we collide with an object tagged "ground" then our jump resets and we can now jump.
        if (collision.gameObject.tag == "ground")
        {
            onGround = true;
            print(onGround);
            //print statements print to the Console panel in Unity. 
            //This will print the value of onGround, which is a boolean, so either True or False.
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

    