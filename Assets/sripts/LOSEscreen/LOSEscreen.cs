using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LOSEscreen : MonoBehaviour
{
    public void CloseGame()
    {
        Application.Quit();
    }
        public void ReplayLevel()
        {
            SceneManager.LoadScene(SceneID.gameSceneID);
        }
}
