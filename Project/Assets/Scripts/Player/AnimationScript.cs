using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Animator anim;
    public AnimationScript animationScript;
    private InputManager inputManager;

    public bool rollLeft;
    public bool rollRight;


    // Start is called before the first frame update
    void Start()
    {
        animationScript = GetComponent<AnimationScript>();
        inputManager = GetComponent<InputManager>();

        anim.SetBool("Rolling_Left", false);

    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        //Calling blend tree function
        Move(x, y);

        if (rollRight == true)
        {
            anim.SetBool("Rolling_Right", true);
        }
        else if (rollRight == false)
        {
            anim.SetBool("Rolling_Right", false);
        }

        if(rollLeft == true)
        {
            anim.SetBool("Rolling_Left", true);
        }
        else if(rollLeft == false)
        {
            anim.SetBool("Rolling_Left", false);
        }
        


    }

    //Blend tree Function
    public void Move(float x, float y)
    {
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }


}
