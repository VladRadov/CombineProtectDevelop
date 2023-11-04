using System.Collections.Generic;
using UnityEngine;

public class BaseProduct : ScriptableObject, IProduct
{
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }
    public virtual ICurrency Price { get; }
    public virtual List<BaseProduct> ElementsBuild { get; set; }
    public virtual TypeGroupProducts GroupProduct { get; set; }
    public virtual ViewProduct Prefab { get; set; }
}