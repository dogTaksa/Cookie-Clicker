using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainCookie : MonoBehaviour
{
    public UnityEvent onClick;
    public UnityEvent onMouseDown;
    public UnityEvent onMouseUp;

    void OnMouseDown()
    {
        onClick.Invoke();
        onMouseDown.Invoke();

        print("click");
    }

    private void OnMouseUp()
    {
        onMouseUp.Invoke();
    }
}
