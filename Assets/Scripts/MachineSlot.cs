using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MachineSlot : MonoBehaviour
{
    [field: SerializeField] public int Cost { get; set; }
    [SerializeField] private bool _isUnlock;

    // references
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private string _machineName;

    private void Awake()
    {
        
    }

    private void Start()
    {
        _costText.text = Cost.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Debug.Log(transform.position);
    }


    private void OnTriggerStay(Collider other)
    {    
        if(Unlock())
        {
            var machinePrefab = Resources.Load($"Machines/{_machineName}");
            if(machinePrefab != null )
            {
                // create machine
                Instantiate(machinePrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning($"Not found machine prefab: {_machineName}");
            }
        }
    }

    public bool Unlock()
    {
        return false;
    }

}
