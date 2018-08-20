using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelector : MonoBehaviour {
    public void SelectStage1()
    {
        SceneManager.LoadScene(1);
    }
    public void SelectStage2()
    {
        SceneManager.LoadScene(2);
    }
    public void SelectStage3()
    {
        SceneManager.LoadScene(3);
    }

}
