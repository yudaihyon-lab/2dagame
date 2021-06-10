using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    int counter = 0;
    float move = 0.40f;
 
    void Update()
    {
        Vector3 p = new Vector3(move, 0, 0);
        transform.Translate(p);
        counter += 2;
        
        //countが100になれば-1を掛けて逆方向に動かす
        if (counter == 100)
        {
            counter = 0;
            move *= -1;
        }
    }
}
