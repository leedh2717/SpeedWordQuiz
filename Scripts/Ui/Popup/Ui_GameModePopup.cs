using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_GameModePopup : MonoBehaviour
{
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePopup();
            }
        }
    }

    public void ModeSelect(int modeNum)
    {
        switch (modeNum)
        {
            case 1:
                Managers.Game.gameMode = Define.GameMode.BasicMode;
                break;
            case 2:
                Managers.Game.gameMode = Define.GameMode.HardMode;
                break;
            default:
                break;
        }
        Managers.Ui.MoveScene("Game");        
    }

    public void ClosePopup()
    {
        Managers.Ui.ClosePopup(gameObject);
    }
}
