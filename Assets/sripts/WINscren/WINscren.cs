using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WINscren : MonoBehaviour

{
    public void CloseGame()
    {
        Application.Quit();
    }
        public void NEXTLevel()
        {
            SceneManager.LoadScene(SceneID.gameSceneID);
        }
}


