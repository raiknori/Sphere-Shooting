
using UnityEngine;

public class DeffaultProjectile : MonoBehaviour, IProjectile
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float force;
    [SerializeField] LayerMask obstacleLayer;

    float power = 0f;

    Vector3 startScale;
    void Awake()
    {
        startScale = transform.localScale;
        Debug.Log(startScale);
    }
    public void Fire()
    {
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    public void IncreasePower(float powerValue)
    {
        power = Mathf.Max(powerValue, 0f);
        transform.localScale = startScale * (1f + power);
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 hitPoint = collision.contacts[0].point;

        Collider[] colliders = Physics.OverlapSphere(hitPoint, power*2.5f, obstacleLayer);

        foreach (var col in colliders)
        {
            if (col.TryGetComponent<IObstacle>(out var obstacle))
            {
                Debug.Log(col.gameObject.name);
                obstacle.OnHit();
            }
        }

        Destroy(gameObject);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, power*2.5f);
    }
}

