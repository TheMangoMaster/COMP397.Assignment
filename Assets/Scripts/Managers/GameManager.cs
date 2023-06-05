using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _gameManagerInstance;

    [Header("Score")]
    public TextMeshProUGUI scoreText;
    public int plyrScore = 0000;

    [Header("Currency Stats")]
    public TextMeshProUGUI coinText;
    public static int Money; //static so it carries on from one scene to another (learning)
    public int startMoney = 225;
 

    public GameManager Instance
    {
        get
        {
            if (_gameManagerInstance == null)
            Debug.LogError("Game Manager is Null");

            return _gameManagerInstance;
        }
    }

    private void Awake() {
        _gameManagerInstance = this;

    }


    void Start()
    {
        Money = startMoney;
    }



    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateMoney();
    }
    public void UpdateScore()
    {
       scoreText.text = plyrScore.ToString();
    }

    public void UpdateMoney()
    {
        coinText.text = "$" + Money.ToString();
    }


}
