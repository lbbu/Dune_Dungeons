using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerInventory: MonoBehaviour 
{
    List<GoldeKeyBase> Gkey = new List<GoldeKeyBase>();
    List<SelverKeyBase> Skey = new List<SelverKeyBase>();

   [SerializeField] int GoldKeys;
   [SerializeField] int silverKeys;


    int Coins;

    private void Update()
    {
        GoldKeys = Gkey.Count;
        silverKeys = Skey.Count;
    }
    public  void AddGoldKey()
    {
        Gkey.Add(new GoldeKeyBase());
        Debug.Log(GoldKeys + " Gold");
    }


    public void AddSelverKey()
    {
        Skey.Add(new SelverKeyBase());
        Debug.Log(silverKeys + " Selver");
    }
}

