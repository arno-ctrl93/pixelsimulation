using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class Agent : MonoBehaviour
{
    //CREATE RANDOM NUMBER
    /* THE CLASS AGENT IS COMPOSED BY
     * Int id  = Use to identify the agent
     * Float posx and posy = define the position of agent in the board
     * Direction direction = is use to know the next position of the agent (the class direction
     * is explain on the other script)
     * The other paramater is used by the function of interaction  
     */
    public int id;
    public float posx;
    public float posy;
    public Direction direction;
    public GameObject Object;
    public Direction futurnewDirection;
    //TO CREATE INTERACTION BETWEEN THE AGENT
    public bool IsInGroup;
    public GameObject Trigger1;
    public int HowManyInGroup;
    

    // CONSTRUCTOR I
    public Agent(int id, int posx, int posy, Direction direction, GameObject GameObject, Random random)
    {
        this.id = id;
        this.posx = posx;
        this.posy = posy;
        this.direction = direction;
        this.Object = GameObject;
        this.futurnewDirection = null;
        this.IsInGroup = false;
        this.HowManyInGroup = 0;
    }
    
    // CONSTRUCTOR II
    public Agent(int id,int posx,int posy,float speed, GameObject Object, Random aleatoire) {
        this.id = id;
        this.posx = posx;
        this.posy = posy;
        Direction[] directionpossible =
        {
            new Direction(speed, 0), new Direction(0, speed), new Direction(-speed, 0), new Direction(0, -speed),
            new Direction(speed, speed), new Direction(speed, -speed), new Direction(-speed, speed),
            new Direction(-speed, -speed)
        };
        this.direction = directionpossible[aleatoire.Next(directionpossible.Length-1)];
        this.Object = Object;
        this.IsInGroup = false;
        this.HowManyInGroup = 0;
        //creationgameobject();
    }

    // CONSTRUCTOR III
    public Agent(int id, GameObject Object, float speed, Board board, Random aleatoire){
        this.id = id;
        this.posx = aleatoire.Next(1, board.sizex-1); //100 = max-min+1 and 1 = min
        this.posy = aleatoire.Next(1, board.sizey-1); //100 = max-min+1 and 1 = min
        Direction[] directionpossible =
        {
            new Direction(speed, 0), new Direction(0, speed), new Direction(-speed, 0), new Direction(0, -speed),
            new Direction(speed, speed), new Direction(speed, -speed), new Direction(-speed, speed),
            new Direction(-speed, -speed)
        };
        int nombre = aleatoire.Next(directionpossible.Length - 1);
        this.direction = directionpossible[nombre];
        this.Object = Object;
        this.IsInGroup = false;
        this.HowManyInGroup = 0;
    }
	
    // FONCTION CALLED EACH FRAME TO MOVE AGENT
    public void MoveAgent(STATE state) {
        if (state is STATE.PLAY)
        {
            this.Object.transform.Translate(direction.x,0,direction.y);
            this.posx = Object.transform.position.x;
            this.posy = Object.transform.position.z;
        }
    }
	
    // HELP FONCTIONS
    public void PrintPosition() {
        //Debug.Log("Position of Agent x: "+this.posx+" y: "+this.posy +"\n");
    }
}

