using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionScript : MonoBehaviour
{
    public List<Vector2> positions;

    public GameObject startPos;
    public GameObject endPos;
    LineRenderer lineRenderer;
    bool n = true;

    ModeManager modeManager;
    PolygonCollider2D polygoneCollider;

    void Start()
    {
        modeManager = GameObject.Find("GameManager").GetComponent<ModeManager>();
        
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        polygoneCollider = gameObject.AddComponent<PolygonCollider2D>();
    }

    void Update()
    {
        if(startPos != null && endPos != null)
        {
            if(n){
                startPos.GetComponent<NodeMoveScript>().AddConnectionStart(gameObject);
                endPos.GetComponent<NodeMoveScript>().AddConnectionEnd(gameObject);

                positions.Clear();
                positions.Add(startPos.transform.position);
                positions.Add(endPos.transform.position);
                positions.Add(endPos.transform.position);
                positions.Add(startPos.transform.position);

                if(endPos.tag == "Add" || endPos.tag == "Minus" || endPos.tag == "Multiply"){
                    endPos.GetComponent<Calcul>().RemplacementValeur(startPos);
                }else if(endPos.tag == "Finish"){
                    endPos.GetComponent<Calcul>().End(startPos);
                }

                n = false;
            }

            float diffX = endPos.transform.position.x - startPos.transform.position.x;
            float diffY = endPos.transform.position.y - startPos.transform.position.y;
            float rajoutX = diffY / (Mathf.Sqrt(diffX * diffX + diffY * diffY)/ 0.2f);
            float rajoutY = diffX / (Mathf.Sqrt(diffX * diffX + diffY * diffY)/ 0.2f);

            positions[0] = new Vector2(startPos.transform.position.x + rajoutX, startPos.transform.position.y - rajoutY);
            positions[1] = new Vector2(endPos.transform.position.x + rajoutX/2, endPos.transform.position.y - rajoutY/2);
            positions[2] = new Vector2(endPos.transform.position.x - rajoutX/2, endPos.transform.position.y + rajoutY/2);
            positions[3] = new Vector2(startPos.transform.position.x - rajoutX, startPos.transform.position.y + rajoutY);

            float alpha = 1.0f;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(startPos.GetComponent<SpriteRenderer>().color, 0.0f), new GradientColorKey(endPos.GetComponent<SpriteRenderer>().color, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
            lineRenderer.colorGradient = gradient;
            lineRenderer.SetPosition(0,startPos.transform.position);
            lineRenderer.SetPosition(1,endPos.transform.position);
            
            if(modeManager.mode == "Delete"){
                polygoneCollider.enabled = true;
                polygoneCollider.points = positions.ToArray();
            }
            else{
                polygoneCollider.enabled = false;
            }
        }
        else
        {
            Reset();
            Destroy(gameObject);
        }
    }

    public void Reset()
    {
        startPos.GetComponent<NodeMoveScript>().RemoveConnectionStart(gameObject);
        endPos.GetComponent<NodeMoveScript>().RemoveConnectionEnd(gameObject);

        endPos.GetComponent<Calcul>().Delete(startPos);

        Destroy(gameObject);
    }

    public void ResetColateral(GameObject xNode)
    {
        if(xNode == startPos){
            endPos.GetComponent<NodeMoveScript>().RemoveConnectionEnd(gameObject);
        }else{
            startPos.GetComponent<NodeMoveScript>().RemoveConnectionStart(gameObject);
        }

        endPos.GetComponent<Calcul>().Delete(startPos);

        Destroy(gameObject);
    }
}