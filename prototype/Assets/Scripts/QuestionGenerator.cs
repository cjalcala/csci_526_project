using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Diagnostics;

public class QuestionGenerator : MonoBehaviour
{
    Root questionObject;

    //if run out of the question in desired level,return the non empty level in descending difficulity
    private int findLevel(int easyCount, int mediumCount, int hardCount, int rand, double easyRate, double mediumRate, double hardRate)
    {
        int res = 0;

        if (rand <= easyRate * 100 && easyCount > 0)
        {
            res = 0;
        }
        else if (rand > easyRate * 100 && rand <= (mediumRate + easyRate) * 100 && mediumCount > 0)
        {
            res = 1;
        }
        else if (rand > (mediumRate + easyRate) * 100 && hardCount > 0)
        {
            res = 2;
        }
        else
        {
            int[] ary = new int[] { easyCount, mediumCount, hardCount };
            res = Array.LastIndexOf(ary, ary.Last(c => c != 0));
        }
        return res;
    }

    //PARAM: rate <= 1.0, sum of rate == 1,
    //RETURN:  QuizQA or NULL
    public QuizQA getQuestion(double easyRate, double mediumRate, double hardRate)
    {
        if (easyRate > 1.0 || mediumRate > 1.0 || hardRate > 1.0)
        {
            UnityEngine.Debug.Log("JSONReader: Rate > 1");
        }

        if (easyRate + mediumRate + hardRate != 1)
        {
            UnityEngine.Debug.Log("JSONReader: Rate sum != 1");
        }

        int rand = new System.Random().Next(101);
        int easyCount = questionObject.easy.Count;
        int mediumCount = questionObject.medium.Count;
        int hardCount = questionObject.hard.Count;
        int level = findLevel(easyCount, mediumCount, hardCount, rand, easyRate, mediumRate, hardRate);

        //Question is deleted in questionObject when return
        //Level: 0 easy, 1 medium, 2 hard
        if (level == 0)
        {
            //get easy question
            int randIndex = new System.Random().Next(easyCount);
            Easy question = questionObject.easy[randIndex];
            if (randIndex != easyCount - 1)
            {
                questionObject.easy[randIndex] = questionObject.easy[easyCount - 1];
            }
            questionObject.easy.RemoveAt(easyCount - 1);
            easyCount--;
            return questionConverter(question);

        }
        else if (level == 1)
        {
            //get medium question
            int randIndex = new System.Random().Next(mediumCount);
            Medium question = questionObject.medium[randIndex];
            // questionObject.medium.RemoveAt(randIndex);
            if (randIndex != mediumCount - 1)
            {
                questionObject.medium[randIndex] = questionObject.medium[mediumCount - 1];
            }
            questionObject.medium.RemoveAt(mediumCount - 1);
            mediumCount--;
            return questionConverter(question);
        }
        else if (level == 2)
        {
            //get hard question
            int randIndex = new System.Random().Next(hardCount);
            Hard question = questionObject.hard[randIndex];
            // questionObject.hard.RemoveAt(randIndex);
            if (randIndex != hardCount - 1)
            {
                questionObject.hard[randIndex] = questionObject.hard[hardCount - 1];
            }
            questionObject.hard.RemoveAt(hardCount - 1);
            hardCount--;
            return questionConverter(question);

        }
        else
        {
            UnityEngine.Debug.Log("Run out of questions");
            return null;
        }
    }

    public QuizQA questionConverter(Question q)
    {
        string text = q.QuestionText;
        QuizQA quizQA = new QuizQA();

        int[] indexArray = { 0, 1, 2, 3 };
        System.Random random = new System.Random();
        indexArray = indexArray.OrderBy(x => random.Next()).ToArray();

        string[] options = new string[4];
        options[indexArray[0]] = q.Option1;
        options[indexArray[1]] = q.Option2;
        options[indexArray[2]] = q.Option3;
        options[indexArray[3]] = q.Option4;

        quizQA.question = q.QuestionText;
        quizQA.answers = options;
        quizQA.correctAnswer = indexArray[0];

        return quizQA;
    }

    public QuestionGenerator()
    {
        var jsonTextFile = Resources.Load<TextAsset>("Questions");//Questions.json in Resources
        questionObject = JsonUtility.FromJson<Root>(jsonTextFile.text);
    }
}


[System.Serializable]
public class Root
{
    public List<Easy> easy;
    public List<Medium> medium;
    public List<Hard> hard;
}
[System.Serializable]
public class Question
{
    public string QuestionText;
    public string Option1;
    public string Option2;
    public string Option3;
    public string Option4;
}

[System.Serializable]
public class Easy : Question
{
}

[System.Serializable]
public class Medium : Question
{
}

[System.Serializable]
public class Hard : Question
{
}
