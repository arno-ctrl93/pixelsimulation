using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = System.Random;


public class Game : MonoBehaviour
{
    public StartPannel Startpannel;
    public PannelAddAgent PannelAddAgent;
    public PannelPause pannelPause;
    public PannelSettings pannelSettings;
    public STATE State;
    public List<GameObject> listeofAgent;
    public float speedofAgent;
    public int numberofAgent;
    

    public Game(StartPannel startpannel, PannelAddAgent pannelAddAgent,PannelPause pannelPause, PannelSettings pannelSettings)
    {
        this.Startpannel = startpannel;
        this.State = STATE.STOP;
        this.listeofAgent = new List<GameObject>();
        this.PannelAddAgent = pannelAddAgent;
        this.pannelPause = pannelPause;
        this.pannelSettings = pannelSettings;
    }

    public void AddAgent(GameObject agent)
    {
        this.listeofAgent.Add(agent);
        this.numberofAgent ++;
    }

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