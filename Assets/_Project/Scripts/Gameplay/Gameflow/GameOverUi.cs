using UnityEngine;
using Zenject;

public class GameOverUi:MonoBehaviour
{
    [SerializeField] GameObject gameOverSection;
    [SerializeField] GameObject gameWonSection;

    [Inject] IGameOver gameOver;

    private void Awake()
    {
        gameOver.OnGameOver += ShowGameOver;
        gameOver.OnGameWon += ShowGameWon;
    }
    void ShowGameOver()
    {
        gameOverSection.SetActive(true);
    }

    void ShowGameWon()
    {
        gameWonSection.SetActive(true);
    }
}
