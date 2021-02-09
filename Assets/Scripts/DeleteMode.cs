using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMode : MonoBehaviour
{
    ModeManager modeManager;

    void Awake()
    {
        modeManager = GameObject.Find("GameManager").GetComponent<ModeManager>();
    }
    void OnMouseDown()
    {
        if(modeManager.mode == "Delete")
        {
            if(tag == "Line")
            {
                gameObject.GetComponent<ConnectionScript>().Reset();
            }else{
                gameObject.GetComponent<NodeMoveScript>().Reset();
            }
        }
    }
}
