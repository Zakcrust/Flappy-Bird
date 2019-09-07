using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadScene(string name)
    {
        Debug.Log("button clicked");
        if(!string.IsNullOrEmpty(name))
        {
            Debug.Log("scene changed");
            SceneManager.LoadScene(name);
        }
    }

}
