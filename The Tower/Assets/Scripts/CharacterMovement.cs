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
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the user presses the space key and the player is on the ground, the player jumps
        if (onGround == true){
            spriteRenderer.sprite = idleSprite;
            canJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true){
            spriteRenderer.sprite = jumpSprite;
            canJump = false;
            rb.velocity = Vector2.up * jumpHeight;
            audioSource.Play();
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
            print(onGround);
            spriteRenderer.sprite = idleSprite;
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
            spriteRenderer.sprite = jumpSprite;
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "nextLevel")
		{
            collision.gameObject.GetComponent<changeScenes>().changeScene("secondLevel");
		}

        //If we collide with an object tagged "obstacle" then the character will be hurt
        if (collision.gameObject.tag == "obstacle")
        {
            spriteRenderer.sprite = hurtSprite;
            print("Hazel is hurt!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

    