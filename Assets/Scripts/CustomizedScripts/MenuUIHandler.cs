using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField nameInput;

    void Start()
    {
        nameInput.text = SaveManager.instance.playerName;
        bestScoreText.SetText("Best Score: " + SaveManager.instance.playerName + ": " + SaveManager.instance.bestScore);
    }


    void Update()
    {

    }

    public void nameChanged()
    {
        SaveManager.instance.playerName = nameInput.text;
        SaveManager.instance.SaveBestScore();
        bestScoreText.SetText("Best Score: " + SaveManager.instance.playerName + ": " + SaveManager.instance.bestScore);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        // save any game data here
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

}