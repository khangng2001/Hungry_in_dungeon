using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadNewScene", 5f);
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene("TestSingleton");
    }
}
