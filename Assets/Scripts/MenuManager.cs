using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]

public class MenuManager : MonoBehaviour
{
    [SerializeField] private InputField nameField;
    [SerializeField] private Text highScoreText;

    private void Awake()
    {
        if (SaveManager.Instance.highScore != 0)
        {
            highScoreText.text = $"High Score : {SaveManager.Instance.highScoreName} - {SaveManager.Instance.highScore}";
        }
        nameField.text = SaveManager.Instance.playerName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
    EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void NameEntered()
    {
        SaveManager.Instance.playerName = nameField.text;
        SaveManager.Instance.Save();
    }
}
