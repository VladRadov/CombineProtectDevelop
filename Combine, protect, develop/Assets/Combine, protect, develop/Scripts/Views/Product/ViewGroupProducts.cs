using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ViewGroupProducts : MonoBehaviour
{
    private UnityEvent<TypeGroupProducts> _showProductsOfGroupEventHandler;

    [SerializeField] private TypeGroupProducts _typeGroupProducts;
    [Header("Имя продукта:")]
    [SerializeField] private string _nameGroupProducts;
    [SerializeField] private Text _nameTypeGroupProducts;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Image _iconView;
    [SerializeField] private Button _showProducts;

    public void Initialize()
    {
        _nameTypeGroupProducts.text = string.IsNullOrWhiteSpace(_nameGroupProducts) ? _typeGroupProducts.ToString() : _nameGroupProducts;
        _iconView.sprite = _icon;
        _showProductsOfGroupEventHandler = new UnityEvent<TypeGroupProducts>();
        _showProducts.onClick.AddListener(InvokeShowProductsOfGroup);
    }

    public void InvokeShowProductsOfGroup()
    {
        if (_showProductsOfGroupEventHandler != null)
            _showProductsOfGroupEventHandler.Invoke(_typeGroupProducts);
    }

    public void AddListenerShowProductsOfGroup(UnityAction<TypeGroupProducts> action) => _showProductsOfGroupEventHandler.AddListener(action);
}