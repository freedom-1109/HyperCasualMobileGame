using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public static GameObject Bonus;
    public static GameObject Player;
    
    private void Start()
    {
        Bonus = GameObject.Find("Main Camera/Canvas/Game Field/Bonus");
        Player = GameObject.Find("Main Camera/Canvas/Game Field/Player");
        
        Bonus.transform.localPosition = new Vector3(Random.Range(-.25f, .25f), .425f, 0);
        Player.transform.localPosition = new Vector3(0,0,0);
        
    }

    public static void MoveBonus()
    {
        Bonus.transform.localPosition = Math.Abs(Bonus.transform.localPosition.y - .425f) < .01 ? 
            new Vector3(Random.Range(-.25f, .25f), -.425f, 0) : 
            new Vector3(Random.Range(-.25f, .25f), .425f, 0);
    }
}
