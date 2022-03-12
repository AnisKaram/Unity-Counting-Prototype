using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    #region Public Variables
    public Text CounterText;
    #endregion Public Variables

    #region Private Variables
    int Count = 0;
    #endregion Private Variables

    #region Private Methods
    void Start()
    {
        Count = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        // Increase the count whenever a sphere enters the box
        // Change the tag from Selectable to Collected
        // to prevent from being re-collected from that box
        Count += 1;
        other.gameObject.tag = "Collected";
        CounterText.text = "Count : " + Count;
    }
    #endregion Private Methods

    public int GetCount()
    {
        return Count;
    }
}
