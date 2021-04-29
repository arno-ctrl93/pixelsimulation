using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Random = System.Random;

// MAIN SCRIPT
public enum STATE
{
    PLAY,
    STOP,
    PAUSE,
};
public class Application : MonoBehaviour
{
    // TEMPORARY PARAMETER
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
    [SerializeField] public Button S_buttonhelp;
    [SerializeField] public InputField S_BoardX;
    [SerializeField] public InputField S_BoardY;
    [SerializeField] public Button S_Exit;
    public StartPannel StartPannel;
    
    // TO Initialize the Game Class
    public Game game;
    
    // To initialize the Board Class
    public Board board;
    [SerializeField] public int BoardX;
    [SerializeField] public int BoardY;
    
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
    
    //To initialize the PannelHelp Class
    [SerializeField] public Image H_background;
    [SerializeField] public Text H_titel;
    [SerializeField] public Text H_description;
    [SerializeField] public Button H_quit;
    [SerializeField] public GameObject H_gameobject;
    public PannelHelp pannelHelp;
    
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
        board = new Board(BoardX, BoardY);
        StartPannel = new StartPannel(S_gameobject, S_InputText, S_Square, S_StartButton, S_Speed, S_Logo,
            S_ValueSpeed,S_buttonhelp,S_BoardX,S_BoardY,S_Exit);
        PannelAddAgent = new PannelAddAgent(A_gameobject, A_IDnumber, A_PosX, A_PosY, A_ChooseDirection, A_trybutton,
            A_ApplyButton);
        Pannelpause = new PannelPause(P_gameobject, P_Play, P_Option, P_Quit);
        pannelSettings = new PannelSettings(Settings_gameobject, S_Resolution, S_Toggle, S_Graphics, S_Volume, S_back);
        pannelHelp = new PannelHelp(H_gameobject,H_background,H_titel,H_description,H_quit);
        game = new Game(StartPannel, PannelAddAgent, Pannelpause, pannelSettings, board,pannelHelp);
        game.speedofAgent = 0.5f;

        //Management of different pannel
        StartPannel.ShowPannel();
        Pannelpause.HidePannel();
        PannelAddAgent.HidePannel();
        pannelSettings.HidePannel();
        pannelHelp.HidePannel();

        //Mange the resolution for option menu
        resolutions = Screen.resolutions;
        pannelSettings.Resolution.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            SetResolution(resolutions.Length-1);
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
        string textreturn = "";
        Debug.Log("Clicked !!");
        //Faire une erreur si pas string
        try
        {
            nombreAgent = int.Parse(StartPannel.Square.text);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            textreturn += "ERROR 4 : YOU CHOOSE A WRONG NUMBER IN NUMBER OF AGENT (TYPE INT)" + "\n";
        }

        try
        {
            int tempx = int.Parse(StartPannel.Board_X.text);
            if (tempx < 10)
            {
                textreturn += "ERROR 7: YOU CHOOSE A BOARD X TOO SMALL (MINI 10)" + "\n";
            }
            else
            {
                if (tempx >256)
                    textreturn += "ERROR 8: YOU CHOOSE A BOARD X TOO TALL (MAX 256)" + "\n";
                else
                {
                    game.board.sizex = tempx;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            textreturn += "ERROR 5 : YOU CHOOSE A WRONG NUMBER IN SIZE BOARD X (TYPE INT)" + "\n";
        }
        try
        {
            int tempy = int.Parse(StartPannel.Board_Y.text);
            if (tempy < 10)
            {
                textreturn += "ERROR 9: YOU CHOOSE A BOARD Y TOO SMALL (MINI 10)" + "\n";
            }
            else
            {
                if (tempy >144)
                    textreturn += "ERROR 8: YOU CHOOSE A BOARD Y TOO TALL (MAX 144)" + "\n";
                else
                {
                    game.board.sizey = tempy;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            textreturn += "ERROR 6 : YOU CHOOSE A WRONG NUMBER IN SIZE BOARD Y (TYPE INT)" + "\n";
        }

        /*try
        {
            

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            textreturn += "ERROR 4 : : YOU CHOOSE A WRONG NUMBER (TYPE INT)" + "\n";
            throw;
        }*/

        if (textreturn != "")
        {
            GameObject error = (GameObject) Instantiate(ErrorWindows);
            error.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Text>().text = textreturn;
        }
        else
        {
            for (int i = 0; i < nombreAgent; i++)
            {

                Vector3 position = new Vector3(aleatoire.Next(1,board.sizex-1),0f,aleatoire.Next(1,board.sizey-1));
                temp = (GameObject)Instantiate(AgentObject,position,Quaternion.identity);
                game.AddAgent(temp);

            }
            SetPlay();
        }

        
        
        
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
        
        //game.listeofAgent[0].GetComponent<AgentApplication>().newtestAgent.IsInGroup = true;
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
        // For manage the direction of the new Agent
        temp.GetComponent<AgentApplication>().DirectionOfAgent =
            DirectionChoose(PannelAddAgent.ChooseDirection.value);
        // For manage the ID of the new Agent
        temp.GetComponent<AgentApplication>().IDofAgent =
            Int32.Parse(PannelAddAgent.IDnumber.text);
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

    public void showthepannelhelp()
    {
        pannelHelp.ShowPannel();
    }

    public void hidethepannelhelp()
    {
        pannelHelp.HidePannel();
    }

    public void QuitTheApplication()
    {
        UnityEngine.Application.Quit();
    }
}
