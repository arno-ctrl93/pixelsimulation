using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Application : MonoBehaviour
{
    
    [SerializeField] public GameObject AgentObject;
    [SerializeField] public int nombreAgent;
    [SerializeField] public Slider Speed;
    [SerializeField] public Text SpeedValue;
    public float speedvalue;
    public System.Random aleatoire = new Random();
    //[SerializeField] public float Speed;
    //private Agent newtestAgent = null;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update
    // is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            
        }
    }

    public void clickButtomStart()
    {
        Debug.Log("Clicked !!");
        GameObject test = transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        //Faire une erreur si pas string
        try
        {
            nombreAgent = int.Parse(test.GetComponent<InputField>().text);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        for (int i = 0; i < nombreAgent; i++)
        {
            
            Vector3 position = new Vector3(aleatoire.Next(20,255),0f,aleatoire.Next(20,143));
            Instantiate(AgentObject,position,Quaternion.identity);

        }
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void switchCamera()
    {
    }

    public void OnValueChanged()
    {
        speedvalue = Speed.value;
        SpeedValue.text =  Speed.value.ToString();
    }
}
