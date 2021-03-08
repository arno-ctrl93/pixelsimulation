using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class PannelSettings : UserInterface
{
    public Dropdown Resolution;
    public Toggle Fullscreen;
    public Dropdown GraphicsLevel;
    public Slider Volume;
    public Button back;

    public PannelSettings(GameObject pannelObject, Dropdown resolution, Toggle fullscreen, Dropdown graphicsLevel, Slider volume,Button back) 
        : base(pannelObject)
    {
        Resolution = resolution;
        Fullscreen = fullscreen;
        GraphicsLevel = graphicsLevel;
        Volume = volume;
        this.back = back;
    }
}