using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

// CLASS TO DEFINE THE PANNEL TO PAUSE
public class PannelPause : UserInterface
{
    public Button play;
    public Button option;
    public Button quit;

    public PannelPause(GameObject pannelObject, Button play, Button option, Button quit) 
        : base(pannelObject)
    {
        this.play = play;
        this.option = option;
        this.quit = quit;
    }
}