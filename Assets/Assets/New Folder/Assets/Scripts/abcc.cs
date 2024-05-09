using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class abc : MonoBehaviour
{
    private int a;
    public Text b;
    public string Scene;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
            {
                Time.timeScale = 0.1f;
            }

        a++;

        GetComponent<Text>().text = "" + a;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}