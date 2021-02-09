using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMoveScript : MonoBehaviour
{
    public int nbConectionStart = 0;
    public int nbConectionStartMax;
    public int nbConectionEnd = 0;
    public int nbConectionEndMax;
    public List<GameObject> liens = new List<GameObject>();
    public GameObject cache;
    bool canMove = false;
    ModeManager modeManager;
    NodeConnection nodeConnection;
    MoneyManager moneyManager;
    string mode;

    public GameObject contours;

    void Awake()
    {
        moneyManager = GameObject.Find("GameManager").GetComponent<MoneyManager>();
        modeManager = GameObject.Find("GameManager").GetComponent<ModeManager>();
        nodeConnection = GameObject.Find("GameManager").GetComponent<NodeConnection>();
        if(modeManager.mode == "Shop"){
            canMove = true;
            mode = "Shop";
        }else if(modeManager.mode == "Constructor"){
            canMove = true;
            mode = "Constructor";
        }
    }

    void Update()
    {
        if(canMove)
        {
            if(mode == "Move" || mode == "Shop" || mode == "Constructor")
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z=0;
                transform.position = mousePosition;
            }
        }
    }

    public void AddConnectionEnd(GameObject lien)
    {
        nbConectionEnd++;
        liens.Add(lien);
    }

    public void AddConnectionStart(GameObject lien)
    {
        nbConectionStart++;
        liens.Add(lien);
    }

    public void RemoveConnectionEnd(GameObject lien)
    {
        nbConectionEnd--;
        liens.Remove(lien);
    }

    public void RemoveConnectionStart(GameObject lien)
    {
        nbConectionStart--;
        liens.Remove(lien);
    }

    public void Reset()
    {
        foreach(GameObject l in liens){
            l.GetComponent<ConnectionScript>().ResetColateral(gameObject);
        }
        if(gameObject.tag == "Add"){
            moneyManager.coins += 50;
        }else if(gameObject.tag == "Minus"){
            moneyManager.coins += 60;
        }else if(gameObject.tag == "Multiply"){
            moneyManager.coins += 70;
        }
        
        if(cache != null){
            cache.SetActive(false);
        }

        Destroy(gameObject);
    }

    void OnMouseDown()
    {
        mode = modeManager.mode;
        if(mode == "Move"){
            canMove = true;
        }else if(mode == "Shop"){
            canMove = false;
        }else if(mode == "Constructor"){
            canMove = false;
        }else if(mode == "Connection")
        {
            nodeConnection.CreatConnection(gameObject);
        }
    }

    void OnMouseUp()
    {
        if(mode == "Move"){
            canMove = false;
        }
    }
}
