using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using System.Collections.Generic;

public class Quiz : MonoBehaviour
{
    [Header("questions")]
    [SerializeField] TextMeshProUGUI questiontext;
    [SerializeField] List<QuestionSO> questions=new List<QuestionSO>();
    QuestionSO currentquestion;
    [Header("answers")]
    [SerializeField] GameObject[] answerButton;
    int correctanswerindex;
    bool HasAnsweredEarly;
    [Header("buttoncolors")]
    [SerializeField] Sprite defaultanswersprite;
    [SerializeField] Sprite correctanswersprite;
    [Header("timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    Scorekeeper scorekeeper;
    void Start()
    {
        timer = FindAnyObjectByType<Timer>();
        scorekeeper = FindAnyObjectByType<Scorekeeper>();
    }
    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadnextquestion)
        {
            HasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadnextquestion = false;
        }
        else if (!HasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            displayanswer(-1);
            SetButtonState(false);
        }
    }
    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            scorekeeper.Incrementquestionsseen();
        }
        
    }
    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentquestion = questions[index];

        if (questions.Contains(currentquestion))
        {
            questions.Remove(currentquestion);
        }
        
    }
    public void OnAnswerSelected(int index)
    {
        HasAnsweredEarly = true;
        displayanswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + scorekeeper.calculatescore()+"%";
    }
    void displayanswer(int index)
    {
        Image buttonimage;
        if (index == currentquestion.GetCorrectAnswerIndex())
        {
            questiontext.text = "correct";
            buttonimage = answerButton[index].GetComponent<Image>();
            buttonimage.sprite = correctanswersprite;
            scorekeeper.Incrementcorrectanswers();
        }
        else
        {
            correctanswerindex = currentquestion.GetCorrectAnswerIndex();
            string correctanswer = currentquestion.GetAnswer(correctanswerindex);
            questiontext.text = "the correct answer was " + correctanswer;
            buttonimage = answerButton[correctanswerindex].GetComponent<Image>();
            buttonimage.sprite = correctanswersprite;

        }
    }
    void DisplayQuestion()
    {
        questiontext.text = currentquestion.GetQuestion();

        for (int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI buttontext = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            buttontext.text = currentquestion.GetAnswer(i);
        }
    }
    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Button button = answerButton[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Image buttonimage = answerButton[i].GetComponent<Image>();
            buttonimage.sprite = defaultanswersprite;
        }
    }
}
