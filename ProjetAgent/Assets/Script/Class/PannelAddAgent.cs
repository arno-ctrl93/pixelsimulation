using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class PannelAddAgent : UserInterface
{
    public InputField IDnumber;
    public InputField PosX;
    public InputField PosY;
    public Dropdown ChooseDirection;
    public Button trybutton;
    public Button ApplyButton;

    public PannelAddAgent(GameObject pannelObject, InputField dnumber, InputField posX, InputField posY, Dropdown chooseDirection, Button trybutton, Button applyButton) 
        : base(pannelObject)
    {
        this.IDnumber = dnumber;
        this.PosX = posX;
        this.PosY = posY;
        this.ChooseDirection = chooseDirection;
        this.trybutton = trybutton;
        this.ApplyButton = applyButton;
    }
    
    

    public InputField Dnumber
    {
        get => IDnumber;
        set => IDnumber = value;
    }

    public InputField PosX1
    {
        get => PosX;
        set => PosX = value;
    }

    public InputField PosY1
    {
        get => PosY;
        set => PosY = value;
    }

    public Dropdown ChooseDirection1
    {
        get => ChooseDirection;
        set => ChooseDirection = value;
    }

    public Button Trybutton
    {
        get => trybutton;
        set => trybutton = value;
    }

    public Button ApplyButton1
    {
        get => ApplyButton;
        set => ApplyButton = value;
    }

    public GameObject PannelObject1
    {
        get => PannelObject;
        set => PannelObject = value;
    }
}