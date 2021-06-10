using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStatusData : ScriptableObject
{

  public List<EnemyStatus> enemyStatusList = new List<EnemyStatus>();

}

[System.Serializable]
public class EnemyStatus
{

  [SerializeField]
  string name = "";
  [SerializeField]
  int maxHP = 1;
  [SerializeField]
  float defaultSpeed = 0;
  [SerializeField]
  int defaultPower = 0;
  [SerializeField]
  bool enableSperArmor = false;
  [SerializeField]
  float superArmorActiveTime = 0;
  [SerializeField]
  int score = 0;
  [SerializeField]
  GameObject dropItem;
  [SerializeField]
  GameObject deadEffect;


  public string Name
  {
    get
    {
      return name;
    }
  }

  public int MaxHp
  {
    get
    {
      return maxHP;
    }
  }

  public float DefaultSpeed
  {
    get
    {
      return defaultSpeed;
    }
  }

  public int DefaultPower
  {
    get
    {
      return defaultPower;
    }
  }

  public bool EnableSuperArmor
  {
    get
    {
      return enableSperArmor;
    }
  }

  public float SuperArmorActiveTime
  {
    get
    {
      return superArmorActiveTime;
    }
  }

  public int Score
  {
    get
    {
      return score;
    }
  }

  public GameObject DropItem
  {
    get
    {
      return dropItem;
    }
  }

  public GameObject DeadEffect
  {
    get
    {
      return deadEffect;
    }
  }

}