using UnityEngine;
using TMPro;
public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalscoretext;
    Scorekeeper scorekeeper;
    void Awake()
    {
        scorekeeper = FindAnyObjectByType<Scorekeeper>();
    }

    public void showfinalscore()
    {
        finalscoretext.text = "Felicitaciones!\n Tu puntaje es " + scorekeeper.calculatescore() + "%";
    }
}
