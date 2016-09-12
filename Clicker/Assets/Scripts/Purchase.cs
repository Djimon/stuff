using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Purchase : MonoBehaviour
{

    public Text text;
    public Text price;
    public Text itemName;
    public int indx = 1;
    private ShopItem item;

    public void Start()
    {
        Debug.Log("new Item in Shop");
        Update();
    }

    public void Click()
    {
        Debug.Log("under construction... please Wait some weeks");
        item = GameObject.Find("Shop").GetComponent<Shop>().Items[indx];
        price.text = item.price.ToString();
        //Update();
        if (PlayerPrefsManager.GetGold() < item.price)
        {
            Debug.LogWarning("can't be purchased, too expensive!");
        }
        else
        {
            item.Purchased();
            Debug.Log("purchase: "+price+ " - " + item.price);
        }
       Update();
    }

    // Update is called once per frame
	public void Update ()
	{
	    price.text = item.price.ToString();
        itemName.text = item.itemName;
        text.text = item.item + " + " + item.bonus;
    }
}
