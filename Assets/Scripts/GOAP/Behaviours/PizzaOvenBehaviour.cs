using UnityEngine;
using System.Collections.Generic;

public class PizzaOvenBehaviour : MonoBehaviour
{
    private int _maxStack = 10;
    private int _currentStack;

    [SerializeField] private Transform _bakedPizzaOriginTransform;
    private Vector3 _bakedPizzaOffset = new Vector3(0,0.1f,0f);
    [SerializeField]  private PizzaBehaviour _pizzaPrefab;
    public List<PizzaBehaviour> BakedPizzas = new();


    private float _bakePizzaTime = 2.0f;
    private float _bakePizzaTimer = 0.0f;

    private void Update()
    {
        _bakePizzaTimer += Time.deltaTime;
        if(_bakePizzaTimer > _bakePizzaTime)
        {
            _bakePizzaTimer -= _bakePizzaTime;
            if (_currentStack < _maxStack)
            {
                Debug.Log("Bake pizza");
                BakePizza();
            }
        }

      
    }



    public PizzaBehaviour BakePizza()
    {
        var pizzaInstance = Instantiate(_pizzaPrefab, GetBakedPizzaPosition(_currentStack), Quaternion.identity);
        BakedPizzas.Add(pizzaInstance);
        _currentStack++;

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
}