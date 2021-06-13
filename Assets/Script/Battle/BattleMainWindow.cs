using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMainWindow : MonoBehaviour
{
    public Text PartyName1;
    public Text PartyName2;
    public Text PartyName3;
    public Text PartyName4;
 
    // Start is called before the first frame update
    void Start()
    {
        PartyName1.text = "ひょん";
        PartyName2.text = "ちはる";
        PartyName3.text = "こはる";
        PartyName4.text = "ぶっちぃ";
    }
  
    // Update is called once per frame
    void Update()
    {
    }
}
