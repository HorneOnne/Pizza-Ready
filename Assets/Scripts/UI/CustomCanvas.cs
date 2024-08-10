using UnityEngine;

public class CustomCanvas : MonoBehaviour
{
    private Canvas _canvas;

    #region Properties
    public Canvas Canvas { get { return _canvas; } }
    #endregion

    protected virtual void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    public void DisplayCanvas(bool isDisplay)
    {
        _canvas.enabled = isDisplay;
    }
}
