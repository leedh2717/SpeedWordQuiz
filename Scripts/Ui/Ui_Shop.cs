using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Define;

public class Ui_Shop : MonoBehaviour
{
    [SerializeField]
    List<Sprite> characters;

    AudioSource backgroundMusic;

    public static int characterNum;

    public Image shopCharacter;
    public TextMeshProUGUI shopCharacterName;

    public TextMeshProUGUI myMoney;

    public Image price;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI checkText;

    public Button buyBtn;

    int[] charactersPrice = { 0, 500, 500, 800, 800, 1000, 1000, 1500, 2000 };
    string[] charactersName = { "깡깡이", "핑크", "밥", "뽀글이", "기사", "해적왕", "쪼꼬", "용사", "악마" };

    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();

        characterNum = 0;

        shopCharacter.sprite = characters[characterNum];
        shopCharacterName.text = charactersName[characterNum];

        if ((int)Managers.JsonData.gameData.equipCharacter == 0)
        {
            checkText.text = "장 착 중";
        }
        else
        {
            checkText.text = "보 유 중";
        }
        PlayerPrefs.SetInt("ShopCharacterNum", characterNum);
        PlayerPrefs.SetString("ShopCharacterName", charactersName[characterNum]);
        PlayerPrefs.SetInt("ShopCharacterPrice", charactersPrice[characterNum]);
    }

    void Update()
    {
        myMoney.text = Managers.JsonData.gameData.money.ToString();

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
                BackMainScene();
            }
        }
    }

    public void BackMainScene()
    {
        Managers.Ui.MoveScene("Main");
    }

    public void CharacterLeftBtn()
    {
        if (characterNum != 0)
        {
            price.gameObject.SetActive(true);
            priceText.gameObject.SetActive(true);
            checkText.gameObject.SetActive(false);
            characterNum--;
            shopCharacter.sprite = characters[characterNum];
            shopCharacterName.text = charactersName[characterNum];
            priceText.text = charactersPrice[characterNum].ToString();

            // 현재 본인이 캐릭터를 보유하고 있을 때
            for (int i = 0; i < Managers.JsonData.gameData.isCharacters.Count; i++)
            {
                if ((int)Managers.JsonData.gameData.isCharacters[i] == characterNum)
                {
                    if (characterNum == (int)Managers.JsonData.gameData.equipCharacter)
                    {
                        price.gameObject.SetActive(false);
                        priceText.gameObject.SetActive(false);
                        checkText.gameObject.SetActive(true);
                        checkText.text = "장 착 중";
                    }
                    else
                    {
                        price.gameObject.SetActive(false);
                        priceText.gameObject.SetActive(false);
                        checkText.gameObject.SetActive(true);
                        checkText.text = "보 유 중";
                    }
                    break;
                }
            }
            PlayerPrefs.SetInt("ShopCharacterNum", characterNum);
            PlayerPrefs.SetString("ShopCharacterName", charactersName[characterNum]);
            PlayerPrefs.SetInt("ShopCharacterPrice", charactersPrice[characterNum]);
        }
    }

    public void CharacterRightBtn()
    {        
        if (characterNum != characters.Count-1)
        {
            price.gameObject.SetActive(true);
            priceText.gameObject.SetActive(true);
            checkText.gameObject.SetActive(false);
            characterNum++;
            shopCharacter.sprite = characters[characterNum];
            shopCharacterName.text = charactersName[characterNum];
            priceText.text = charactersPrice[characterNum].ToString();

            // 현재 본인이 캐릭터를 보유하고 있을 때
            for (int i = 0; i < Managers.JsonData.gameData.isCharacters.Count; i++)
            {
                if ((int)Managers.JsonData.gameData.isCharacters[i] == characterNum)
                {
                    if (characterNum == (int)Managers.JsonData.gameData.equipCharacter)
                    {
                        price.gameObject.SetActive(false);
                        priceText.gameObject.SetActive(false);
                        checkText.gameObject.SetActive(true);
                        checkText.text = "장 착 중";
                    }
                    else
                    {
                        price.gameObject.SetActive(false);
                        priceText.gameObject.SetActive(false);
                        checkText.gameObject.SetActive(true);
                        checkText.text = "보 유 중";
                    }
                    break;
                }
            }
            PlayerPrefs.SetInt("ShopCharacterNum", characterNum);
            PlayerPrefs.SetString("ShopCharacterName", charactersName[characterNum]);
            PlayerPrefs.SetInt("ShopCharacterPrice", charactersPrice[characterNum]);
        }
    }

    public void BuyBtn()
    {
        // 구매여부에 따른 버튼기능
        if (checkText.gameObject.activeSelf)
        {
            if (checkText.text.Equals("보 유 중"))
            {
                Managers.JsonData.gameData.equipCharacter = (Define.CharactersName)characterNum;
                Managers.JsonData.SaveData();
                checkText.text = "장 착 중";
            }
        }
        else
        {
            if (Managers.JsonData.gameData.money < charactersPrice[characterNum])
            {
                Managers.Ui.ShowPopup("Ui_BuyFailPopup");
            }
            else
            {
                Managers.Ui.ShowPopup("Ui_CharacterBuyPopup");
            }
        }
    }
}
