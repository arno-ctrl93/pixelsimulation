using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class AgentApplication : MonoBehaviour
{

    // ALL THE DIFFERENT DIRECTION IN TUPPLE

    public Tuple<float, float> N;
    public Tuple<float, float> NE;
    public Tuple<float, float> E;
    public Tuple<float, float> SE;
    public Tuple<float, float> S;
    public Tuple<float, float> SW;
    public Tuple<float, float> W;
    public Tuple<float, float> NW; 


    [SerializeField] public GameObject AgentObject;
    [SerializeField] public GameObject VariaSpeed;
    public Agent newtestAgent = null;
    private Board ecran = new Board(256, 144);
    private Renderer rend;
    private Game game;
    private StartPannel StartPannel;
    public Direction DirectionOfAgent = null;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("AgentInstance").GetComponent<Application>().game;
        StartPannel = GameObject.Find("AgentInstance").GetComponent<Application>().StartPannel;
        newtestAgent = new Agent(1, AgentObject, game.speedofAgent);
        rend = GetComponent<Renderer>();
        if (DirectionOfAgent != null)
            newtestAgent.direction = DirectionOfAgent;
        
        float speed = game.speedofAgent;
        N =  new Tuple<float, float>(speed,0);
        NE =  new Tuple<float, float>(speed,speed);
        E =  new Tuple<float, float>(0,speed);
        SE =  new Tuple<float, float>(-speed,speed);
        S =  new Tuple<float, float>(-speed,0);
        SW =  new Tuple<float, float>(-speed,-speed);
        W =  new Tuple<float, float>(0,-speed);
        NW =  new Tuple<float, float>(speed,-speed);
    }

// Update is called once per frame
    void Update()
    {
        if (game.State is STATE.PLAY)
        {
            newtestAgent.MoveAgent(game.State);
            ecran.ChecktheCoord(newtestAgent);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        AgentApplication script = other.gameObject.GetComponent<AgentApplication>();
        Agent autreAgent = script.newtestAgent;
        autreAgent.direction = new Direction(-autreAgent.direction.x,-autreAgent.direction.y);
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

    public void test(Agent other)
    {
        float speed = game.speedofAgent;
        Tuple<float, float> directionfirst = new Tuple<float, float>(newtestAgent.direction.x, newtestAgent.direction.y);
        Tuple<float, float> directionother = new Tuple<float, float>(other.direction.x, other.direction.y);

        if (Equals(directionfirst,N))
        {

        }
        if (Equals(directionfirst,NE))
        {

        }
        if (Equals(directionfirst,E))
        {

        }
        if (Equals(directionfirst,SE))
        {

        }
        if (Equals(directionfirst,S))
        {
                    
        }
        if (Equals(directionfirst,SW))
        {
                    
        }
        if (Equals(directionfirst,W))
        {
                    
        }
        if (Equals(directionfirst,NW))
        {
                    
        }
    }

    private void ChangeDirectionN(Tuple<float, float> directionfirst)
    { 
        if (Equals(directionfirst,NE))
        {

        }
        if (Equals(directionfirst,E))
        {

        }
        if (Equals(directionfirst,SE))
        {

        }
        if (Equals(directionfirst,S))
        {
                    
        }
        if (Equals(directionfirst,SW))
        {
                    
        }
        if (Equals(directionfirst,W))
        {
                    
        }
        if (Equals(directionfirst,NW))
        {
                    
        }
        
    }
}

