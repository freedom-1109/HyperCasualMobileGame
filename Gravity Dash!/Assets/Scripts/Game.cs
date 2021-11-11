using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public static GameObject Bonus;
    [SerializeField] private GameObject player;

    private static int _score;
    [SerializeField] private Text scoreText;
    private static Text _scoreTextToWrite; // static переменная scoreText для использования ее не в FixedUpdate() (что-то вроде оптимизации)
    
    public void Start()
    {
        // установка всех начальных значений
        // счет
        _score = 0;
        _scoreTextToWrite = scoreText;
        _scoreTextToWrite.text = _score.ToString();
        // блок до нажатия
        Player.GameBlock = true;

        // переменные статические => нужно их задать так, а не через [SerializeField]
        Bonus = GameObject.Find("Main Camera/Canvas/Game Field/Bonus");
        
        // установка обьектов на старт позиции
        Bonus.transform.localPosition = new Vector3(Random.Range(-0.3f, 0.3f), 0.425f, 0);
        player.transform.localPosition = new Vector3(0,0,0);
        
        // установка начального направления полета игрока
        Player.direction = Bonus.transform.localPosition.normalized;
    }

    public static void BonusBehavior()
    {
        _score++;
        // вывод счета на экран
        _scoreTextToWrite.text = _score.ToString();
        
        // перемещение бонуса
        Bonus.transform.localPosition = Math.Abs(Bonus.transform.localPosition.y - 0.425f) < .01 ? 
            new Vector3(Random.Range(-0.3f, 0.3f), -0.425f, 0) : 
            new Vector3(Random.Range(-0.3f, 0.3f), 0.425f, 0);
    }
}
