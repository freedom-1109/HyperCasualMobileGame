using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    private GameObject _bonus = Game.Bonus;
    private GameObject _player = Game.Player;
    [SerializeField] private float speed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bonus"))
            Game.MoveBonus();
    }

    private void FixedUpdate()
    {
        
    }
}
