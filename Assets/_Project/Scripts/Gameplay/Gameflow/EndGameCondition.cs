using UnityEngine;
using Zenject;

public class EndGameCondition:MonoBehaviour
{
    [Inject] IGameOver gameOver;
    [Inject] ISize size;
    [Inject] IFinishChecker finishChecker;


    void Start()
    {
        size.sizeChanged += CheckSize;
        finishChecker.OnFinishReached += FinishReached;
    }

    void CheckSize(float newSize)
    {
        if(newSize <= 0)
        {
            gameOver.GameOver();
        }
    }

    void FinishReached()
    {
        gameOver.GameWon();
    }



}