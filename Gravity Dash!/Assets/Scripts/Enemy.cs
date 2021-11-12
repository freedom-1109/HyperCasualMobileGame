using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject enemyBody;
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeedRange;
    private float rotateSpeed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Remover"))
            Destroy(enemy);
    }

    private void Start()
    {
        rotateSpeed = Random.Range(-rotateSpeedRange, rotateSpeedRange);
        enemyBody.transform.Rotate(0, 0, Random.Range(-180, 180));
    }

    private void FixedUpdate()
    {
        enemy.transform.Translate(moveSpeed, 0, 0);
        enemyBody.transform.Rotate(0, 0, rotateSpeed);
    }
}
