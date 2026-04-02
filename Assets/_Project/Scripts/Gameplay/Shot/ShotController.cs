using UnityEngine;
using Zenject;

public class ShotController : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform spawnPosition;

    [Inject] IHoldInput input;
    [Inject] ISize sizeControl;
    [Inject] DiContainer container;

    IProjectile projectile;

    private void Start()
    {
        input.InputHolded += CreateProjectile;
        input.InputReleased += FireProjectile;
        sizeControl.sizeChanged += ProjectilePower;
    }

    void CreateProjectile()
    {
        GameObject go = container.InstantiatePrefab(projectilePrefab, spawnPosition.position, Quaternion.identity, null);

        projectile = go.GetComponent<IProjectile>();
    }

    void FireProjectile()
    {
        if(projectile != null)
            projectile.Fire();

        projectile = null;
    }

    void ProjectilePower(float size)
    {
        float normalized = 1f - (size / sizeControl.StartSize);

        if (projectile != null)
            projectile.IncreasePower(normalized);
    }
}

public interface IProjectile
{
    void IncreasePower(float powerValue);

    void Fire();

}

