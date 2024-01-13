using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayGame : MonoBehaviour
{
    // Update is called once per frame
    public void PlayGameScene()
    {
        FruitController.fruitScore = 0;
        SCManager.instance.LoadScene("Level1");
    }
}
