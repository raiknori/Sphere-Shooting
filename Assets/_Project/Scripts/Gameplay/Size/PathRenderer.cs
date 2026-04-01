using Unity.Android.Gradle;
using UnityEngine;
using Zenject;

public class PathRenderer:MonoBehaviour
{
    [Inject] ISize size;
    [SerializeField] Transform targetObject;
    [SerializeField] Transform finish;
    [SerializeField] Transform quad;

    private void Start()
    {
        size.sizeChanged += DrawPath;
        CalculatePath();
    }

    void DrawPath(float newSize)
    {
        CalculatePath();   
    }

    void CreateRoadQuad(Vector3 A, Vector3 B, Vector3 C, Vector3 D)
    {
        Vector3 center = (A + B + C + D) / 4f;
        center.y = 0.01f;


        quad.position = center;

        Vector3 widthDir = (B - A).normalized;
        Vector3 lengthDir = (D - A).normalized;

        float width = Vector3.Distance(A, B);
        float length = Vector3.Distance(A, D);

        quad.localScale = new Vector3(width, length, 1f);
    }

    void CalculatePath()
    {
        Vector3 pos = targetObject.transform.position;

        var halfW = targetObject.localScale.x / 2;
        var halfL = finish.position.z*1.6f;

        Vector3 A = pos - targetObject.transform.right * halfW - targetObject.transform.forward;
        Vector3 B = pos + targetObject.transform.right * halfW - targetObject.transform.forward;
        Vector3 C = pos + targetObject.transform.right * halfW + targetObject.transform.forward * halfL;
        Vector3 D = pos - targetObject.transform.right * halfW + targetObject.transform.forward * halfL;

        CreateRoadQuad(A, B, C, D);
    }
}
