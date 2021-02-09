using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructorScript : MonoBehaviour
{
    public GameObject startPrefab;
    public GameObject cache;
    public Text valueText;
    public int value;

    void Start()
    {
        valueText.text = "VAL = " + value.ToString();
    }
    public void CreateStartNode()
    {
        if(!cache.activeInHierarchy)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z=0;
            GameObject start = Instantiate(startPrefab,mousePosition,Quaternion.identity);
            start.GetComponent<Calcul>().valeur = value;
            start.GetComponent<NodeMoveScript>().cache = cache;
            cache.SetActive(true);
        }
    }
}
