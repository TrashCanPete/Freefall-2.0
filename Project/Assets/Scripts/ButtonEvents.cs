using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    private void OnMouseEnter()
    {
        FindObjectOfType<AudioManager>().PlayAudio("Button Highlight");
    }
}
