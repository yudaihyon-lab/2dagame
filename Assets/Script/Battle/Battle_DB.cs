using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_DB : MonoBehaviour
{

    public static string Enemy_Name;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad (this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setEnemyName(string enemyName)
    {
        Enemy_Name = enemyName;
    }

    public string getEnemyName()
    {
        return Enemy_Name;
    }
}
