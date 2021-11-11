using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bonus;
    [SerializeField] private GameObject _player;
    private Vector3 direction;
    [SerializeField] private float speed;

    
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

    private void Dead()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
