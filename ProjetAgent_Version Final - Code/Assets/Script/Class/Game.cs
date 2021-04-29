using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = System.Random;


public class Game : MonoBehaviour
{
    /* THE CLASS GAME IS COMPOSED BY ALL THE DIFFERENT PANNEL OF THE APP,
     * THE STATE, THE LIST OF AGENT AND ALL INFORMATION IMPORTANT
     * I CREATE THIS CLASS TO CAN CALLED ALL THIS DIFFERENT ELEMENT IN ALL SCRIPT
     */
    public StartPannel Startpannel;
    public PannelAddAgent PannelAddAgent;
    public PannelPause pannelPause;
    public PannelSettings pannelSettings;
    public PannelHelp pannelHelp;
    public STATE State;
    public List<GameObject> listeofAgent;
    public float speedofAgent;
    public int numberofAgent;
    public Board board;
    public Random aleatoire;
    

    // CONSTRUCTOR
    public Game(StartPannel startpannel, PannelAddAgent pannelAddAgent,PannelPause pannelPause, PannelSettings pannelSettings,Board board, PannelHelp pannelHelp)
    {
        this.Startpannel = startpannel;
        this.State = STATE.STOP;
        this.listeofAgent = new List<GameObject>();
        this.PannelAddAgent = pannelAddAgent;
        this.pannelPause = pannelPause;
        this.pannelSettings = pannelSettings;
        this.board = board;
        this.aleatoire = new Random();
        this.pannelHelp = pannelHelp;
    }

    // FUNCTION IS USED TO ADD AN AGENT TO THE LIST OF AGENT
    public void AddAgent(GameObject agent)
    {
        this.listeofAgent.Add(agent);
        this.numberofAgent ++;
    }
    
    // GETTER AND SETTER

    public StartPannel Startpannel1
    {
        get => Startpannel;
        set => Startpannel = value;
    }

    public STATE State1
    {
        get => State;
        set => State = value;
    }


    public float SpeedofAgent
    {
        get => speedofAgent;
        set => speedofAgent = value;
    }

    public int NumberofAgent
    {
        get => numberofAgent;
        set => numberofAgent = value;
    }
}