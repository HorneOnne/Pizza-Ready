using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentsController : MonoBehaviour
{
    public AgentController AgentPrefab;
    public List<AgentController> Agents;
    public Transform[] Points;
    private bool _isAgentsActive = false;

    private void OnEnable()
    {
        MachineSlot.OnMachineUnlocked += CheckGameStarted;
    }

    private void OnDisable()
    {
        MachineSlot.OnMachineUnlocked -= CheckGameStarted;
    }

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

    private void CheckGameStarted()
    {
        if (_isAgentsActive) return;
        TableBehaviour table = FindObjectOfType<TableBehaviour>();
        PizzaOvenBehaviour oven = FindObjectOfType<PizzaOvenBehaviour>();
        CounterBehaviour counter = FindObjectOfType<CounterBehaviour>();

        if(table != null && oven != null && counter != null)
        {
            _isAgentsActive = true;
            for (int i = 0; i < Agents.Count; i++)
            {
                Agents[i].gameObject.SetActive(true);
            }
        }

    }
}
