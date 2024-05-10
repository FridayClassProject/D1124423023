using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControll : MonoBehaviour
{
    public InputField inputField; 
    public Text resultText; 
    private int correctNumber; 

    public string nextSceneName;

    void Start()
    {
        StartNewGame();
    }

    void Update()
    {
     
    }

    void StartNewGame()
    {
        correctNumber = Random.Range(1, 101);
        inputField.text = "";
        resultText.text = "";
    }


    public void SubmitGuess()
    {

        string guessString = inputField.text;

     
        int guess;
        if (!int.TryParse(guessString, out guess))
        {
    
            resultText.text = "Please enter a valid number.";
            return;
        }

        if (guess == correctNumber)
        {
            resultText.text = "Congratulations! You guessed it right!";
        }
        else if (guess < correctNumber)
        {
            resultText.text = "Too low! Try a larger number.";
        }
        else
        {
            resultText.text = "Too high! Try a smaller number.";
        }
    }


    public void RestartGame()
    {
        StartNewGame();
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}