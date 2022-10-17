using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizEffect : MonoBehaviour
{
    AudioSource effectAudio;

    void Start()
    {
        effectAudio = GetComponent<AudioSource>();

        Invoke("SpriteRemove", 0.3f);
        Invoke("Destroy", 1f);
    }

    private void Update()
    {
        if (Managers.JsonData.gameData.effectMusicVolume)
        {
            effectAudio.volume = 1.0f;
        }
        else
        {
            effectAudio.volume = 0f;
        }
    }

    void SpriteRemove()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

}
