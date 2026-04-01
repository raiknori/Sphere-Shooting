using System;

public interface IGameOver
{
    event Action OnGameOver;
    event Action OnGameWon;
    void GameOver();
    void GameWon();
}
