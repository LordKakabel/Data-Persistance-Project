using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class UIMenu : MonoBehaviour
{
    [SerializeField] InputField _inputField;
    [SerializeField] Text _highScoreText;

    private void Start() {
        _highScoreText.text = $"High Score: {GameManager.Instance.RecordHolderName} : {GameManager.Instance.HighScore}";
    }

    public void StartButton() {
        GameManager.Instance.CurrentPlayerName = _inputField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit() {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
