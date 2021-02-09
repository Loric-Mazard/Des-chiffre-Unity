using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeConnection : MonoBehaviour
{
    public Transform parent;
    public GameObject linePrefab;
    GameObject line;
    int parametre = 0;
    GameObject start;
    public ModeManager modeManager;

    public void CreatConnection(GameObject xNode)
    {
        if(parametre == 0 && xNode.GetComponent<NodeMoveScript>().nbConectionStart < xNode.GetComponent<NodeMoveScript>().nbConectionStartMax)
        {
            start = xNode;
            parametre++;
            start.GetComponent<NodeMoveScript>().contours.SetActive(true);
        }
        else if(parametre == 1 && xNode.GetComponent<NodeMoveScript>().nbConectionEnd < xNode.GetComponent<NodeMoveScript>().nbConectionEndMax && start != xNode)
        {
            bool different = true;
            foreach(GameObject l in xNode.GetComponent<NodeMoveScript>().liens){
                if(l.GetComponent<ConnectionScript>().startPos == xNode && l.GetComponent<ConnectionScript>().endPos == start){
                    different = false;
                }
            }

            if(different)
            {
                line = Instantiate(linePrefab, new Vector3(0,0,0), Quaternion.identity, parent);
                line.GetComponent<ConnectionScript>().startPos = start;
                line.GetComponent<ConnectionScript>().endPos = xNode;
                parametre--;
                start.GetComponent<NodeMoveScript>().contours.SetActive(false);
            }
            else
            {
                parametre = 0;
                start.GetComponent<NodeMoveScript>().contours.SetActive(false);
            }
        }
        else if(xNode.GetComponent<NodeMoveScript>().nbConectionStart == xNode.GetComponent<NodeMoveScript>().nbConectionStartMax
                || xNode.GetComponent<NodeMoveScript>().nbConectionEnd == xNode.GetComponent<NodeMoveScript>().nbConectionEndMax)
        {
            parametre = 0;
            start.GetComponent<NodeMoveScript>().contours.SetActive(false);
        }
    }

    void Update()
    {
        if(modeManager.mode != "Connection" || Input.GetKeyDown(KeyCode.Escape)){
            parametre = 0;
            if(start != null){
                start.GetComponent<NodeMoveScript>().contours.SetActive(false);
            }
        }
    }
}
