using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeButton : MonoBehaviour
{
    public UnityEvent onClick;
    public void OnButtonClick(GameObject target, string description)
    {
        if (target.GetComponent<TextMeshPro>().text == description)
        {
            onClick.Invoke();
        }
        else
        {
            target.GetComponent<TextMeshPro>().text = description;
        }
    }
}
