using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

	public float speed;
    // Start is called before the first frame update
	private Animator anim = null;
	private Rigidbody2D rb = null;
	 
	void Start()
	{
	   anim = GetComponent<Animator>();
	   rb = GetComponent<Rigidbody2D>();
	}
	 
	void Update()
	{
		float horizontalKey = Input.GetAxis("Horizontal");
		float verticalKey = Input.GetAxis("Vertical");
		float xSpeed = 0.0f; 
		float ySpeed = 0.0f; 

		if (horizontalKey > 0) 
		{
		     transform.localScale = new Vector3(-1, 1, 1);
		     anim.SetBool("walk", true);
		     xSpeed = speed;
		}
		else if (horizontalKey < 0) 
		{
		     transform.localScale = new Vector3(1, 1, 1);
		     anim.SetBool("walk", true);
		     xSpeed = -speed;
		}
		else
		{
		     anim.SetBool("walk", false);
		     xSpeed = 0.0f;
		}

		if (verticalKey > 0) 
		{
		     anim.SetBool("walk", true);
		     ySpeed = speed;
		}
		else if (verticalKey < 0) 
		{
		     anim.SetBool("walk", true);
		     ySpeed = -speed;
		}
		rb.velocity = new Vector2(xSpeed, ySpeed);

	}
}
