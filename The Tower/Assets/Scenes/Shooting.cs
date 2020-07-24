using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

	public Rigidbody2D laser;
	public GameObject soundManager;
	public bool isVertical;
	public float firingRate;
	void Start()
	{

	}
	// Update is called once per frame
	void Update()
	{
		if (isVertical)
		{
			Invoke("VerticalFiring", firingRate);
		}
		else
		{
			Invoke("HorizontalFiring", firingRate);
		}
	}

	void VerticalFiring()
	{
		Instantiate(laser, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
	}
	void HorizontalFiring()
	{
		Instantiate(laser, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
	}
}




