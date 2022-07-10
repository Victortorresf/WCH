using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    GameObject album;

    [SerializeField] Animation anim;

    public void StartAnim(GameObject gameOb)
    {
        anim.Play();
        album = gameOb;
    }

    void Update()
    {
        if (anim["Book Open"].time >= 1.45f && anim.isPlaying)
        {
            album.SetActive(true);
        }
    }
}
