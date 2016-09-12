using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Click : MonoBehaviour
{
    public Text Life;
    public Text Points;
    //TODO: auslagern in PlayerPrefsManager
    private int clickPower; 
    private int maxHP;
    private int life ;
    public int gold { get; private set; } //PPM

    public void Start()
    {
        Debug.Log("Initilaize...");
        clickPower = 1;
        maxHP = 25;
        life = 25;

        PlayerPrefsManager.SetDifficulty(1f);
        PlayerPrefsManager.SetClickPower(1);
        PlayerPrefsManager.SetGold(0);

    }

    public void Update()
    {
        if (life <= 0)
        {
            maxHP += 5;
            life = maxHP;
            PlayerPrefsManager.AddGold(10); 
        }

        Life.text = "HP: " + life;
        Points.text = PlayerPrefsManager.GetGold().ToString();
    }

    public void Clicked()
    {
        life -= clickPower;
        Update();
    }

}
