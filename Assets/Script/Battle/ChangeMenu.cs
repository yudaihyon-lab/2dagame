using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMenu : MonoBehaviour
{
    public Button Battle;
    public Button SelectEnemy_Back;
    public GameObject SelectEnemy;
    // Start is called before the first frame update
    void Start()
    {
		Battle.onClick.AddListener (OnClickBattleButton);
        SelectEnemy_Back.onClick.AddListener (OnClickSelectEnemy_BackButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBattleButton()
    {
        SelectEnemy.SetActive(true); 
    }

        public void OnClickSelectEnemy_BackButton()
    {
        SelectEnemy.SetActive(false); 
    }
}
