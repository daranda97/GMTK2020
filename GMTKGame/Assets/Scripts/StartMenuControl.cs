using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuControl : MonoBehaviour
{



    void ChangeScene()
    {
        SceneManager.LoadScene("SceneName", LoadSceneMode.single);
    }

}
