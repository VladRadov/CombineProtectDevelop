using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObject/Bullet")]
public class Bullet : ScriptableObject
{
    [SerializeField] private GameObject _prefab;

    public GameObject Prefab => _prefab;
}
