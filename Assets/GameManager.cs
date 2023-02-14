using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool playerDead = false;
    public static GameManager instance;
    private int wormsCollected;

    [SerializeField]
    TextMeshProUGUI scoreUI;
    [SerializeField]
    TextMeshProUGUI gameEndUI;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool GetGameStatus()
    {
        return playerDead;
    }
    public void Kill()
    {
        print("Player has died");
        playerDead = true;
        scoreUI.gameObject.SetActive(false);
        gameEndUI.gameObject.SetActive(true);
    }
    public void AddWorm()
    {
        wormsCollected++;
        scoreUI.text = wormsCollected.ToString();
    }

}
