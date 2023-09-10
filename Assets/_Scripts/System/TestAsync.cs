using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestAsync : MonoBehaviour
{
    public void TestAsyncFunc()
    {
        LoadingScreenGUI.Instance.StartLoadScene("Endless Scene");
    }
}
