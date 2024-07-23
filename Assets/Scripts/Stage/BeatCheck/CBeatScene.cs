using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CBeatScene : MonoBehaviour
{
    public void ToBeatCheckScene()
    {
        SceneManager.LoadScene(3);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
