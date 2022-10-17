using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Define;

public class Ui_CharacterBuyPopup : MonoBehaviour
{
    public Sprite[] characters;

    public Image character;
    public TextMeshProUGUI characterNameText;
    public Button cancelBtn;
    public Button oKBtn;

    int characterNum;
    string characterName;
    int characterPrice;

    void Start()
    {
        characterNum = PlayerPrefs.GetInt("ShopCharacterNum");
        characterName = PlayerPrefs.GetString("ShopCharacterName");
        characterPrice = PlayerPrefs.GetInt("ShopCharacterPrice");

        character.GetComponent<Image>().sprite = characters[characterNum];
        characterNameText.text = characterName;
    }

    public void ClosePopup()
    {
        Managers.Ui.ClosePopup(this.gameObject);
    }

    public void OkBtn()
    {
        Managers.JsonData.gameData.money -= characterPrice;
        Managers.JsonData.gameData.isCharacters.Add((Define.CharactersName)characterNum);
        Managers.JsonData.gameData.equipCharacter = (Define.CharactersName)characterNum;
        Managers.JsonData.SaveData();
        Managers.Ui.ShowPopup("Ui_BuySuccessPopup");
        Managers.Ui.ClosePopup(this.gameObject);
    }
}
