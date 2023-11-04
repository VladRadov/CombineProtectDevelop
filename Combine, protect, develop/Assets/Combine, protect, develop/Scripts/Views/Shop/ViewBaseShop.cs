using UnityEngine;

public class ViewBaseShop : MonoBehaviour
{
    private Transform _transform;

    public virtual void Initialize()
    {
        _transform = transform;
    }

    public Transform BaseTransform => _transform;
}