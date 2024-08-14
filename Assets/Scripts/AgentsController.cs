using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentsController : MonoBehaviour
{
    public AgentController AgentPrefab;
    public List<AgentController> Agents;
    public Transform[] Points;


    public void Add(AgentController agent)
    {
        Agents.Add(agent);
    }

    public void Remove(AgentController agent)
    {
        Agents.Remove(agent);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            for(int i = 0; i < Agents.Count; i++)
            {
                Agents[i].gameObject.SetActive(true);
            }
        }
    }
}
