
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartingApp : MonoBehaviour
{
    [SerializeField] public GameObject picture1;
    [SerializeField] public GameObject picture2;
    [SerializeField] public GameObject picture3;
    [SerializeField] public GameObject picture4;
    [SerializeField] public GameObject picture5;
    [SerializeField] public GameObject picture6;
    [SerializeField] public GameObject picture7;
    [SerializeField] public GameObject picture8;
    [SerializeField] public GameObject picture9;
    [SerializeField] public GameObject picture10;
    [SerializeField] public GameObject picture11;
    [SerializeField] public GameObject picture12;
    [SerializeField] public GameObject picture13;
    [SerializeField] public GameObject picture14;
    [SerializeField] public GameObject picture15;
    [SerializeField] public GameObject picture16;

    [SerializeField] public Text tips;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("V2.0");
        }
        if (Time.time >= 4f && Time.time < 4.8f)
        {
            picture1.SetActive(true);
            Debug.Log("On est là");
        }
        if (Time.time >= 4.8f && Time.time < 5.6f)
        {
            picture1.SetActive(false);
            picture2.SetActive(true);
        }
        if (Time.time >= 5.6f && Time.time < 6.8f)
        {
            picture2.SetActive(false);
            picture3.SetActive(true);
        }
        if (Time.time >= 6.8f && Time.time < 7.4f)
        {
            picture3.SetActive(false);
            picture4.SetActive(true);
        }
        if (Time.time >= 7.4f && Time.time < 8.2f)
        {
            picture4.SetActive(false);
            picture5.SetActive(true);
        }
        if (Time.time >= 8.2f && Time.time<9)
        {
            picture5.SetActive(false);
            picture6.SetActive(true);
        }
        if (Time.time >= 9 && Time.time<9.8f)
        {
            picture6.SetActive(false);
            picture7.SetActive(true);
        }
        if (Time.time >= 9.8f && Time.time<10.6f)
        {
            picture7.SetActive(false);
            picture8.SetActive(true);
        }
        if (Time.time >= 10.6f && Time.time<11.4f)
        {
            picture8.SetActive(false);
            picture9.SetActive(true);
        }
        if (Time.time >= 11.4f && Time.time<12.2f)
        {
            picture9.SetActive(false);
            picture10.SetActive(true);
        }
        if (Time.time >= 12.2f && Time.time<13)
        {
            picture10.SetActive(false);
            picture11.SetActive(true);
        }
        if (Time.time >= 13 && Time.time<13.5f)
        {
            picture11.SetActive(false);
            picture12.SetActive(true);
        }
        if (Time.time >= 13.5f && Time.time<14)
        {
            picture12.SetActive(false);
            picture13.SetActive(true);
        }
        if (Time.time >=14 && Time.time<15)
        {
            picture13.SetActive(false);
            picture14.SetActive(true);
        }
        if (Time.time >=15 && Time.time<15.7f)
        {
            picture14.SetActive(false);
            picture15.SetActive(true);
        }

        /*if (Time.time == 15.7f )
        {
            picture15.transform.localScale = new Vector3(2,1,2);
        }*/
        if (Time.time >= 15.7f && Time.time<16.4f)
        {
            picture15.SetActive(false);
            picture16.SetActive(true);
            tips.gameObject.SetActive(true);
        }
        
        
    }
}
