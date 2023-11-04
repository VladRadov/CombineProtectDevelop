using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObject/Weapon")]
public class Weapon : BaseProduct
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Bullet _baseBullet;
    [SerializeField] private float _damage;
    [SerializeField] private ViewProduct _prefab;
    [SerializeField] private float _price;
    [SerializeField] private List<BaseProduct> _elementsBuild;
    [SerializeField] private TypeGroupProducts _groupProduct;

    public override string Name { get { return _name; } set { _name = value; } }
    public override string Description { get { return _description; } set { _description = value; } }
    public Bullet BaseBullet => _baseBullet;
    public float Damage => _damage;
    public override ViewProduct Prefab { get { return _prefab; } set { _prefab = value; } }
    public override ICurrency Price { get { return new Coin() { Value = _price }; } }
    public override List<BaseProduct> ElementsBuild { get { return _elementsBuild; } set { _elementsBuild = value; } }
    public override TypeGroupProducts GroupProduct { get { return _groupProduct; } set { _groupProduct = value; } }
}
