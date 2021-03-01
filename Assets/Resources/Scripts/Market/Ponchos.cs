using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using System.Linq;
public class Ponchos : MonoBehaviour
{
    [SerializeField]
    private int price;
    public PonchosType ponchoType;
    [SerializeField]
    private bool bought;

    private AudioSource buySound;
    [SerializeField]
    private TMP_Text buyText;

    public enum PonchosType
    {
        basePoncho,
        greenPoncho,
        mochaPoncho,
        pinkPoncho,
        GoodBadEvilPoncho
    }
    private void Awake()
    {
        buySound = GetComponent<AudioSource>();
    }
    public void Start()
    {
        //PlayerPrefs.DeleteAll();
        bought = PlayerPrefs.GetInt($"Bought{this.ponchoType.ToString().ToUpper()}") != 0;
        if (!bought)
        {
            buyText.text = $"price: {price}";
        } else
        {
            buyText.text = "bought";
        }
    }
    public void Buy()
    {
        if (bought) { Use(); return; }
        if(price <= PlayerPrefs.GetInt("BottlesScore"))
        {
            buySound.Play();
            PlayerPrefs.SetInt($"Bought{this.ponchoType.ToString().ToUpper()}", (true ? 1 : 0));
            Debug.Log($"Bought = {bought}, used func");

            buyText.text = "bought";
            bought = PlayerPrefs.GetInt($"Bought{this.ponchoType.ToString().ToUpper()}") != 0;
            PlayerPrefs.SetInt("BottlesScore", PlayerPrefs.GetInt("BottlesScore") - price);
        }
    }

    private void Use()
    {
        if (!bought) return;
        PlayerPrefs.SetInt("UsebalePoncho", (int)(this.ponchoType));
        Data.nowUsebelPoncho = (PonchosType)PlayerPrefs.GetInt("UsebalePoncho");
    }
}
