using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;
public class MarketManage : MonoBehaviour
{
    [SerializeField]
    private Ponchos[] ponchos;

    private void Awake()
    {
        Data.nowUsebelPoncho = (Ponchos.PonchosType)PlayerPrefs.GetInt("UsebalePoncho");
        Debug.Log($"You have { ponchos.Length}, now you use {Data.nowUsebelPoncho}");
    }
    // Start is called before the first frame update
    void Start()
    {
        //ChangeSkinOfPoncho();
    }

    // Update is called once per frame
    void Update()
    {
       // ChangeSkinOfPoncho();
    }

    private void ChangeSkinOfPoncho()
    {
        foreach (Ponchos poncho in ponchos)
        {
           
        }
    }
}
