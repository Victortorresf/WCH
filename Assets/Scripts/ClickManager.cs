using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class ClickManager : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    public AudioSource audioClick;
    public AudioClip clip;
    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {       
        audioClick.clip = clip;
        audioClick.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        isPaused = PauseMenu.isPaused;
        if (!isPaused)
        {
            if (Input.GetMouseButtonDown(0) && !FindObjectOfType<DialogueRunner>().IsDialogueRunning)
            {
                Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
                if (hit)
                {
                    IClickable clickable = hit.collider.GetComponent<IClickable>();
                    clickable?.Click();
                    audioClick.Play();
                }
            }
        }
    }
}
