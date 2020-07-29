using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    AudioSource myAudioSource;


	// Start is called before the first frame update
	void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void FixedUpdate()
	{
		rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "worldLimits")
		{
			Destroy(gameObject);
		}
	}
}
