using UnityEngine;
using Zenject;

public class SizeController : MonoBehaviour, ISize
{
    [SerializeField] float startSize;
    [SerializeField] float downsizingSpeed;

    [Inject] IHoldInput holdInput;

    public event System.Action<float> sizeChanged;

    float size;
    bool holded = false;

    public float StartSize => startSize;

    private void Start()
    {
        size = startSize;
        holdInput.InputHolded += OnHold;
        holdInput.InputReleased += OnReleased;
    }

    void OnHold()
    {
        holded = true;
    }

    void OnReleased()
    {
        holded = false;
    }

    void ChangeSize()
    {
        size -= downsizingSpeed * Time.deltaTime;
        sizeChanged?.Invoke(size);
        Debug.Log($"Size changed: {size}");
    }

    private void Update()
    {
        if(holded)
        {
            ChangeSize();
        }
    }

}

