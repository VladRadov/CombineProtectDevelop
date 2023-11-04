using System.Collections.Generic;
using UnityEngine.Events;

public class ShopController
{
    private Shop _shop;
    private List<ViewBaseShop> _views;
    private ViewShop _viewShop;
    private BaseProduct _currentProductView;

    public UnityEvent<BaseProduct> PurchasingEventHandler;

    public ShopController(Shop shop, List<ViewBaseShop> viewsShop)
    {
        _views = viewsShop;
        _shop = shop;

        Initialize();
    }

    private void Initialize()
    {
        PurchasingEventHandler = new UnityEvent<BaseProduct>();
        foreach (var view in _views)
            view.Initialize();

        _viewShop = GetView<ViewShop>();
        if (_viewShop != null)
        {
            _shop.SetProducts(_viewShop.Products);
            _viewShop.InitializeGroupsProducts(GetFirstProductOfGroup);
            _viewShop.SubscribeOnBackButton(GetBackProduct);
            _viewShop.SubscribeOnNextButton(GetNextProduct);
            _viewShop.SubscribeOnPurchaseButton(Purchase);
        }
    }

    private void Purchase()
    {
        if (PurchasingEventHandler != null && _currentProductView != null)
            PurchasingEventHandler.Invoke(_currentProductView);
    }

    private void GetNextProduct() => ChangeCurrentProduct(true);

    private void GetBackProduct() => ChangeCurrentProduct(false);

    private void ChangeCurrentProduct(bool isNext)
    {
        if (_currentProductView != null)
        {
            var products = _shop.GetProductsOfGroup(_currentProductView.GroupProduct);
            if (products.Count > 0)
            {
                var indexCurrentProductView = products.IndexOf(_currentProductView);
                var indexNext = isNext ? indexCurrentProductView + 1 : indexCurrentProductView - 1;
                if ((isNext && indexNext < products.Count) || (isNext == false && indexCurrentProductView != 0))
                    GetProductsOfGroup(_currentProductView.GroupProduct, indexNext);
            }
        }
    }

    private void GetFirstProductOfGroup(TypeGroupProducts typeGroupProducts) => GetProductsOfGroup(typeGroupProducts, 0);

    public void GetProductsOfGroup(TypeGroupProducts typeGroupProducts, int index)
    {
        var products = _shop.GetProductsOfGroup(typeGroupProducts);
        if (products.Count > 0)
        {
            _currentProductView = products[index];
            _viewShop.ViewProduct(_currentProductView.Name, _currentProductView.Description, _currentProductView.Price.Value, _currentProductView.Prefab);
        }
    }

    private T GetView<T>() where T : ViewBaseShop
    {
        var findedView = (T)_views.Find(view => view.GetType() == typeof(T));
        return findedView;
    }
}
