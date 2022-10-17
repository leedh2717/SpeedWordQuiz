using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui_Main : MonoBehaviour
{
    AudioSource backgroundMusic;

    bool isExitPopup;

    void Start()
    {
        isExitPopup = false;
        Managers.JsonData.LoadData();
        backgroundMusic = GetComponent<AudioSource>(); 
    }

    private void Update()
    {
        if (Managers.JsonData.gameData.backgroundMusicVolume)
        {
            backgroundMusic.volume = 1.0f;
        }
        else
        {
            backgroundMusic.volume = 0f;
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isExitPopup)
                {
                    GameObject go = GameObject.Find("Ui_GameExitPopup(Clone)");
                    go.GetComponent<Ui_GameExitPopup>().CancelBtn();
                    isExitPopup = false;
                }
                else
                {
                    Managers.Ui.ShowPopup("Ui_GameExitPopup");
                    isExitPopup = true;
                }                
            }
        }

    }

    public void GameStartClick()
    {
        Managers.Ui.ShowPopup("Ui_GameModePopup");
    }

    public void ShopClick()
    {
        Managers.Ui.MoveScene("CharacterShop");
    }

    public void SettingClick()
    {
        Managers.Ui.ShowPopup("Ui_MainSettingPopup");
    }

}
