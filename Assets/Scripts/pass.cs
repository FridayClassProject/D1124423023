using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pass : MonoBehaviour
{
    public float moveSpeed = 5f; // 移动速度
    public float arrowSpeed = 5f; // 箭头移动速度

    private bool hasExitedScreen = false;

    void Update()
    {
        // 控制物体移动
        MoveObject();

        // 控制箭头移动并检测是否离开屏幕
        MoveArrow();

        // 根据当前场景名加载不同场景
        LoadDifferentScene();
    }

    void MoveObject()
    {
        // 获取水平和垂直方向的输入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 根据输入移动物体
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);

        // 设置动画参数
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetInteger("X", (int)horizontalInput);
            animator.SetInteger("Y", (int)verticalInput);
        }
    }

    void MoveArrow()
    {
        transform.Translate(Vector3.right * arrowSpeed * Time.deltaTime);

        if (!hasExitedScreen)
        {
            Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
            if (viewportPos.x > 1.2f)
            {
                hasExitedScreen = true;
                LoadNextScene();
            }
        }
    }

    void LoadNextScene()
    {
        // 根据当前场景名称加载下一个场景
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "D1124423017")
        {
            SceneManager.LoadScene("D1124423030");
        }
        else if (currentScene == "D1124423030")
        {
            SceneManager.LoadScene("BOOYIPE");
        }
        else
        {
            Debug.LogWarning("Unknown scene name: " + currentScene);
        }
    }

    void LoadDifferentScene()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene == "D1124423017")
            {
                SceneManager.LoadScene("D1124423030");
            }
            else if (currentScene == "D1124423030")
            {
                SceneManager.LoadScene("BOOYIPE");
            }
            else
            {
                Debug.LogWarning("Unknown scene name: " + currentScene);
            }
        }
    }
}