using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "My UI/MenuFunctions")]
public class MenuFunctions : ScriptableObject
{
    // Start is called before the first frame update
    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("titleScreen");
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }
}
