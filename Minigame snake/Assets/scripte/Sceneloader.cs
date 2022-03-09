using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    public void LoadScene(string _name)
    {
        SceneManager.LoadScene(_name);
        Time.timeScale = 1.0f;

    }
}
