using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelMenu : MonoBehaviour
{

    public GameObject Container;
    public GameObject ItemButton;


	// Use this for initialization
	void Start ()
	{
	    Sprite[] thumbnails = Resources.LoadAll<Sprite>("Items");
	    foreach (Sprite thumbnail in thumbnails)
	    {
	        GameObject Item = Instantiate(ItemButton) as GameObject;
            Item.transform.SetParent(Container.transform);
	        Item.GetComponentInChildren<Image>().sprite = thumbnail;
	    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
