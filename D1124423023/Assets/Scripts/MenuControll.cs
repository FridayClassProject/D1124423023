using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControll : MonoBehaviour
{
    // 數字猜測遊戲相關變量
    public InputField inputField; 
    public Text resultText; 
    private int correctNumber; 

    // 遊戲菜單相關變量
    public string nextSceneName;

    void Start()
    {
        StartNewGame(); // 開始一局新遊戲
    }

    void Update()
    {
        // 數字猜測遊戲部分
        // ...
    }

    // 開始一局新遊戲的方法
    void StartNewGame()
    {
        correctNumber = Random.Range(1, 101);
        inputField.text = "";
        resultText.text = "";
    }

    // 玩家猜測提交的方法
    public void SubmitGuess()
    {
               // 從Input Field中獲取玩家的猜測數字
        string guessString = inputField.text;

        // 將玩家的猜測數字轉換為整數
        int guess;
        if (!int.TryParse(guessString, out guess))
        {
            // 如果無法將輸入轉換為整數，則顯示錯誤信息並提前返回
            resultText.text = "Please enter a valid number.";
            return;
        }

        // 根據玩家的猜測與正確答案進行比較，顯示相應的提示信息
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

    // 再來一次遊戲的方法
    public void RestartGame()
    {
        StartNewGame();
    }

    // 載入下一個場景的方法
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // 開始遊戲的方法（用於菜單）
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    // 退出遊戲的方法（用於菜單）
    public void QuitGame()
    {
        Application.Quit();
    }
}
