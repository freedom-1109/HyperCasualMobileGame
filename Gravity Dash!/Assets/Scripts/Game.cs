using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    private static GameObject bonus;
    private static GameObject player;

    private static int Score;
    [SerializeField] private Text ScoreText;
    
    private void Start()
    {
        Score = 0;
        
        // переменные статыческие => нужно их задать так, а не через [SerializeField]
        bonus = GameObject.Find("Main Camera/Canvas/Game Field/Bonus");
        player = GameObject.Find("Main Camera/Canvas/Game Field/Player");
        
        // установка обьектов на старт позиции
        bonus.transform.localPosition = new Vector3(Random.Range(-.3f, .3f), .425f, 0);
        player.transform.localPosition = new Vector3(0,0,0);
        
    }

    private void FixedUpdate()
    {
        // вывод счета на экран
        ScoreText.text = Score.ToString();
    }

    public static void BonusBehavior()
    {
        Score++;
        
        // перемещение бонуса
        bonus.transform.localPosition = Math.Abs(bonus.transform.localPosition.y - .425f) < .01 ? 
            new Vector3(Random.Range(-.3f, .3f), -.425f, 0) : 
            new Vector3(Random.Range(-.3f, .3f), .425f, 0);
    }
}
