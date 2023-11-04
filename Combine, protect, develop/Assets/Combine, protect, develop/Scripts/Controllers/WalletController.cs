using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletController
{
    private IWallet _wallet;

    private List<ViewBaseWallet> _views;

    public WalletController(IWallet wallet, List<ViewBaseWallet> views, params ICurrency[] currencies)
    {
        _wallet = wallet;
        _views = views;

        var viewCurrency = GetView<ViewCurrency>();
        if (viewCurrency != null)
            _wallet.ChangeValueCurrencyEventHandler.AddListener(viewCurrency.UpdateCurrency);

        _wallet.AddRange(currencies);
    }

    public void OnPurchasing(BaseProduct product)
    {
        if (_wallet.HasCountCurrencyOnPurchase(product.Price))
            _wallet.Decrease(product.Price);
    }

    private T GetView<T>() where T : ViewBaseWallet
    {
        var findedView = (T)_views.Find(view => view.GetType() == typeof(T));
        return findedView;
    }
}
