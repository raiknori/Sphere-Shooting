using System;

public interface ICheckObstacle
{
    event Action OnObstacleHit;
    event Action OnFinishHit;
}