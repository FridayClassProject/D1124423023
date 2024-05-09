using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowController : MonoBehaviour
{
    public float speed = 5f;
    private bool hasExitedScreen = false;

    void Start()
    {
        if (Camera.main == null)
        {
            Debug.LogError("Main camera is not found!");
        }
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

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
        
        Debug.Log("fNext Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
