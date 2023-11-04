using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IPerson
{
    private WalletController _walletController;

    public Player(WalletController walletController)
    {
        _walletController = walletController;
    }

    public string Name { get; set; }  
    public Bullet BaseBullet { get; set; }
}