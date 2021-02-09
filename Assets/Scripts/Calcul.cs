using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calcul : MonoBehaviour
{
    public int valeur;
    public GameObject n1;
    public GameObject n2;
    public int resultat;
    public GameObject textValeur;
    CreateLevel createLevel;

    void Start()
    {
        createLevel = GameObject.Find("LevelManager").GetComponent<CreateLevel>();
    }

    void Update()
    {
        if(tag == "Finish"){
            textValeur.GetComponent<TextMesh>().text = resultat.ToString();
        }else{
            textValeur.GetComponent<TextMesh>().text = valeur.ToString();
        }
        

        if(tag == "Add" && n1 != null && n2 != null)
        {
            valeur = n1.GetComponent<Calcul>().valeur + n2.GetComponent<Calcul>().valeur;
        }
        if(tag == "Minus" && n1 != null && n2 != null)
        {
            valeur = n1.GetComponent<Calcul>().valeur - n2.GetComponent<Calcul>().valeur;
        }
        if(tag == "Multiply" && n1 != null && n2 != null)
        {
            valeur = n1.GetComponent<Calcul>().valeur * n2.GetComponent<Calcul>().valeur;
        }
        if(tag == "Finish" && n1 != null)
        {
            valeur = n1.GetComponent<Calcul>().valeur;
        }
        if(n1 == null && n2 != null){
            n1 = n2;
            n2 = null;
        }
    }

    public void RemplacementValeur(GameObject casePrecedante)
    {
        if(n1 == null){
            n1 = casePrecedante;
        }else if(n2 == null){
            n2 = casePrecedante;
        }
    }

    public void End(GameObject casePrecedante)
    {
        n1 = casePrecedante;
        if(casePrecedante.GetComponent<Calcul>().valeur == resultat)
        {
            createLevel.NextLevel();
        }
    }

    public void Delete(GameObject lienSupprime)
    {
        valeur = 0;
        if(n1 == lienSupprime){
            n1 = null;
        }else{
            n2 = null;
        }
    }
}
