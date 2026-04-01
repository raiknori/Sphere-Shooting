using UnityEngine;
using Zenject;

public class EndGameCondition:MonoBehaviour
{
    [Inject] IGameOver gameOver;
    [Inject] ICheckObstacle checkObstacle;
    [Inject] ISize size;


    void Start()
    {
        size.sizeChanged += CheckSize;
        checkObstacle.OnObstacleHit += ObstacleTouched;
        checkObstacle.OnFinishHit += FinishReached;
    }

    void CheckSize(float newSize)
    {
        if(newSize <= 0)
        {
            gameOver.GameOver();
        }
    }

    void ObstacleTouched()
    {
        gameOver.GameOver();
    }

    void FinishReached()
    {
        gameOver.GameWon();
    }



}