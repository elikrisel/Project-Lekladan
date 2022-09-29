using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsNav : MonoBehaviour
{
    public void BacktoTitle()
    {
        SceneManager.LoadScene("OlleMenuIntegration");
    }
}
