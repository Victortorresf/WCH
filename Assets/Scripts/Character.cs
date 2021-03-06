using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class Character : MonoBehaviour, IClickable
{

    public string NPC;
    private string loadAudio;
    private bool coroutineAllowed;
    private bool coroutineAllowed2;
    private bool hadHovered;


    void Start()
    {
        coroutineAllowed = true;
        coroutineAllowed2 = true;
        hadHovered = false;
    }

    public void Click()
    {
        FindObjectOfType<DialogueRunner>().StartDialogue(NPC);
    }

    private void OnMouseOver()
    {
        bool ispaused = PauseMenu.isPaused;
        if (!ispaused)
        {
            if (coroutineAllowed && !FindObjectOfType<DialogueRunner>().IsDialogueRunning)
            {
                StartCoroutine("ScaleUp");
                hadHovered = true;
            }
        }
    }

    private void OnMouseExit()
    {
        bool ispaused = PauseMenu.isPaused;
        if (coroutineAllowed2 && hadHovered && !ispaused)
        {
           StartCoroutine("ScaleDown");
            hadHovered = false;
        }
         
        coroutineAllowed = true;
    }

    private IEnumerator ScaleUp()
    {
        coroutineAllowed = false;

        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            transform.localScale= new Vector3(
            (Mathf.Lerp(transform.localScale.x, transform.localScale.x + 0.025f, Mathf.SmoothStep (0f, 0.2f, i))),
            (Mathf.Lerp(transform.localScale.y, transform.localScale.y + 0.025f, Mathf.SmoothStep(0f, 0.2f, i))),
            (Mathf.Lerp(transform.localScale.z, transform.localScale.z + 0.025f, Mathf.SmoothStep(0f, 0.2f, i)))
            );
            yield return new WaitForSeconds(0.05f);
        }
        coroutineAllowed2 = true;
    }

    private IEnumerator ScaleDown()
    {
        coroutineAllowed = false;

        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            transform.localScale = new Vector3(
            (Mathf.Lerp(transform.localScale.x, transform.localScale.x - 0.025f, Mathf.SmoothStep(0f, 0.2f, i))),
            (Mathf.Lerp(transform.localScale.y, transform.localScale.y - 0.025f, Mathf.SmoothStep(0f, 0.2f, i))),
            (Mathf.Lerp(transform.localScale.z, transform.localScale.z - 0.025f, Mathf.SmoothStep(0f, 0.2f, i)))
            );
            yield return new WaitForSeconds(0.05f);
        }

    }
}
