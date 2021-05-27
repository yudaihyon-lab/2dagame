using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

	public float speed;
    // Start is called before the first frame update
	private Animator anim = null;
	private Rigidbody2D rb = null;
    private Vector2 input;
    public float stopf = 1;
    State state;

    public enum State
    {
        Normal,
        Talk,
        Command,
    }

    public void SetState(State state)
    {
        this.state = state;

        if (state == State.Normal)
        {
            stopf = 1;
            anim.enabled = true;
        }
        else if (state == State.Talk)
        {
            stopf = 0;
            anim.enabled = false;
        }
        else if (state == State.Command)
        {
            stopf = 0;
            anim.enabled = false;
        }
    }
    
    public State GetState()
    {
        return state;
    }

 
	void Start()
	{
		anim = GetComponent<Animator>();
		this.rb = GetComponent<Rigidbody2D>();
		this.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
	}
	 
	private void Update()
    {
        if(stopf == 1){
            // 入力を取得
            input = new Vector2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical"));
        }
    }

    private void FixedUpdate()
    {
        if (input == Vector2.zero)
        {
            return;
        }
        if (stopf == 1)
        {
            // 移動量を加算する
            rb.position += input * speed;
        }
    }
}
