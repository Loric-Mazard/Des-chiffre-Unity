using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public string mode = "Move";

    public GameObject shop;
    public GameObject constructor;

    public void MoveMode()
    {
        mode = "Move";
        shop.SetActive(false);
        constructor.SetActive(false);
    }

    public void ConnectionMode()
    {
        mode = "Connection";
        shop.SetActive(false);
        constructor.SetActive(false);
    }

    public void DeleteMode()
    {
        mode = "Delete";
        shop.SetActive(false);
        constructor.SetActive(false);
    }

    public void ShopMode()
    {
        mode = "Shop";
        shop.SetActive(true);
        constructor.SetActive(false);
    }

    public void ConstructorMode()
    {
        mode = "Constructor";
        shop.SetActive(false);
        constructor.SetActive(true);
    }
}
