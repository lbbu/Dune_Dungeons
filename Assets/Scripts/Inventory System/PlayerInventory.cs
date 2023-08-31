using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerInventory: MonoBehaviour 
{
    List<GoldeKeyBase> Gkey = new List<GoldeKeyBase>();
    List<SelverKeyBase> Skey = new List<SelverKeyBase>();

    int Coins;

   public  void AddGoldKey()
    {
        Gkey.Add(new GoldeKeyBase());
        Debug.Log(Gkey.Count+" Gold");
    }


    public void AddSelverKey()
    {
        Skey.Add(new SelverKeyBase());
        Debug.Log(Skey.Count + " Selver");
    }
}

