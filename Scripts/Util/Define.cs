using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{    
    public enum QuizQuestion
    {
        NotSet,
        Ready,
        QuestionStart,
        QuestionEnd,        
    }

    public enum QuizAnswer
    {
        NotSet,
        Ready,
        AnswerStart,
        AnswerEnd,
    }

    public enum GameMode
    {
        BasicMode,
        HardMode
    }

    public enum CharactersName
    {
        c1,
        c2,
        c3,
        c4,
        c5,
        c6,
        c7,
        c8,
        c9
    }   
}
