using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCube : MonoBehaviour
{
    
    [SerializeField] public GameObject AgentObject;
    
    [SerializeField] public float Speed;
    private Agent newtestAgent = null;
    private Board ecran = new Board(100, 100);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
