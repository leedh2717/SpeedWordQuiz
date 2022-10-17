using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int movePos = 2;
    int moveArea;

    int playerState;

    private void Start()
    {
        transform.position = new Vector3(0, -3.9f, 0);
        moveArea = 2;
        playerState = 1;
        PlayerPrefs.SetInt("PlayerState", playerState);
    }

    void Update()
    {
        playerState = PlayerPrefs.GetInt("PlayerState");

        if (playerState == 1)
        {
            PlayerControll();
            PlayerControll2();
        }        
    }

    void PlayerControll()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.y <= Screen.height / 1.3f)
                {
                    if (touch.position.x <= Screen.width / 2)
                    {
                        if (moveArea != 1)
                        {
                            transform.localScale = new Vector3(-1.0f, 1, 1);
                            transform.position -= new Vector3(movePos, 0, 0);
                            moveArea--;
                        }
                    }
                    else
                    {
                        if (moveArea != 3)
                        {
                            transform.localScale = new Vector3(1.0f, 1, 1);
                            transform.position += new Vector3(movePos, 0, 0);
                            moveArea++;
                        }
                    }
                }                
            }
        } 
    }

    void PlayerControll2()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (moveArea != 1)
            {
                transform.localScale = new Vector3(-1.0f, 1, 1);
                transform.position -= new Vector3(movePos, 0, 0);
                moveArea--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (moveArea != 3)
            {
                transform.localScale = new Vector3(1.0f, 1, 1);
                transform.position += new Vector3(movePos, 0, 0);
                moveArea++;
            }
        }
    }

    void QuizSuccessEffect()
    {
        GameObject successEffect = Resources.Load<GameObject>("Prefabs/Quiz/Success");
        Instantiate(successEffect);
    }

    public void QuizFailEffect()
    {
        GameObject successEffect = Resources.Load<GameObject>("Prefabs/Quiz/Fail");
        Instantiate(successEffect);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Answer0":
                if (Managers.Game.randomTrNum == 0)
                {
                    QuizSuccessEffect();
                    Managers.Game.QuizSuccess();
                }                    
                else
                    Managers.Game.QuizFail(this.gameObject);
                break;
            case "Answer1":
                if (Managers.Game.randomTrNum == 1)
                {
                    QuizSuccessEffect();
                    Managers.Game.QuizSuccess();
                }
                else
                    Managers.Game.QuizFail(this.gameObject);
                break;
            case "Answer2":
                if (Managers.Game.randomTrNum == 2)
                {
                    QuizSuccessEffect();
                    Managers.Game.QuizSuccess();
                }
                else
                    Managers.Game.QuizFail(this.gameObject);
                break;
            default:
                break;
        }
    }

    public void PlayerDie()
    {
        gameObject.SetActive(false);
    }

}
