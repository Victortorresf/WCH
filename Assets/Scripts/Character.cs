using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class Character : MonoBehaviour, IClickable
{

    public string NPC;


    public void Click()
    {
        FindObjectOfType<DialogueRunner>().StartDialogue(NPC);
    }

}
