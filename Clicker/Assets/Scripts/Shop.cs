using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shop : MonoBehaviour
{

    public Text Points;
    public GameObject panel;
    public ShopItem[] Items;
    private Sprite[] ItemSprites;
    private int power;
    private bool isLoaded = false;

    void LoadItems()
    {
        ItemSprites = new Sprite[10]; // ersatz, bis loadAll funzt
        //ItemSprites = Resources.LoadAll("Items"); //TODO: fix
        Items = new ShopItem[10];
        //beliebig erweiterbar
        Items[0] = new ShopItem("Krafttrank","Attack",5,2,ItemSprites[0]);
        Items[1] = new ShopItem("Krafttrank+", "Attack", 10, 5, ItemSprites[1]);
        Items[2] = new ShopItem("Energietrank", "NrgEffi", 10, -2, ItemSprites[2]);
        Items[3] = new ShopItem("Powrtrank", "Attack", 25, 10, ItemSprites[3]);
        Items[4] = new ShopItem("Megatrank", "Attack", 50, 20, ItemSprites[4]);
        Items[5] = new ShopItem("Ultratrank", "Attack", 100, 50, ItemSprites[5]);
        Items[6] = new ShopItem("Gigatrank", "Attack", 1000, 500, ItemSprites[6]);
        Items[7] = new ShopItem("Gasfalle", "Turret", 25, 10, ItemSprites[7]);
        Items[8] = new ShopItem("Giftfalle", "Turret", 25, 10, ItemSprites[8]);
        Items[9] = new ShopItem("Spikes", "Turret", 25, 10, ItemSprites[9]);

        foreach (ShopItem tem in Items)
        {
            // Create Button (prefab) wie in levelMneü-Code von pharao
            //GameObject x;
            //x.GetComponent<Purchase>().Update();
        }
    }

    // Update is called once per frame
	public void Update ()
	{
	    Points.text = PlayerPrefsManager.GetGold().ToString();
	    foreach (ShopItem i in Items)
	    {
            // update button
	    }
	}

    public void Clicked()
    {
        if (!isLoaded)
        {
            Debug.Log("first time");
            LoadItems(); //Invoke?
            isLoaded = false;
        }

        //PlayAnimation(); 
        Update();
        panel.SetActive(true);
        
    }

    public void Closed()
    {
        panel.SetActive(false);
        GameObject.Find("Click").GetComponent<Click>().Update();
    }
}
