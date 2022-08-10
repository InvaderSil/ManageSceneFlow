using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TMP_InputField _nameTextArea;

    private void Start()
    {
        SetPlayerStats();
    }

    private void SetPlayerStats()
    {
        if(_bestScoreText != null)
        {
            string score = "Best Score: ";

            _bestScoreText.text = $"{score} {PlayerDataManager.Instance.BestPlayerName}: {PlayerDataManager.Instance.BestScore} ";
        }
    }

    public void StartGame()
    {

        PlayerDataManager.Instance.CurrentPlayerName = _nameTextArea.text;
        SceneManager.LoadScene(1);
    }

    

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
                
    }
}
