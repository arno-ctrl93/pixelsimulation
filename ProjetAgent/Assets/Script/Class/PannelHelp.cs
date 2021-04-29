using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

// CLASS TO DEFINE THE PANNEL OF SETTINGS
public class PannelHelp : UserInterface
{
    public Image Background;
    public Text titel;
    public Text description;
    public Button buttonQuit;

    public PannelHelp(GameObject pannelObject, Image background, Text titel, Text description, Button buttonQuit) : base(pannelObject)
    {
        Background = background;
        this.titel = titel;
        this.description = description;
        this.buttonQuit = buttonQuit;
    }
    
}