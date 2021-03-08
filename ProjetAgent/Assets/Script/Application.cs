using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Random = System.Random;


public enum STATE
{
    PLAY,
    STOP,
    PAUSE,
};
public class Application : MonoBehaviour
{

    [SerializeField] private GameObject or;
    private GameObject temp;
    
    //Windows for error
    [SerializeField] public GameObject ErrorWindows;
    
    //TO Initialize the StartPannel Class
    
    [SerializeField] public Text S_InputText;
    [SerializeField] public InputField S_Square;
    [SerializeField] public Button S_StartButton;
    [SerializeField] public Slider S_Speed;
    [SerializeField] public Image S_Logo;
    [SerializeField] public Text S_ValueSpeed;
    [SerializeField] public GameObject S_gameobject;
    public StartPannel StartPannel;
    
    // TO Initialize the Game Class
    public Game game;
    
    // To Initialize the PannelAddAgent Class

    public PannelAddAgent PannelAddAgent;
    
    [SerializeField] public InputField A_IDnumber;
    [SerializeField] public InputField A_PosX;
    [SerializeField] public InputField A_PosY;
    [SerializeField] public Dropdown A_ChooseDirection;
    [SerializeField] public Button A_trybutton;
    [SerializeField] public Button A_ApplyButton;
    [SerializeField] public GameObject A_gameobject;

    //To initialize the PausePannel Class

    [SerializeField] public Button P_Play;
    [SerializeField] public Button P_Option;
    [SerializeField] public Button P_Quit;
    [SerializeField] public GameObject P_gameobject;
    public PannelPause Pannelpause;

    //TO initialize the SettingsPannel Class
    [SerializeField] public Dropdown S_Resolution;
    [SerializeField] public Toggle S_Toggle;
    [SerializeField] public Dropdown S_Graphics;
    [SerializeField] public Slider S_Volume;
    [SerializeField] public Button S_back;
    [SerializeField] public GameObject Settings_gameobject;
    public PannelSettings pannelSettings;
    
    //Audio Mixer
    public AudioMixer audioMixer;
    //Resolution list
    private Resolution[] resolutions;
    

