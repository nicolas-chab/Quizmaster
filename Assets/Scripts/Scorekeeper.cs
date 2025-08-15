using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    int correctanswers = 0;
    int questionsseen = 0;
    public int getcorrectanswers()
    {
        return correctanswers;
    }
    public void Incrementcorrectanswers()
    {
        correctanswers++;
    }
    public int getquestionsseen()
    {
        return questionsseen;
    }
    public void Incrementquestionsseen()
    {
        questionsseen++;
    }
    public int calculatescore()
    {
        return  Mathf.RoundToInt(correctanswers / (float)questionsseen * 100);
    }
}
