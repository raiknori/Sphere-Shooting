using System;
using UnityEngine;

public class DeffaultCheckObstacle : MonoBehaviour, ICheckObstacle
{
    public event Action OnObstacleNotInterfere;

    [SerializeField] Transform checkingObject;

    [SerializeField] LayerMask layerMask;

    int GetCollisionsNumber()
    {
        Collider[] hitColliders = Physics.OverlapBox(checkingObject.position, checkingObject.localScale / 2f, checkingObject.rotation, layerMask);

        return hitColliders.Length;
    }

    public void CheckObstacle()
    {
        if (GetCollisionsNumber() == 0)
        {
            OnObstacleNotInterfere.Invoke();
        }
    }
}
