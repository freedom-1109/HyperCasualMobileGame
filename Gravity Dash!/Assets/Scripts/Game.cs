using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public static GameObject Bonus;
    public static GameObject Player;

    private static int Score;
    [SerializeField] private Text ScoreText;
    
    private void Start()
    {
        Score = 0;
        
        Bonus = GameObject.Find("Main Camera/Canvas/Game Field/Bonus");
        Player = GameObject.Find("Main Camera/Canvas/Game Field/Player");
        
        Bonus.transform.localPosition = new Vector3(Random.Range(-.3f, .3f), .425f, 0);
        Player.transform.localPosition = new Vector3(0,0,0);
        
    }

    private void FixedUpdate()
    {
        ScoreText.text = Score.ToString();
    }

    public static void BonusBehavior()
    {
        Score++;
        
        Bonus.transform.localPosition = Math.Abs(Bonus.transform.localPosition.y - .425f) < .01 ? 
            new Vector3(Random.Range(-.3f, .3f), -.425f, 0) : 
            new Vector3(Random.Range(-.3f, .3f), .425f, 0);
    }
}
