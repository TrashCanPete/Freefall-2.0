using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour
{
    public FlyingStates flyingStates;

    [SerializeField]
    private Slider fuel;

    [SerializeField]
    Image UITankImage;

    [SerializeField]
    float FlashRate;

    [SerializeField]
    float CurrentLerp;

    [SerializeField]
    Color BaseColor;

    [SerializeField]
    Color FlashColor;

    public bool Flashing;
    public bool LerpGoingUp;

   

    // Start is called before the first frame update
    void Start()
    {
        
        fuel = GetComponent<Slider>();
        fuel.maxValue = flyingStates.maxBoostFuel;
        fuel.value = flyingStates.boostFuel;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Flashing)
        {
            if (LerpGoingUp)
            {
                CurrentLerp += (Time.deltaTime * FlashRate);
                if (CurrentLerp > 1)
                {
                    CurrentLerp = 1;
                    LerpGoingUp = false;
                }
            }
            else
            {
                CurrentLerp -= (Time.deltaTime * FlashRate);
                if (CurrentLerp < 0)
                {
                    CurrentLerp = 0;
                    LerpGoingUp = true;
                }
            }

            UITankImage.color = Color.Lerp(BaseColor, FlashColor, CurrentLerp);
        }
        else
        {
            UITankImage.color = BaseColor;
        }

        fuel.value = flyingStates.boostFuel;

        
    }
}
