using System;
using UnityEngine;
using System.Collections;

public class ShopItem
{
    public enum Itemtype
    {
        none,
        Attack,
        Collect,
        NrgSafe,
        NrgEffi,
        Turret
    }

    public string itemName;
    public int purchased ;
    public int price { get; private set; } 
    public int bonus { get; private set; }
    private Sprite icon;
    public Itemtype item { get; private set; }

    /// <summary>
    /// constructor of ShopItem
    /// </summary>
    /// <param name="name">item's itemName</param>
    /// <param name="type">type of buff</param>
    /// <param name="cost">price of the item</param>
    /// <param name="effect">amount by which the buff is changed</param>
    public ShopItem(string name, string type, int cost, int effect, Sprite img)
    {
        itemName = name;
        price = cost;
        bonus = effect;
        //icon = img;
        
        item = (Itemtype) Enum.Parse(typeof(Itemtype), type);
        Debug.Log(item.ToString());
        if (!Enum.IsDefined(typeof(Itemtype), item))
        {
            Debug.LogError(item +" is not a member of Enum: Itemtype");
            item = Itemtype.none;
            itemName += " (invalid)";
            bonus = 0;
            price = 0;
        }

        Debug.Log("item placed");
    }

    /// <summary>
    /// Buy Item and set all values
    /// </summary>
    public void Purchased()
    {
        purchased += 1;
        
        
        
        //TODO: implement correctly! atm just Debug
        switch (item)
        {
            case Itemtype.none: Debug.LogError("Didn't buy anything");
                break;
            case Itemtype.Attack: //beispiel
                PlayerPrefsManager.AddClickPower(bonus);
                PlayerPrefsManager.SubGold(price);
                break;
            case Itemtype.Collect:
                //PlayerPrefsManager.AddCollectPower(bonus);
                PlayerPrefsManager.SubGold(price);
                break;
            case Itemtype.NrgEffi:
                
                break;
            case Itemtype.NrgSafe:
                
                break;
            case Itemtype.Turret:
                
                break;
        }
        price += (int) (price *0.25f *purchased);

        Debug.Log("buyed: " + price );
    }


}
