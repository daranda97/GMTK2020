using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuControl : MonoBehaviour
{

    public Animator animator;

    public void Fade()
    {
        animator.SetTrigger("FadeOut");
    }

    public void ChangeScene()
    {
            SceneManager.LoadScene(1);
        
    }

}
