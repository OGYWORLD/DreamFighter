using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameExit : MonoBehaviour
{
    private Button exitBtn;

    private void Awake()
    {
        exitBtn = GetComponent<Button>();
        exitBtn.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
#if Unity_EDITOR
EditorApplication.ExitPlayMode();

#else
        Application.Quit();

#endif

    }
}
