using System.Collections.Generic;

public class Shop
{
    private List<BaseProduct> _products;

    public void SetProducts(List<BaseProduct> products) => _products = products;

    public T Purchase<T>(T product) where T : BaseProduct
    {
        return (T)_products.Find(productShop => productShop.GetType() == typeof(T));
    }

    public bool IsHaveProduct<T>(T product) where T : BaseProduct
    {
        var findedProduct = _products.Find(productShop => productShop.GetType() == typeof(T));
        return findedProduct != null ? true : false;
    }

    public List<BaseProduct> GetProductsOfGroup(TypeGroupProducts typeGroupProducts) => _products.FindAll(product => product.GroupProduct == typeGroupProducts);
}