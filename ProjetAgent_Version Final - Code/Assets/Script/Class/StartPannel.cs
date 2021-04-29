﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

// CLASS TO DEFINE THE PANNEL OF START
public class StartPannel : UserInterface
{
    public Text InputText;
    public InputField Square;
    public Button Start;
    public Slider Speed;
    public Image Logo;
    public Text ValueSpeed;
    public Button helpbutton;
    public InputField Board_X;
    public InputField Board_Y;
    public Button Exit;

    public StartPannel(GameObject pannelObject, Text inputText, InputField square, Button start, Slider speed, Image logo, Text valueSpeed, 
        Button helpbutton, InputField boardX,InputField boardY,Button exit) 
        : base(pannelObject)
    {
        this.InputText = inputText;
        this.Square = square;
        this.Start = start;
        this.Speed = speed;
        this.Logo = logo;
        this.ValueSpeed = valueSpeed;
        this.helpbutton = helpbutton;
        this.Board_X = boardX;
        this.Board_Y = boardY;
        this.Exit = exit;
    }
    
    public Text InputText1
    {
        get => InputText;
        set => InputText = value;
    }

    public InputField Square1
    {
        get => Square;
        set => Square = value;
    }

    public Button Start1
    {
        get => Start;
        set => Start = value;
    }

    public Slider Speed1
    {
        get => Speed;
        set => Speed = value;
    }

    public Image Logo1
    {
        get => Logo;
        set => Logo = value;
    }

    public Text ValueSpeed1
    {
        get => ValueSpeed;
        set => ValueSpeed = value;
    }

    public GameObject PannelObject1
    {
        get => PannelObject;
        set => PannelObject = value;
    }

}