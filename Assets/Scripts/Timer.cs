using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timetocompletequestion = 30f;
    [SerializeField] float timetoshowcorrectanswer = 10f;
    public bool loadnextquestion;
    public bool isAnsweringQuestion;
    public float fillFraction;
    float TimerValue;
    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }
    public void CancelTimer()
    {
        TimerValue = 0;
    }
    void UpdateTimer()
    {
        TimerValue -= Time.deltaTime;
        if (isAnsweringQuestion)
        {
            if (TimerValue > 0)
            {
                fillFraction = TimerValue / timetocompletequestion;
            }
            else
            {
                isAnsweringQuestion = false;
                TimerValue = timetoshowcorrectanswer;
            }
        }
        else
        {
            if (TimerValue > 0)
            {
                fillFraction = TimerValue / timetoshowcorrectanswer;
            }
            else
            {
                isAnsweringQuestion = true;
                TimerValue = timetocompletequestion;
                loadnextquestion = true;
            }
        }
        
        
    }
}
