using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncountEnemy : MonoBehaviour
{

    public GameObject ImgEnd;　　　//終了ダイアログ

    public Fade fade;              //フェードキャンバス取得
    [SerializeField]GameObject Player;
    player player;
    [SerializeField]GameObject EnemyDB;
    Battle_DB battleDB;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.GetComponent<player>();
        battleDB = EnemyDB.GetComponent<Battle_DB>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "enemy")
        {

            player.stopPlayerMotion();
            fade.FadeIn(1f, () =>
            {
                // battleDB.setEnemyName(collisionInfo.gameObject.name);
                Battle_DB.Enemy_Name = collisionInfo.gameObject.name;
                SceneManager.LoadScene("Battle");
            });
                
            }
    }
}
