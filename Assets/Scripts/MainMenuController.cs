using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnLoadStartGame()
    {
        SceneManager.LoadSceneAsync("Scene_1");
    }
}
