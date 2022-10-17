using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_MessagePopup : MonoBehaviour
{
    public void ClosePopup()
    {
        Managers.Ui.ClosePopup(this.gameObject);
    }

    public void CloseCharacterBuyPopup()
    {
        Managers.Ui.ClosePopup(this.gameObject);
        Managers.Ui.MoveScene("CharacterShop");
    }
}
