using UnityEngine;
using System.Collections;
public class PizzaBehaviour : MonoBehaviour
{
    public bool IsPickUp { get; private set; }
    public float NutritionValue { get; set; }


    // animation
    private float _animMoveDuration = 0.2f;
    [SerializeField] private AnimationCurve _yCurve;
    private float _timeElapsed = 0f;
    private Vector3 _startMovePosition;

    private void Awake()
    {
        NutritionValue = 70;
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
    
    }

    public void PickUp()
    {
        this.IsPickUp = true;
    }

    public void Drop()
    {
        this.IsPickUp = false;
    }

    public void MoveToLocal(Vector3 localTargetPosition)
    {
        _startMovePosition = transform.localPosition;
        StartCoroutine(MoveToLocalAnimationCoroutine(localTargetPosition));
    }

    public void MoveTo(Vector3 targetPosition, System.Action onFinished = null)
    {
        _startMovePosition = transform.position;
        StartCoroutine(MoveAnimationCoroutine(targetPosition, onFinished));
    }

    private IEnumerator MoveAnimationCoroutine(Vector3 target, System.Action onFinished)
    {
        _timeElapsed = 0.0f;
        while (_timeElapsed < _animMoveDuration)
        {
            _timeElapsed += Time.deltaTime;
            float t  = _timeElapsed / _animMoveDuration;

            Vector3 newPosition = Vector3.Lerp(_startMovePosition, target, t);
            newPosition.y = _startMovePosition.y + _yCurve.Evaluate(t) * (target.y - _startMovePosition.y);
            transform.position = newPosition;
            yield return null;
        }
        transform.position = target;

        onFinished?.Invoke();
    }


    private IEnumerator MoveToLocalAnimationCoroutine(Vector3 target)
    {
        _timeElapsed = 0.0f;
        while (_timeElapsed < _animMoveDuration)
        {
            _timeElapsed += Time.deltaTime;
            float t = _timeElapsed / _animMoveDuration;

            Vector3 newPosition = Vector3.Lerp(_startMovePosition, target, t);
            newPosition.y = _startMovePosition.y + _yCurve.Evaluate(t) * (target.y - _startMovePosition.y);
            transform.localPosition = newPosition;
            yield return null;
        }
        transform.localPosition = target;
    }
}
