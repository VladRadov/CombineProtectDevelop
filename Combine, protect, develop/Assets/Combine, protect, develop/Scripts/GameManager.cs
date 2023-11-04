using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private IWallet _wallet;
    private Player _player;
    private ShopController _shopController;
    private WalletController _walletController;

    [SerializeField] private float _coins;
    [SerializeField] private List<ViewBaseShop> _viewsShop;
    [SerializeField] private List<ViewBaseWallet> _viewCurrency;

    private void Start()
    {
        _walletController = new WalletController(new Wallet(), _viewCurrency, new Coin() { Value = 1000 });
        _player = new Player(_walletController);
        _shopController = new ShopController(new Shop(), _viewsShop);
        _shopController.PurchasingEventHandler.AddListener(_walletController.OnPurchasing);
    }
}
