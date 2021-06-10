using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(Flowchart))]
public class Fishing_System : MonoBehaviour
{
    [SerializeField]GameObject bikkuri_view;
    [SerializeField]GameObject fishing_view;
    [SerializeField]GameObject fishing_game;
    [SerializeField]GameObject Player;
    [SerializeField]GameObject fish;
    Vector3 fishtmp;
    View_Bikkuri bikkuri;
    View_FishGame view_Fish;
    fishingGame game_Fish;
    player player;
    private Animator anim = null;
    public bool fishing_anim = false;
    public bool fishing_nowflg = false;
    public bool fishing_Secondflg = false;
    public bool fishGetTermFlg;
    [SerializeField]
    Flowchart flowChart;

	void Start()
	{
        fishtmp = fish.transform.position;
		anim = GetComponent<Animator>();
		bikkuri = bikkuri_view.GetComponent<View_Bikkuri>();
        view_Fish = fishing_view.GetComponent<View_FishGame>();
        game_Fish = fishing_game.GetComponent<fishingGame>();
        player = Player.GetComponent<player>();
	}
	 
	private void Update()
    {
        StartCoroutine(fishing_choise());
        if (this.fishing_Secondflg == true)
        {
            StartCoroutine(fishing_now());
            this.fishing_Secondflg = false;
        }
        fishGet();
    }

    private void FixedUpdate()
    {

    }

    void OnCollisionStay2D(UnityEngine.Collision2D stay)
    {
        if (Input.GetKeyDown(KeyCode.Space) && stay.gameObject.name == "魚1")
        {
            fish.SetActive(false);
            fish.transform.position = fishtmp;
        }
    }    
    void OnCollisionExit2D(UnityEngine.Collision2D other)
    {

    }
    void fishing_start()
    {
        anim.SetBool("fishing",true);
        player.respeed = player.speed;
        player.speed = 0;
        this.fishing_anim = true;
        fishing_nowflg = true;
        fishing_Secondflg = true;
    }

    public void fishing_exit()
    {
        player.speed = player.respeed;
        anim.SetBool("fishing",false);
        this.fishing_anim = false;
        this.fishGetTermFlg = false;
        this.fishing_nowflg = false;
        this.fishing_Secondflg = false;
    }

    public void getFishinCor()
    {
        StartCoroutine(fishGetFlow());
    }
        public void getFishinCor_miss()
    {
        StartCoroutine(fishGetFlow_miss());
    }

    IEnumerator fishing_choise()
    {
        if (Input.GetKey(KeyCode.Escape) && this.fishing_nowflg == true)
        {
            bikkuri.unviewBikkuri();
            player.SetState(player.State.Talk);
            flowChart.SendFungusMessage("釣りをやめる");
            yield return new WaitUntil(() => flowChart.GetExecutingBlocks().Count == 0);
            player.SetState(player.State.Normal);
        }
    }

    IEnumerator fishing_now()
    {
        var randomNm = Random.Range(5.0f, 10.0f);
        yield return new WaitForSeconds(randomNm);

        if (this.fishing_nowflg == true)
        {
            StartCoroutine(fishGetTerm());
            Debug.Log(randomNm + "今だ!");

			bikkuri.viewBikkuri();
        }
    }

    IEnumerator fishGetTerm()
    {
        this.fishGetTermFlg = true;
        var randomNm = Random.Range(1.0f, 1.5f);
        yield return new WaitForSeconds(randomNm);
        if (this.fishing_nowflg == true)
            {
                Debug.Log(randomNm + "ここまで～");
                bikkuri.unviewBikkuri();
                this.fishGetTermFlg = false;
                yield return new WaitForSeconds(5);
                this.fishing_Secondflg = true;
            }
    }

    void fishGet()
    {
        if (Input.GetKey(KeyCode.Space) && this.fishGetTermFlg == true)
        {
            Debug.Log("GET!");
            this.fishing_nowflg = false;
            this.fishGetTermFlg = false;
            bikkuri.unviewBikkuri();
            view_Fish.viewFishGame();       
        }
    }

    IEnumerator fishGetFlow()
    {
        fish.SetActive(true);    
        player.SetState(player.State.Talk);
        flowChart.SendFungusMessage("釣れた");

        yield return new WaitUntil(() => flowChart.GetExecutingBlocks().Count == 0);
        player.SetState(player.State.Normal);
        fishing_exit();
    }
        IEnumerator fishGetFlow_miss()
    {
        // view_Fish.unviewFishGame();    
        player.SetState(player.State.Talk);
        flowChart.SendFungusMessage("釣れなかった");
        yield return new WaitUntil(() => flowChart.GetExecutingBlocks().Count == 0);
        player.SetState(player.State.Normal);
        fishing_exit();
    }
}