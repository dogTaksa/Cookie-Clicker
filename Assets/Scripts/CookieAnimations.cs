using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieAnimations : MonoBehaviour
{
    public GameObject mainCookie;
    public GameObject glowEffect;

    public float rotationSpeed;
    public void Update()
    {
        glowEffect.transform.transform.Rotate(0, 0, rotationSpeed);
    }
    public void smallCookie()
    {
        mainCookie.transform.transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);
    }

    public void bigCookie()
    {
        mainCookie.transform.transform.localScale = new Vector3(1, 1, 1);
    }
}
