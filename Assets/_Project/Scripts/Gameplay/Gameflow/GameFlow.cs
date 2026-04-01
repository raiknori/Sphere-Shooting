using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameFlow : MonoBehaviour, IGameOver
{
    public event Action OnGameOver;
    public event Action OnGameWon;

    [SerializeField] GameObject controllers;
    [SerializeField] GameObject systems;

    public void GameOver()
    {
        controllers.SetActive(false);
        systems.SetActive(false);

        OnGameOver?.Invoke();
    }

    public void GameWon()
    {
        controllers.SetActive(false);
        systems.SetActive(false);

        OnGameWon?.Invoke();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
