using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ViewShop : ViewBaseShop
{
    [SerializeField] private List<BaseProduct> _products;
    [SerializeField] private Button _openShop;
    [SerializeField] private List<ViewGroupProducts> _groupsProducts;
    [SerializeField] private ViewProductShop _viewProduct;
    [SerializeField] private Button _backProduct;
    [SerializeField] private Button _nextProduct;
    [SerializeField] private Button _purchase;
    [SerializeField] private GameObject _map;

    public List<BaseProduct> Products => _products;

    public override void Initialize()
    {
        base.Initialize();
        BaseTransform.gameObject.SetActive(false);
        _viewProduct.gameObject.SetActive(false);
        _openShop.onClick.AddListener(SetActiveShop);
    }

    public void SubscribeOnBackButton(UnityAction action) => _backProduct.onClick.AddListener(action);

    public void SubscribeOnNextButton(UnityAction action) => _nextProduct.onClick.AddListener(action);

    public void SubscribeOnPurchaseButton(UnityAction action) => _purchase.onClick.AddListener(action);

    public void InitializeGroupsProducts(UnityAction<TypeGroupProducts> action)
    {
        foreach (var groupProducts in _groupsProducts)
        {
            groupProducts.Initialize();
            groupProducts.AddListenerShowProductsOfGroup(action);
        }
    }

    public void ViewProduct(string nameProduct, string descriptionProduct, float price, ViewProduct prefab)
    {
        _viewProduct.NameProduct = nameProduct;
        _viewProduct.DescriptionProduct = descriptionProduct;
        _viewProduct.Price = price;
        PoolObjects<ViewProduct>.DisactiveObjects();
        PoolObjects<ViewProduct>.GetObject(prefab, _viewProduct.BaseWindow.transform);
        EnableViewProduct();
    }

    private void EnableViewProduct()
    {
        if(_viewProduct.gameObject.activeSelf == false)
            _viewProduct.gameObject.SetActive(true);
    }

    private void SetActiveShop()
    {
        BaseTransform.gameObject.SetActive(!BaseTransform.gameObject.activeSelf);
        _map.gameObject.SetActive(!BaseTransform.gameObject.activeSelf);
    }
}
