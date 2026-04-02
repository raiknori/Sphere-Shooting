using System.Collections;
using UnityEngine;
using Zenject;

public class DeffaultObstacle : MonoBehaviour, IObstacle
{
    [SerializeField] float secondsToDestroy;

    [SerializeField] ColorChanger colorChanger;

    [SerializeField] Collider obstacleCollider;

    [Inject] ICheckObstacle checkObstacle;

    Coroutine infectionCoroutine;
    public void OnHit()
    {
        Infect();
    }

    void Infect()
    {
        StartInfectionCoroutine();
    }

    void StartInfectionCoroutine()
    {
        if (infectionCoroutine == null)
        {
            infectionCoroutine = StartCoroutine(Infection());
        }
    }

    IEnumerator Infection()
    {
        float t = 0;

        while (t < secondsToDestroy)
        {
            colorChanger.ChangeColor(t);
            t+= Time.deltaTime;
            yield return null;
        }

        obstacleCollider.enabled = false;
        checkObstacle.CheckObstacle();
        Destroy(gameObject);
    }


}
