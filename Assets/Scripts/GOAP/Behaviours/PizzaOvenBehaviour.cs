using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PizzaOvenBehaviour : MonoBehaviour
{
    private int _maxStack = 3;

    [SerializeField ] private Transform _pizzaMakerTransform;
    [SerializeField] private Transform _bakedPizzaOriginTransform;
    private Vector3 _bakedPizzaOffset = new Vector3(0,0.1f,0f);
    [SerializeField]  private PizzaBehaviour _pizzaPrefab;
    public Stack<PizzaBehaviour> BakedPizzas = new();

    private bool _hitPlayer =false;
    private float _bakePizzaTime = 2.0f;
    private float _bakePizzaTimer = 0.0f; 
    private float _takePizzaTime = 0.25f;
    private float _takePizzaTimer = 0.0f;

    private void Update()
    {
        _bakePizzaTimer += Time.deltaTime;
        if(_bakePizzaTimer > _bakePizzaTime)
        {
            _bakePizzaTimer -= _bakePizzaTime;
            if (BakedPizzas.Count < _maxStack)
            {
               var pizza = BakePizza();
                StartCoroutine(AddPizzaToStackCoroutine(pizza));
            }
        }
    }

    private IEnumerator AddPizzaToStackCoroutine(PizzaBehaviour pizza)
    {
        yield return new WaitForSeconds(0.21f);
        BakedPizzas.Push(pizza);
    }

    public PizzaBehaviour BakePizza()
    {
        var pizzaInstance = Instantiate(_pizzaPrefab, _pizzaMakerTransform.position, Quaternion.identity);
        pizzaInstance.MoveTo(GetBakedPizzaPosition(BakedPizzas.Count));
        return pizzaInstance;
    }

    private Vector3 GetBakedPizzaPosition(int index)
    {
        var position = _bakedPizzaOriginTransform.position;
        for (int i = 0; i < index;i++)
        {
            position += _bakedPizzaOffset;
        }
        return position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _hitPlayer = true;
            _takePizzaTimer = 0.0f;
        }
    }

  
    private void OnTriggerStay(Collider other)
    {
        if (_hitPlayer == false) return;

        _takePizzaTimer += Time.deltaTime;
        if(_takePizzaTimer > _takePizzaTime)
        {
            _takePizzaTimer -= _takePizzaTime;
            if (other.CompareTag("Player"))
            {
                if (other.TryGetComponent<PlayerServePizzaController>(out var player))
                {
                    if (BakedPizzas.Count > 0 && player.CanHoldMorePizza())
                    {
                        player.TakeFromOven(BakedPizzas.Pop());
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _hitPlayer = false;
        }
    }
}
