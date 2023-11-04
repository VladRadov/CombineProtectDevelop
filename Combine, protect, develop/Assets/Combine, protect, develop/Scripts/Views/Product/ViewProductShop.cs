using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewProductShop : MonoBehaviour
{
    [SerializeField] private Text _nameProduct;
    [SerializeField] private Text _descriptionProduct;
    [SerializeField] private Text _price;
    [SerializeField] private Button _buildProduct;
    [SerializeField] private Button _viewBuildComponentProduct;
    [SerializeField] private GameObject _baseWindow;

    public string NameProduct { set { _nameProduct.text = value; } }
    public string DescriptionProduct { set { _descriptionProduct.text = value; } }
    public float Price { set { _price.text = value.ToString(); } }
    public GameObject BaseWindow => _baseWindow;
}
