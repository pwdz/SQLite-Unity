using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextScene() {
        Debug.Log("###############################################");
        int index = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(index+1);
    }
}
