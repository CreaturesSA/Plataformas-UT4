using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayGame : MonoBehaviour
{
    // Update is called once per frame
    public void PlayGameScene()
    {
        SCManager.instance.LoadScene("Level1");
    }

    public void InstructionScene()
    {
        SCManager.instance.LoadScene("Instructions");
    }

    public void goMenu()
    {
        SCManager.instance.LoadScene("Menu");
    }
}
