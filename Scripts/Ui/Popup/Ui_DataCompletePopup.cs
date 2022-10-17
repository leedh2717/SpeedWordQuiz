using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ui_DataCompletePopup : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    public void ClosePopup()
    {
        Managers.Ui.ClosePopup(this.gameObject);
    }
}
