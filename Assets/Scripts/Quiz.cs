using UnityEngine;
using TMPro;
public class Quiz : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI questiontext;
    [SerializeField] QuestionSO question;
    void Start()
    {
        questiontext.text = question.GetQuestion();
    }

   
    
}
