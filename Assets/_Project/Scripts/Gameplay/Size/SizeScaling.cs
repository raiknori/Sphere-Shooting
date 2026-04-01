using UnityEngine;
using Zenject;

public class SizeScaling:MonoBehaviour
{
    [SerializeField] Transform scalingObject;
    [SerializeField] Vector3 criticalScale;

    [Inject] ISize size;

    Vector3 startScale;
    private void Start()
    {
        startScale = scalingObject.localScale;
        size.sizeChanged += Scale;
    }

    void Scale(float newSize)
    {
        float t = newSize/size.StartSize;

        scalingObject.localScale = Vector3.Lerp(criticalScale, startScale, t);
    }
}

