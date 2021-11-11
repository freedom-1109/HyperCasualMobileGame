using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bonus;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerBody;

    private Vector3 direction;
    [SerializeField] public float playerSpeed;
    [SerializeField] public float playerRotationSpeed;

    public void OnClick() {playerSpeed = -playerSpeed;}

    private void ChangePlayerDirection()
    {
        // вычисление направления движения игрока
        var bonusPosition = _bonus.transform.localPosition;
        var playerPosition = _player.transform.localPosition;
        direction = new Vector2(bonusPosition.x - playerPosition.x, bonusPosition.y - playerPosition.y).normalized;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Bonus": // подбор бонуса
                Game.BonusBehavior();
                break;
            case "let": // столкновение с препятствием
                Dead();
                break;
        }
        
        ChangePlayerDirection();
    }

    private void Start()
    {
        ChangePlayerDirection();
    }

    private void FixedUpdate()
    {
        // движение игрока
        _player.transform.Translate(direction * playerSpeed);
        _playerBody.transform.Rotate(0, 0, playerRotationSpeed);
    }

    private void Dead()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
