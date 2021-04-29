﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

// CLASS TO DEFINE THE USER INTERFACE ALL THE OTHER PANNELS HERITATE OF THIS CLASS
public class UserInterface : MonoBehaviour
{
    public GameObject PannelObject;

    public UserInterface (GameObject pannelObject)
    {
        this.PannelObject = pannelObject;
    }

    public UserInterface()
    {
        Console.WriteLine("ERROR");
    }
    
    public GameObject O
    {
        get => PannelObject;
        set => PannelObject = value;
    }

    public void HidePannel()
    {
        this.PannelObject.SetActive(false);
    }

    public void ShowPannel()
    {
        this.PannelObject.SetActive(true);
    }
        

    
}