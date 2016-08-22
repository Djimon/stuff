using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelMenu : MonoBehaviour
{

    public GameObject LevelContainer;
    public GameObject LevelButton;


	// Use this for initialization
	void Start ()
	{
	    Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
	    foreach (Sprite thumbnail in thumbnails)
	    {
	        GameObject container = Instantiate(LevelButton) as GameObject;
            container.transform.SetParent(LevelContainer.transform);
	        container.GetComponent<Image>().sprite = thumbnail;
	    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
