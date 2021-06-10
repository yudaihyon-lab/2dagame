using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_FishGame : MonoBehaviour
{
     [SerializeField] GameObject ex;
    public AudioClip sound1;
    public bool audioFlg;
    AudioSource audioSource;
    [SerializeField] private GameObject testObject;
 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (audioFlg == true ) {
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(sound1);
            audioFlg = false;
        }
    }

    public void viewFishGame()
    {
        ex.SetActive(true);
    }

    public void unviewFishGame()
    {
        ex.SetActive(false);
    }
}
