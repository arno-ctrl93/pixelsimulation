using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class AgentApplication: MonoBehaviour
{
    public bool changeDirection = true;
    [SerializeField] public GameObject AgentObject;
    [SerializeField] public float Speed;
    [SerializeField] public GameObject VariaSpeed;
    private Agent newtestAgent = null;
    private Board ecran = new Board(256, 144);
    private Renderer rend;
    
    
    // Start is called before the first frame update
    void Start()
    {

        float test = GameObject.Find("AgentInstance").GetComponent<Application>().speedvalue;
        //Speed = VariaSpeed.value;
        newtestAgent = new Agent(1, AgentObject, test);
        rend = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        newtestAgent.MoveAgent();
        ecran.ChecktheCoord(newtestAgent);
    }

    private void OnTriggerEnter(Collider other)
    {
        AgentApplication script = other.GetComponent<AgentApplication>();
        Agent autreAgent = script.newtestAgent;
        autreAgent.direction = new Direction(-autreAgent.direction.x,-autreAgent.direction.y);
        /*if (script.changeDirection)
    {
        Agent autreAgent = script.newtestAgent;
        autreAgent.direction = changedirection(autreAgent);
        changeDirection = false;
    }*/
        //Debug.Log("new Direction Agent: "+newtestAgent.direction.x+" et y: "+newtestAgent.direction.y);
    }

    private void OnTriggerExit(Collider other)
    {
        int colorChoose = Random.Range(0, 10);
        switch (colorChoose)
        {
            case 0: rend.material.color = Color.white; break;
            case 1: rend.material.color = Color.cyan; break;
            case 2: rend.material.color = Color.blue; break;
            case 3: rend.material.color = Color.black; break;
            case 4: rend.material.color = Color.red; break;
            case 5: rend.material.color = Color.green; break;
            case 6: rend.material.color = Color.grey; break;
            case 7: rend.material.color = Color.magenta; break;
            case 8: rend.material.color = Color.yellow; break;
            case 9: rend.material.color = Color.gray; break;
            
        }
        
    }

    private Direction changedirection(Agent other)
    {
        float x = newtestAgent.direction.x;
        float otherx = other.direction.x;
        float y = newtestAgent.direction.y;
        float othery = other.direction.y;
        //Debug.Log("Direction Agent: "+newtestAgent.direction.x+" et y: "+newtestAgent.direction.y);
        Direction temp = new Direction(other.direction.x+newtestAgent.direction.x,other.direction.y+newtestAgent.direction.y);
        //Debug.Log("temp : "+temp.x+" et "+temp.y);
        if (temp.x == 0)
        {
            x = other.direction.x;
            otherx = newtestAgent.direction.x;
        }

        if (temp.y == 0)
        {
            y = other.direction.y;
            othery = newtestAgent.direction.y;
        }
        this.newtestAgent.direction = new Direction(x,y);
        return new Direction(otherx,othery);
        
    }
}
