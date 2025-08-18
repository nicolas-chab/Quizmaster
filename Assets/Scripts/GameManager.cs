using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endscreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        quiz = FindAnyObjectByType<Quiz>();
        endscreen = FindAnyObjectByType<EndScreen>();
    }
    void Start()
    {
       
        quiz.gameObject.SetActive(true);
        endscreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (quiz.iscomplete)
        {
            quiz.gameObject.SetActive(false);
            endscreen.gameObject.SetActive(true);
            endscreen.showfinalscore();
        }
    }
    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
