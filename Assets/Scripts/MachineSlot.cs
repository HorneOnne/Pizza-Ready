using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MachineSlot : MonoBehaviour
{
    public static System.Action OnMachineUnlocked;
    [field: SerializeField] public int Cost { get; set; }
    private int _startingCost;
    [SerializeField] private bool _isUnlocking = false;
    private float _waitToUnlockTime = 0.5f;
    [SerializeField] private float _waitToUnlockTimer = 0.0f;
    public Transform MachineTransform;

    // references
    [SerializeField] private TextMeshProUGUI _defaultCostText;
    [SerializeField] private TextMeshProUGUI _unlockingCostText;
    [SerializeField] private GameObject _default;
    [SerializeField] private GameObject _unlocking;
    [SerializeField] private Image _percentSliderImage;
    [SerializeField] private string _machineName;

    private void Awake()
    {
        _startingCost = Cost;
    }

    private void Start()
    {
        UpdateCostString();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {


            _isUnlocking = true;
            transform.DOScale(1.35f, 0.5f).SetEase(Ease.InFlash);
        }


    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            transform.DOScale(1.0f, 0.5f).SetEase(Ease.OutBounce);
            _isUnlocking = false;
            _waitToUnlockTimer = 0;
        }


    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") == false)
        {
            return;
        }

        if (_isUnlocking)
        {
            _waitToUnlockTimer += Time.deltaTime;
            if (_waitToUnlockTimer < _waitToUnlockTime)
            {
                return;
            }
            else
            {
                if (_startingCost != Cost)
                {
                    _default.SetActive(false);
                    _unlocking.SetActive(true);
                }
            }
        }


        if (Unlock())
        {
            var machinePrefab = Resources.Load($"Machines/{_machineName}");
            if (machinePrefab != null)
            {
                // create machine
                Instantiate(machinePrefab, MachineTransform.position, Quaternion.identity);
                this.gameObject.SetActive(false);
                OnMachineUnlocked?.Invoke();
            }
            else
            {
                Debug.LogWarning($"Not found machine prefab: {_machineName}");
            }
        }
    }

    public bool Unlock()
    {
        if (CurrencyManager.Instance.Money > 0)
        {
            CurrencyManager.Instance.Withdraw(1);
            Cost--;
            UpdateCostString();
            _percentSliderImage.fillAmount = 1 - (float)Cost / _startingCost;
        }


        if (Cost == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateCostString()
    {
        _defaultCostText.text = CurrencyManager.Instance.GetCurrencyString(Cost);
        _unlockingCostText.text = CurrencyManager.Instance.GetCurrencyString(_startingCost - Cost);

    }

    private void SetUnlockState()
    {
        // first time unlock
        if (_startingCost == Cost)
        {
            _default.SetActive(false);
            _unlocking.SetActive(true);
        }
        else
        {
            _default.SetActive(true);
            _unlocking.SetActive(false);
        }
    }
}

