using UnityEngine;

public class PizzaMakerBehaviour : MonoBehaviour
{
    public GameObject PizzaPrefab;

    public PizzaBehaviour MakePizza(Vector3 position)
    {
        return Instantiate(PizzaPrefab, position, Quaternion.identity).GetComponent<PizzaBehaviour>();
    }
}
