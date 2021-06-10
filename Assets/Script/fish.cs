using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{
    [SerializeField]GameObject Player;
    [SerializeField]GameObject homingObj;
    public float Speed;
    Vector3 play;
    bool fishFlg;

    // Use this for initialization
    void Start () {
        play = Player.transform.position;
        fishFlg = true;
    }

    // Update is called once per frame
    void Update () {
        if (this.transform.position.y != play.y + 2 && this.transform.position.x != play.x && fishFlg ==true)
        {
            this.transform.position = Vector2.MoveTowards (this.transform.position,new Vector2(play.x, play.y + 2), Speed * Time.deltaTime);
            fishFlg = false;
        } 
        
    }
}
