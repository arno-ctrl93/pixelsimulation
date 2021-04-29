using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Trigger1 : MonoBehaviour
{
    private AgentApplication agentApplication;
    // Start is called before the first frame update
    void Start()
    {
        agentApplication = transform.GetComponentInParent<AgentApplication>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject != transform.gameObject)
        {
            agentApplication.OnTrigger1(other.gameObject);
        }
    }
}
