using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    Battle_DB battleDB;
    string Enemy_Name;

    // Start is called before the first frame update
    void Start()
    {
        GameObject EnemyDB = GameObject.Find ("Battle_DB");
        battleDB = EnemyDB.GetComponent<Battle_DB>();

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Enemy_Name);
        Debug.Log(Battle_DB.Enemy_Name);
    }

    void getEnemyData()
    {
        Enemy_Name = battleDB.getEnemyName();
    }
}
