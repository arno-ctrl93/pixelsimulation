using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class AgentApplication : MonoBehaviour
{

    // THIS OPTION USE TO DEBUG THE CODE

    [SerializeField] public float posx;
    [SerializeField] public float posy;
    [SerializeField] public bool IsInAGroup;
    
    // ALL THE DIFFERENT DIRECTION POSSIBLE

    public Direction N;
    public Direction NE;
    public Direction E;
    public Direction SE;
    public Direction S;
    public Direction SW;
    public Direction W;
    public Direction NW;

    // BOOLEAN USED TO KNOW WHEN THE GAME IS LAUNCHED
    public bool StartFonctionIsFinish = false;

    // PARAMETER TO DEFINE THE AGENT 
    [SerializeField] public GameObject AgentObject;
    [SerializeField] public GameObject VariaSpeed;
    [SerializeField] public GameObject Trigger1;
    public Agent newtestAgent = null;
    private Board ecran; //= new Board(256, 144);
    private Renderer rend;
    private Game game;
    private StartPannel StartPannel;
    
    // Using for synchronise pannel add agent and the creation of agent
    public Direction DirectionOfAgent = null;
    public int IDofAgent = 0;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("AgentInstance").GetComponent<Application>().game;
        ecran = game.board;
        StartPannel = GameObject.Find("AgentInstance").GetComponent<Application>().StartPannel;
        newtestAgent = new Agent(1, AgentObject, game.speedofAgent,ecran, game.aleatoire);
        rend = GetComponent<Renderer>();
        if (DirectionOfAgent != null)
            newtestAgent.direction = DirectionOfAgent;
        if (IDofAgent != 0)
        {
            newtestAgent.id = IDofAgent;
        }
        float speed = game.speedofAgent;
        N = new Direction(speed, 0);
        NE = new Direction(speed, speed);
        E = new Direction(0, speed);
        SE = new Direction(-speed, speed);
        S = new Direction(-speed, 0);
        SW = new Direction(-speed, -speed);
        W = new Direction(0, -speed);
        NW = new Direction(speed, -speed);
        StartFonctionIsFinish = true;
    }

    // Update is called once per frame
    void Update()
    {
        IsInAGroup = newtestAgent.IsInGroup;
        posx = newtestAgent.posx;
        posy = newtestAgent.posy;
        
        // IF THE GAME LAUNCH, YOU CAN MOVE THE AGENT 
        if (game.State is STATE.PLAY)
        {
            ecran.ChecktheCoord(newtestAgent,game.speedofAgent);
            newtestAgent.MoveAgent(game.State);
        }
    }

    // FUNCTION IS USED WHEN TWO AGENTS ARE A COLLISION
    private void OnTriggerEnter(Collider other)
    {
        if (newtestAgent.futurnewDirection != null)
        {
            newtestAgent.direction = newtestAgent.futurnewDirection;
        }
        else
        {
            if (newtestAgent.direction == N)
            {
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == SW)
                {
                    newtestAgent.direction = W;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = NW;
                    return;
                }
                
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == SE)
                {
                    newtestAgent.direction = E;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = NE;
                    return;
                }
            }
            if (newtestAgent.direction == E)
            {
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == SW)
                {
                    newtestAgent.direction = S;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = SE;
                    return;
                }
                
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == NW)
                {
                    newtestAgent.direction = N;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = NE;
                    return;
                }
            }
            if (newtestAgent.direction == S)
            {
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == NE)
                {
                    newtestAgent.direction = E;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = SE;
                    return;
                }
                
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == NW)
                {
                    newtestAgent.direction = W;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = SE;
                    return;
                }
            }
            if (newtestAgent.direction == W)
            {
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == SE)
                {
                    newtestAgent.direction = S;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = SW;
                    return;
                }
                
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == NE)
                {
                    newtestAgent.direction = N;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = NW;
                    return;
                }
            }
            if (newtestAgent.direction == SW)
            {
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == N)
                {
                    newtestAgent.direction = NW;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = W;
                    return;
                }
                
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == E)
                {
                    newtestAgent.direction = SE;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = S;
                    return;
                }
            }
            if (newtestAgent.direction == SE)
            {
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == N)
                {
                    newtestAgent.direction = NE;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = E;
                    return;
                }
                
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == W)
                {
                    newtestAgent.direction = SW;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = S;
                    return;
                }
            }
            if (newtestAgent.direction == NW)
            {
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == E)
                {
                    newtestAgent.direction = NE;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = N;
                    return;
                }
                
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == S)
                {
                    newtestAgent.direction = SE;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = W;
                    return;
                }
            }
            if (newtestAgent.direction == NE)
            {
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == S)
                {
                    newtestAgent.direction = SE;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = E;
                    return;
                }
                
                if (other.GetComponent<AgentApplication>().newtestAgent.direction == W)
                {
                    newtestAgent.direction = NW;
                    other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = N;
                    return;
                }
            }
            
            Direction temp = newtestAgent.direction;
            if (other.GetComponent<AgentApplication>())
            {
                newtestAgent.direction = other.GetComponent<AgentApplication>().newtestAgent.direction;
                other.GetComponent<AgentApplication>().newtestAgent.futurnewDirection = temp;
            }

        }
    }
    
    // FUNCTION IS USED AFTER A COLLISION TO CHANGE THE COLOR OF AGENT
    private void OnTriggerExit(Collider other)
    {
        int colorChoose = Random.Range(0, 10);
        switch (colorChoose)
        {
            case 0:
                rend.material.color = Color.white;
                break;
            case 1:
                rend.material.color = Color.cyan;
                break;
            case 2:
                rend.material.color = Color.blue;
                break;
            case 3:
                rend.material.color = Color.black;
                break;
            case 4:
                rend.material.color = Color.red;
                break;
            case 5:
                rend.material.color = Color.green;
                break;
            case 6:
                rend.material.color = Color.grey;
                break;
            case 7:
                rend.material.color = Color.magenta;
                break;
            case 8:
                rend.material.color = Color.yellow;
                break;
            case 9:
                rend.material.color = Color.gray;
                break;

        }

    }

    // FUNCTION IS USED TO INTERACT WITH THE OTHER AGENTS
    public void OnTrigger1(GameObject other)
    {
        if (StartFonctionIsFinish && other.GetComponent<AgentApplication>())
        {
            //Debug.Log("Activation by trigger1");
            //Debug.Log(other.name);
            Agent otheragent = other.GetComponent<AgentApplication>().newtestAgent;
            //Debug.Log("Voici l'id de l'agent qui rentre: "+otheragent.id);
            if (!otheragent.IsInGroup && !newtestAgent.IsInGroup)
            {
                otheragent.direction = newtestAgent.direction;
                newtestAgent.IsInGroup = true;
                otheragent.IsInGroup = true;

                newtestAgent.HowManyInGroup++;
                otheragent.HowManyInGroup++;
                return;
            }

            if (!otheragent.IsInGroup && newtestAgent.IsInGroup)
            {
                otheragent.direction = newtestAgent.direction;
                otheragent.IsInGroup = true;

                otheragent.HowManyInGroup++;
                newtestAgent.HowManyInGroup++;
                return;
            }

            if (otheragent.IsInGroup && newtestAgent.IsInGroup)
            {
                if (otheragent.HowManyInGroup >= newtestAgent.HowManyInGroup)
                {
                    newtestAgent.direction = otheragent.direction;
                    otheragent.HowManyInGroup++;
                    newtestAgent.HowManyInGroup = otheragent.HowManyInGroup;
                }
                else
                {

                    otheragent.direction = newtestAgent.direction;
                    newtestAgent.HowManyInGroup++;
                    otheragent.HowManyInGroup = newtestAgent.HowManyInGroup;
                }
            }
        }
    }
}
