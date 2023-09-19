using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerInventory: MonoBehaviour 
{
    List<GoldeKeyBase> Gkey = new List<GoldeKeyBase>();
    List<SelverKeyBase> Skey = new List<SelverKeyBase>();

   [SerializeField] int GoldKeys = 0;
   [SerializeField] int silverKeys = 0;


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


    public int GetSilverKeyNum()
    {
        return silverKeys;
    }
    public int GetGoldKeyNum()
    {
        return GoldKeys;
    }

    public void DecreaseGoldKeyNum(int amountOfKeys)
    {
        Gkey.RemoveAt(0);
        Debug.Log("DEC GOLD "+ GoldKeys);
    }
    public void DecreaseSetSilverKeyNum(int amountOfKeys)
    {
        
        Skey.RemoveAt(0);
        Debug.Log("DEC Silver " + silverKeys);
    }
}

