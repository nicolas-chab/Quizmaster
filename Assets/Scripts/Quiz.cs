using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI questiontext;
    [SerializeField] QuestionSO question;
    [SerializeField]GameObject[] answerButton;
    int correctanswerindex;
    [SerializeField]Sprite defaultanswersprite;
    [SerializeField] Sprite correctanswersprite;
    void Start()
    {
        questiontext.text = question.GetQuestion();

        for (int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI buttontext= answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            buttontext.text=  question.GetAnswer(i);
        }
        
    }

    public void OnAnswerSelected(int index)
    {
        if (index == question.GetCorrectAnswerIndex())
        {
            questiontext.text = "correct";
            Image buttonimage = answerButton[index].GetComponent<Image>();
            buttonimage.sprite = correctanswersprite;
        }
    }
    
}
