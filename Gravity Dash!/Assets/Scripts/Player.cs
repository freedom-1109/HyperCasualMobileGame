using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerBody;

    public static Vector3 Direction;
    
    [SerializeField] public float playerSpeed;
    [SerializeField] public float playerRotationSpeed;

    public static bool GameBlock;

    public void OnClick() {if (!GameBlock) playerSpeed = -playerSpeed;} // разворот игрока по нажатию на экран

    public void RemoveBlock() {GameBlock = false;} // "пауза" до нажатия
    
    // вычисление нужного направления для движения игрока
    private void ChangePlayerDirection()
    {
        var bonusPosition = Game.Bonus.transform.localPosition;
        var playerPosition = player.transform.localPosition;
        Direction = new Vector2(bonusPosition.x - playerPosition.x, bonusPosition.y - playerPosition.y).normalized;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Border":
                playerSpeed = Math.Abs(playerSpeed);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Bonus": // подбор бонуса
                Game.BonusBehavior();
                playerSpeed += 0.001f;
                break;
            case "Border":
                playerSpeed = Math.Abs(playerSpeed);
                break;
            case "let": // столкновение с препятствием
                Dead();
                break;
        }
        
        ChangePlayerDirection();
        playerRotationSpeed *= -1;
    }

    private void FixedUpdate()
    {
        // движение игрока
        if (!GameBlock) 
            player.transform.Translate(Direction * playerSpeed);
        playerBody.transform.Rotate(0, 0, playerRotationSpeed);
    }

    private void Dead()
    {
        if (Game.Score > Game.settings.BestScore)
        {
            Game.settings.BestScore = Game.Score;
            File.WriteAllText(Application.streamingAssetsPath + "/settings.json", JsonUtility.ToJson(Game.settings));
        }
        SceneManager.LoadScene("MainMenuScene");
    }
}
