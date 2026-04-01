using System.Reflection;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DebugMethod : MonoBehaviour
{
    [SerializeField] string methodName = "methodName";
    [SerializeField] MonoBehaviour target;

    [ContextMenu("Run debug method")]
    void CallDebugMethod()
    {
        if (target == null)
        {
            Debug.LogWarning("Target is null");
            return;
        }

        var method = target.GetType().GetMethod(methodName,
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);

        if (method != null)
        {
            method.Invoke(target, null);
        }
        else
        {
            Debug.LogWarning($"Method '{methodName}' not found on {target.GetType()}");
        }
    }

    private void OnValidate()
    {
        Debug.LogWarning($"DebugMethod attached to {gameObject.name} gameobject!");
    } 
}
