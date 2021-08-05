using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameManager : MonoBehaviour
{
    public enum GameState { Setup, Game, Menu };
    public GameState gState;

    private void Update()
    {

    }
}
