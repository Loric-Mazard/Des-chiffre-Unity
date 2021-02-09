using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text money;
    public int coins = 200;

    void FixedUpdate()
    {
        money.text = coins.ToString();
    }
}
