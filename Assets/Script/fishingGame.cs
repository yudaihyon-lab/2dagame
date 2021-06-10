using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishingGame : MonoBehaviour
{

    
    [SerializeField]GameObject playerObj;
    player play;
    [SerializeField]GameObject fishing_view;
    View_FishGame view_Fish;
    bool collisonFlg;
    [SerializeField]GameObject fishing_system;
    Fishing_System fishing;

    // Start is called before the first frame update
    void Start()
    {
        play = playerObj.GetComponent<player>();
        view_Fish = fishing_view.GetComponent<View_FishGame>();
        fishing = fishing_system.GetComponent<Fishing_System>();
	}

    // Update is called once per frame
    void Update()
    {
        pushFishingKey();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "hitBar")
        {
            collisonFlg = true;
            Debug.Log(collisonFlg);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "hitBar")
        {
            collisonFlg = false;
            Debug.Log(collisonFlg);
        }
    }

    void pushFishingKey()
    {
        if (Input.GetKeyDown(KeyCode.Space) && collisonFlg == true)
        {
            view_Fish.unviewFishGame();
            // StartCoroutine(play.fishGetFlow());
            fishing.getFishinCor();
        }else if(Input.GetKeyDown(KeyCode.Space) && collisonFlg == false)
        {
            view_Fish.unviewFishGame();
            // StartCoroutine(play.fishGetFlow());
            fishing.getFishinCor_miss();
        }
    }
}
