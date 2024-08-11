using UnityEngine;

public class HungerBehaviour : MonoBehaviour
{
    public float Hunger;
    private void Awake()
    {
        Hunger = Random.Range(0f, 100f);
    }

    private void FixedUpdate()
    {
        Hunger += Time.fixedDeltaTime * 10f;
    }
}