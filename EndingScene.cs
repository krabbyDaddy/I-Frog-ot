using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndingScene : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject sceneCamera;
    [SerializeField]
    private FirstPersonController playerScript;
    [SerializeField]
    private PlayableDirector sceneDirector;

    public void PlayEndingScene()
    {
        sceneCamera.SetActive(true);
        mainCamera.SetActive(false);
        sceneDirector.Play();
        playerScript.canCameraMove = false;
        playerScript.canPlayerMove = false;
    }
        public void Ending()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
