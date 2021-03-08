using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class Agent : MonoBehaviour
{
    Random aleatoire = new Random();
    public int id;
    public float posx;
    public float posy;
    public Direction direction;
    public GameObject Object;


    public Agent(int id, int posx, int posy, Direction direction, GameObject GameObject)
    {
        this.id = id;
        this.posx = posx;
        this.posy = posy;
        this.direction = direction;
        this.Object = GameObject;
    }
    
    public Agent(int id,int posx,int posy,float speed, GameObject Object) {
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
        //creationgameobject();
    }

    public Agent(int id, GameObject Object, float speed){
        this.id = id;
        this.posx = aleatoire.Next(1, 255); //100 = max-min+1 and 1 = min
        this.posy = aleatoire.Next(1, 143); //100 = max-min+1 and 1 = min
        Direction[] directionpossible =
        {
            new Direction(speed, 0), new Direction(0, speed), new Direction(-speed, 0), new Direction(0, -speed),
            new Direction(speed, speed), new Direction(speed, -speed), new Direction(-speed, speed),
            new Direction(-speed, -speed)
        };
        int nombre = aleatoire.Next(directionpossible.Length - 1);
        this.direction = directionpossible[nombre];
        //Debug.Log("Nombre Random: "+nombre);
        //Debug.Log("Direction "+this.direction.x+" et "+this.direction.y+"\n");
        this.Object = Object;
    }
	
    public void MoveAgent(STATE state) {
        if (state is STATE.PLAY)
        {
            this.Object.transform.Translate(direction.x,0,direction.y);
            this.posx = Object.transform.position.x;
            this.posy = Object.transform.position.z;
        }
    }
	
    public void PrintPosition() {
        //Debug.Log("Position of Agent x: "+this.posx+" y: "+this.posy +"\n");
    }
}

