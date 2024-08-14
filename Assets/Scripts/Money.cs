using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int Value;
    public Vector3 Size = new Vector3(0.3123995f, 0.1846734f, 0.6416975f);

    // animation
    private float _animMoveDuration = 0.2f;
    [SerializeField] private AnimationCurve _yCurve;
    private float _timeElapsed = 0f;
    private Vector3 _startMovePosition;

    public void MoveTo(Transform target, System.Action onFinished = null)
    {
        _startMovePosition = transform.position;
        StartCoroutine(MoveAnimationCoroutine(target, onFinished));
    }

    private IEnumerator MoveAnimationCoroutine(Transform target, System.Action onFinished)
    {
        _timeElapsed = 0.0f;
        while (_timeElapsed < _animMoveDuration)
        {
            _timeElapsed += Time.deltaTime;
            float t = _timeElapsed / _animMoveDuration;

            Vector3 newPosition = Vector3.Lerp(_startMovePosition, target.position, t);
            newPosition.y = _startMovePosition.y + _yCurve.Evaluate(t) * (target.position.y - _startMovePosition.y);
            transform.position = newPosition;
            yield return null;
        }
        transform.position = target.position;
        onFinished?.Invoke();
        Hide();
    }

    public void Hide()
    {
        transform.Find("Model").gameObject.SetActive(false);
    }

}
