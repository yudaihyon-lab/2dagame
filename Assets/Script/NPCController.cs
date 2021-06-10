using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(Flowchart))]
public class NPCController : MonoBehaviour
{
    [SerializeField]
    string message = "";
    GameObject playerObj;
    Flowchart flowChart;
    player player;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<player>();
        flowChart = GetComponent<Flowchart>();
    }
    private  void OnCollisionEnter2D(UnityEngine.Collision2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            StartCoroutine(Talk());
        }
    }

    private  void OnCollisionStay2D(UnityEngine.Collision2D stay)
    {
 
    }

    void update ()
    {

    }
   
    IEnumerator Talk()
    {

        player.SetState(player.State.Talk);

        flowChart.SendFungusMessage(message);
        yield return new WaitUntil(() => flowChart.GetExecutingBlocks().Count == 0);

        player.SetState(player.State.Normal);
    }
}