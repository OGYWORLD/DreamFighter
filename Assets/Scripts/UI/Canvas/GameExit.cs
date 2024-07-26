using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameExit : MonoBehaviour
{
    public Button exitBtn;

    private void Awake()
    {
        exitBtn.onClick.AddListener(ExitGame);
    }

    public void ExitGame()
    {
#if Unity_EDITOR
EditorApplication.ExitPlayMode();

#else
        Application.Quit();

#endif

    }
}
