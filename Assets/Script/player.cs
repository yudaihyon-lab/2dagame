using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(Flowchart))]
public class player : MonoBehaviour
{
    [SerializeField]GameObject fishing_system;
    Fishing_System fishing;
    private Animator anim = null;
	private Rigidbody2D rb = null;
    private Vector2 input;
	public float speed;
    public float respeed;
    public float stopf = 1;
    State state;

    [SerializeField]
    Flowchart flowChart;
    public enum State
    {
        Normal,
        Talk,
        Command,
    }

	void Start()
	{
		anim = GetComponent<Animator>();
		this.rb = GetComponent<Rigidbody2D>();
		this.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        fishing = fishing_system.GetComponent<Fishing_System>();
	}
	 
	private void Update()
    {
        //アニメーション推移関数
        anim_direction();
    }

    private void FixedUpdate()
    {
        set_speed();
    }

    void OnCollisionStay2D(UnityEngine.Collision2D stay)
    {

    }    
    void OnCollisionExit2D(UnityEngine.Collision2D other)
    {
        // Debug.Log(other.gameObject.name + "から離れた");
        
        if(other.gameObject.name == "Water"){ 
            anim.SetBool("fishing",false);
            //Y軸固定を解放
            this.rb.constraints = RigidbodyConstraints2D.None;
            this.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void anim_direction()
    {
        var menuDialog = GameObject.Find("MenuDialog"); 
        var sayDialog = GameObject.Find("SayDialog"); 

        if(stopf == 1 && menuDialog == null && sayDialog == null && fishing.fishing_anim == false){
            // 入力を取得
            input = new Vector2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical"));

            if (input.x > 0) 
            {
                anim.SetBool("walk", true);
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (input.x < 0) 
            {
                anim.SetBool("walk", true);
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                anim.SetBool("walk", false);
            }
        }

    }

    void set_speed()
    {
        var menuDialog = GameObject.Find("MenuDialog"); 
        var sayDialog = GameObject.Find("SayDialog"); 
        
        if (input == Vector2.zero)
        {
            return;
        }
        if (stopf == 1 && menuDialog == null && sayDialog == null)
        {
            // 移動量を加算する
            rb.position += input * speed;
        }
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
            anim.SetBool("walk", false);
        }
        else if (state == State.Command)
        {
            stopf = 0;
            anim.SetBool("walk", false);
        }
    }
    
    public State GetState()
    {
        return state;
    }

}