    [SerializeField] public GameObject AgentObject;
    [SerializeField] public int nombreAgent;
    public System.Random aleatoire = new Random();
    //[SerializeField] public float Speed;
    //private Agent newtestAgent = null;
    // Start is called before the first frame update
    void Start()
    {
        
        // Initialization and creation of the differents class
        StartPannel = new StartPannel(S_gameobject,S_InputText,S_Square,S_StartButton,S_Speed,S_Logo,S_ValueSpeed); 
        PannelAddAgent = new PannelAddAgent(A_gameobject,A_IDnumber,A_PosX,A_PosY,A_ChooseDirection,A_trybutton,A_ApplyButton);
        Pannelpause = new PannelPause(P_gameobject,P_Play,P_Option,P_Quit); 
        pannelSettings = new PannelSettings(Settings_gameobject,S_Resolution,S_Toggle,S_Graphics,S_Volume,S_back);
        game = new Game(StartPannel,PannelAddAgent,Pannelpause,pannelSettings);
        game.speedofAgent = 0.5f;
        
        //Management of different pannel
        StartPannel.ShowPannel();
        Pannelpause.HidePannel();
        PannelAddAgent.HidePannel();
        pannelSettings.HidePannel();
        
        //Mange the resolution for option menu
        resolutions = Screen.resolutions;
        pannelSettings.Resolution.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }
        pannelSettings.Resolution.AddOptions(options);
        pannelSettings.Resolution.value = currentResolutionIndex;
        pannelSettings.Resolution.RefreshShownValue();

    }

    // Update
    // is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !PannelAddAgent.PannelObject.activeSelf)
        {
            if (game.State == STATE.PLAY)
                SetPause();
            else
            {
                if (game.State == STATE.PAUSE && Pannelpause.PannelObject.activeSelf)
                    SetPlay();
            }
            
        }

        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetStop();
        }*/

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (game.State != STATE.STOP )
            {
                if (PannelAddAgent.PannelObject.activeSelf )
                {
                    game.State = STATE.PLAY;
                    PannelAddAgent.HidePannel();
                    Debug.Log("On a caché le pannel");
                }
                else
                {
                    if (game.State != STATE.PAUSE)
                    {
                        PannelAddAgent.ShowPannel();
                        game.State = STATE.PAUSE;
                        Debug.Log("On montre le pannel");
                    }
                }
            }
            /*SetPause();
            
            Vector3 position = new Vector3(aleatoire.Next(20,255),0f,aleatoire.Next(20,143));
            temp = (GameObject)Instantiate(AgentObject,position,Quaternion.identity);
            game.AddAgent(temp);*/
        }
    }

    public void clickButtomStart()
    {
        Debug.Log("Clicked !!");
        //Faire une erreur si pas string
        try
        {
            nombreAgent = int.Parse(StartPannel.Square.text);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            GameObject error = (GameObject) Instantiate(ErrorWindows);
            error.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Text>().text =
                "ERROR 4 : : YOU CHOOSE A WRONG NUMBER (TYPE INT)" + "\n";
            throw;
        }

        try
        {
            

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            GameObject error = (GameObject) Instantiate(ErrorWindows);
            error.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Text>().text =
                "ERROR 4 : : YOU CHOOSE A WRONG NUMBER (TYPE INT)" + "\n";
            throw;
        }
        for (int i = 0; i < nombreAgent; i++)
        {

            Vector3 position = new Vector3(aleatoire.Next(20,255),0f,aleatoire.Next(20,143));
            temp = (GameObject)Instantiate(AgentObject,position,Quaternion.identity);
            game.AddAgent(temp);

        }
        SetPlay();
        
    }


    public void OnValueChanged()
    {
        game.speedofAgent = StartPannel.Speed.value;
        StartPannel.ValueSpeed.text =  StartPannel.Speed.value.ToString();
    }

    public void SetPause()
    {
        game.State = STATE.PAUSE;
        Pannelpause.ShowPannel();
        pannelSettings.HidePannel();
        PannelAddAgent.HidePannel();
        

    }

    public void SetStop()
    {
        game.State = STATE.STOP;
        StartPannel.ShowPannel();
        Pannelpause.HidePannel();
        PannelAddAgent.HidePannel();
        for (int i = 0; i < game.listeofAgent.Count; i++)
        { 
            GameObject o  = game.listeofAgent[i].gameObject;
            Destroy(o);
            game.numberofAgent--;

        }
    }

    public void SetPlay()
    {
        game.State = STATE.PLAY;
        StartPannel.HidePannel();
        Pannelpause.HidePannel();
        pannelSettings.HidePannel();
    }

    public void OpenSettings()
    {
        Pannelpause.HidePannel();
        StartPannel.HidePannel();
        pannelSettings.ShowPannel();
        
    }

    public void buttontryexception()
    {
        string textreturn ="";
        try
        {
            int temp = Int32.Parse(PannelAddAgent.IDnumber.text);

        }
        catch (Exception e)
        {
            textreturn += "ERROR 1 : YOU CHOOSE A WRONG ID (TYPE INT)" + "\n";
            Console.WriteLine(e);
        }
        
        try
        {
            int temp = Int32.Parse(PannelAddAgent.PosX.text);

        }
        catch (Exception e)
        {
            textreturn += "ERROR 2 : YOU CHOOSE A WRONG POS_X (TYPE INT)" + "\n";
            Console.WriteLine(e);
        }
        try
        {
            int temp = Int32.Parse(PannelAddAgent.PosY.text);

        }
        catch (Exception e)
        {
            textreturn += "ERROR 3 : YOU CHOOSE A WRONG POS_Y (TYPE INT)" + "\n";
            Console.WriteLine(e);
        }

        if (textreturn != "")
        {
            GameObject error = (GameObject) Instantiate(ErrorWindows);
            error.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Text>().text = textreturn;
        }
        else
        {
            PannelAddAgent.ApplyButton.interactable = true;
        }
        
    }

    public void CreateAAgent()
    {
        int posx = Int32.Parse(PannelAddAgent.PosX.text);
        int posy = Int32.Parse(PannelAddAgent.PosY.text);
        Vector3 pos = new Vector3(posx,0,posy);
        temp = (GameObject)Instantiate(AgentObject,pos,Quaternion.identity);
        game.AddAgent(temp);
        temp.GetComponent<AgentApplication>().DirectionOfAgent =
            DirectionChoose(PannelAddAgent.ChooseDirection.value);
        PannelAddAgent.ApplyButton.interactable = false;
        PannelAddAgent.HidePannel();
        SetPlay();
        
    }

    public Direction DirectionChoose(int value)
    {
        switch (value)
        {
            case 0:
                return new Direction(0,game.speedofAgent);
            case 1:
                return new Direction(game.speedofAgent,game.speedofAgent);
            case 2:
                return new Direction(game.speedofAgent,0);
            case 3:
                return new Direction(game.speedofAgent,-game.speedofAgent);
            case 4:
                return new Direction(0,-game.speedofAgent);
            case 5:
                return new Direction(-game.speedofAgent,-game.speedofAgent);
            case 6:
                return new Direction(-game.speedofAgent,0);
            case 7:
                return new Direction(-game.speedofAgent,game.speedofAgent);
            default:
                return null;
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }

    public void returnSetting()
    {
        SetPause();
    }
}
