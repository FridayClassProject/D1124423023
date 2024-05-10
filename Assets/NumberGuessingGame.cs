using UnityEngine;
using UnityEngine.UI;

public class NumberGuessingGame : MonoBehaviour
{
    public InputField inputField; // 用於存儲Input Field元素的變量
    public Text resultText; // 用於顯示結果的Text元素

    private int correctNumber; // 正確的數字答案

    void Start()
    {
        StartNewGame(); // 開始一局新遊戲
    }

    // 開始一局新遊戲的方法
    void StartNewGame()
    {
        // 隨機生成一個1到100之間的數字作為正確答案
        correctNumber = Random.Range(1, 101);

        // 清空輸入框和結果文本
        inputField.text = "";
        resultText.text = "";
    }

    // 當玩家按下提交按鈕時被調用的方法
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

    // 當玩家點擊再來一次按鈕時被調用的方法
    public void RestartGame()
    {
        StartNewGame(); // 開始一局新遊戲
    }
}
