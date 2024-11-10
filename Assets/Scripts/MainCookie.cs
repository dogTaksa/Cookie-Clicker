using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainCookie : MonoBehaviour
{
    public UnityEvent onClick;

    void OnMouseDown()
    {
        onClick.Invoke();
        print("click");
    }
}
