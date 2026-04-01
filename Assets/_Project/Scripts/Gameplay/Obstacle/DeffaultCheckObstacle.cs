using System;
using UnityEngine;

public class DeffaultCheckObstacle : MonoBehaviour, ICheckObstacle
{
    public event Action OnObstacleHit;
    public event Action OnFinishHit;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<IObstacle>(out var obstacle) )
        {
            OnObstacleHit?.Invoke();
        }
        else if(collision.gameObject.tag == "Finish")
        {
            OnFinishHit?.Invoke();
        }
    }
}
