using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFiring : MonoBehaviour
{
	public Rigidbody2D laser;
	AudioSource audioSource;
	public bool isVertical;
	public float firingRate;
	private float firingRateFixed;
	public bool isLeft;
	public bool isBottom;

	void Start()
	{
		firingRateFixed = firingRate;
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		firingRate -= Time.deltaTime;

		if (firingRate <= 0)
		{
			firingRate = firingRateFixed;
			audioSource.Play();
			if (isVertical)
			{
				VerticalFiring();
			}
			else
			{
				HorizontalFiring();
			}

		}
	}

	void VerticalFiring()
	{
		if (isBottom)
		{
			Instantiate(laser, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
		}
		else
		{
			Instantiate(laser, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
		}

	}
	void HorizontalFiring()
	{
		if (isLeft)
		{
			Instantiate(laser, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, -180)));
		}
		else
		{
			Instantiate(laser, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
		}
	}
}
