using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerObjectController : MonoBehaviour, IFinishChecker
{
    [SerializeField] GameObject playerGameObject;
    [SerializeField] Rigidbody playerRb;

    [SerializeField] Transform finish;

    [SerializeField] float reachingForce;

    [Inject] ICheckObstacle checkObstacle;

    public event Action OnFinishReached;

    private void Start()
    {
        checkObstacle.OnObstacleNotInterfere += ReachToFinish;
    }

    void ReachToFinish()
    {
        if (playerGameObject != null && playerRb != null)
        {
            playerRb.AddForce(playerGameObject.transform.forward * reachingForce, ForceMode.Impulse);
            StartCoroutine(CheckingFinish());
        }
    }


    IEnumerator CheckingFinish()
    {
        while(true)
        {
            if(Vector3.Distance(playerGameObject.transform.position, finish.position) > 1f)
            {
                yield return null;
            }
            else
            {
                break;
            }

        }

        OnFinishReached?.Invoke();
    }

}
