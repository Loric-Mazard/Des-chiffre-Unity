using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateLevel : MonoBehaviour
{
    public GameObject endPrefab;

    public GameObject constructorPrefab;
    Transform parentConstructor;

    public int level = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void NextLevel(){
        level++;
        SceneManager.LoadScene("SampleScene");
        CreationLevel();
    }

    void CreationLevel()
    {
        if(level == 1)
        {
            parentConstructor = GameObject.Find("ConstructorPanel").transform;
            GameObject.Find("ConstructorPanel").SetActive(false);
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject start = Instantiate(constructorPrefab,new Vector3(7,-i*1.7f+3,0),Quaternion.identity,parentConstructor);
            start.GetComponent<ConstructorScript>().value = Random.Range(0,10);
        }
        GameObject end = Instantiate(endPrefab,new Vector3(0,0,0),Quaternion.identity);
        end.GetComponent<Calcul>().resultat = 13;
    }
}
