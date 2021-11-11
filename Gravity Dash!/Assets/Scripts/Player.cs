using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bonus;
    [SerializeField] private GameObject _player;
    private Vector3 direction;
    [SerializeField] private float speed;

    // подбор бонуса
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bonus"))
            Game.BonusBehavior();
    }

    private void FixedUpdate()
    {
        // вычисление направления движения игрока
        var bonusPosition = _bonus.transform.localPosition;
        var playerPosition = _player.transform.localPosition;
        direction = new Vector2(bonusPosition.x - playerPosition.x, bonusPosition.y - playerPosition.y).normalized;
        
        // движение игрока
        if (!Game.buttonActive)
            _player.transform.Translate(direction * speed);
        else
            _player.transform.Translate(direction * -speed);
    }
}
