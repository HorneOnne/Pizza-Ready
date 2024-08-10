using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;

public class Table : MonoBehaviour, IMachine
{
    [SerializeField] private List<Transform> _sittingPositions;

    private void Awake()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1.0f, 0.35f).SetEase(Ease.InOutSine);
    }
}
