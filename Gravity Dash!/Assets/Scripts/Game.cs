using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public static GameObject Bonus;
    private static float bonusPosRange;
    [SerializeField] private GameObject player;
    public Transform enemy;
    public static float EnemySpeed;
    
    [SerializeField] private float spawnEnemiesWait;

    public static int Score;
    [SerializeField] private Text scoreText;
    private static Text _scoreTextToWrite; // static переменная scoreText для использования ее не в FixedUpdate() (что-то вроде оптимизации)

    private Vector3 direction;
    public void Start()
    {
        direction = Vector3.down;
        // установка всех начальных значений
        // счет
        Score = 0;
        _scoreTextToWrite = scoreText;
        _scoreTextToWrite.text = Score.ToString();
        bonusPosRange = 0.25f;
        EnemySpeed = 0.025f;
        
        // блок до нажатия
        Player.GameBlock = true;

        // переменные статические => нужно их задать так, а не через [SerializeField]
        Bonus = GameObject.Find("Main Camera/Canvas/Game Field/Bonus");
        
        // установка обьектов на старт позиции
        Bonus.transform.localPosition = new Vector3(Random.Range(-bonusPosRange, bonusPosRange), 0.425f, 0);
        player.transform.localPosition = new Vector3(0,-0.4f,0);
        
        // установка начального направления полета игрока
        Player.Direction = Bonus.transform.localPosition.normalized;
        
        // спавн врагов
        StartCoroutine(SpawnEnemies());
    }

    private void FixedUpdate()
    {
        if (math.abs(gameObject.transform.position.y) > 0.2f)
            direction = -direction;
        gameObject.transform.Translate(direction * 0.0025f);
    }

    public static void BonusBehavior()
    {
        // увеличение скорости всех будующих врагов
        EnemySpeed += 0.001f;
        
        Score++;

        // разворот врага
        if (Score % 5 == 0)
        {
            Enemy.ChangeDirection();
        }
        
        // вывод счета на экран
        _scoreTextToWrite.text = Score.ToString();

        // перемещение бонуса
        Bonus.transform.localPosition = Math.Abs(Bonus.transform.localPosition.y - 0.425f) < .01 ? 
            new Vector3(Random.Range(-bonusPosRange, bonusPosRange), -0.425f, 0) : 
            new Vector3(Random.Range(-bonusPosRange, bonusPosRange), 0.425f, 0);
    }
    
    private IEnumerator SpawnEnemies()
    {
        
        if (Score / 5 % 2 == 0)
        {
            if (!Player.GameBlock)
                Instantiate(enemy, new Vector3(-4f, Random.Range(-1.4f, 1.4f), 0), Quaternion.identity);
        }
        else
        {
            if (!Player.GameBlock)
                Instantiate(enemy, new Vector3(4f, Random.Range(-1.4f, 1.4f), 0), Quaternion.identity);
        }
        yield return new WaitForSeconds(spawnEnemiesWait + 0.025f - Math.Abs(EnemySpeed));
        StartCoroutine(SpawnEnemies());
    }
    
    
}
