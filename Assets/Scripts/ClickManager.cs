using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class ClickManager : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    AudioSource audioClick;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audioClick = FindObjectOfType<AudioSource>();
        audioClick.clip = clip;
        audioClick.loop = false;
    }

    // Update is called once per frame
    void Update()
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
