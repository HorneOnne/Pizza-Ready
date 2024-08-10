using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Table : MonoBehaviour, IMachine
{
    [SerializeField] private List<Transform> _sittingPositions;
}
