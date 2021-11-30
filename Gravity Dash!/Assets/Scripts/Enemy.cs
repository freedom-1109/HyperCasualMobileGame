using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject enemyBody;

    private static float enemySpeed;
    [SerializeField] private float rotateSpeedRange;
    private float rotateSpeed;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Remover"))
            Destroy(enemy);
    }
    
    
    public static void ChangeDirection() // разворот врага todo доделать плавность перехода!!!!!!!!!!!!!!!!!!!!
    {
        enemySpeed = -enemySpeed;
    } 
    
    private void Start()
    {
        enemySpeed = Game.Score / 5 % 2 == 0 ? Game.EnemySpeed : -Game.EnemySpeed;
        rotateSpeed = Random.Range(-rotateSpeedRange, rotateSpeedRange);
        enemyBody.transform.Rotate(0, 0, Random.Range(-180, 180));
    }

    private void FixedUpdate()
    {
        enemy.transform.Translate(enemySpeed, 0, 0);
        enemyBody.transform.Rotate(0, 0, rotateSpeed);
    }
}
