using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_GameExitPopup : MonoBehaviour
{
    public void CancelBtn()
    {
        Managers.Ui.ClosePopup(gameObject);
    }

    public void OkBtn()
    {
        Application.Quit();
    }

}
