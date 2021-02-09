using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public GameObject prefab;
    public int price;
    public Text priceText;
    MoneyManager moneyManager;

    void Start()
    {
        moneyManager = GameObject.Find("GameManager").GetComponent<MoneyManager>();
        priceText.text = "VAL = " + price.ToString();
    }
    public void CreateAddNode()
    {
        if(moneyManager.coins >= price)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z=0;
            Instantiate(prefab,mousePosition,Quaternion.identity);
            moneyManager.coins -= price;
        }
    }

    public void CreateMinusNode()
    {
        if(moneyManager.coins >= price)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z=0;
            Instantiate(prefab,mousePosition,Quaternion.identity);
            moneyManager.coins -= price;
        }
    }
}
