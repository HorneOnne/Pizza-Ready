using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingCounter : MonoBehaviour
{
    [SerializeField] private CounterBehaviour _counter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _counter.IsServing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _counter.IsServing = false;
        }
    }
}
