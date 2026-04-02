using System;

public interface ICheckObstacle
{
    event Action OnObstacleNotInterfere;

    void CheckObstacle();
}