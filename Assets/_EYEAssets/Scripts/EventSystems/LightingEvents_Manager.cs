using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingEvents_Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] _lightPalettes;
    [SerializeField] private int _lightingID;


    //BUILT-IN FUNCTIONS
    private void OnEnable()
    {
        DayCycle_24Hours.newDay         += newDay;
        DayCycle_24Hours.day            += Day;

        DayCycle_24Hours.dawn           += DawnLight;
        DayCycle_24Hours.noon           += NoonLight;
        DayCycle_24Hours.dusk           += DuskLight;
        DayCycle_24Hours.earlyEvening   += EarlyEveningLight;
        DayCycle_24Hours.midnight       += MidnightLight;
        DayCycle_24Hours.lateEvening    += LateEveningLight;
    }

    void Start()
    {
        ClearAllLights();
        DisplayCurrentLight();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            _lightingID++;

            if (_lightingID > _lightPalettes.Length - 1)
                _lightingID = 0;

            ClearAllLights();
            DisplayCurrentLight();
        }
    }

    private void OnDisable()
    {
        DayCycle_24Hours.newDay         -= newDay;
        DayCycle_24Hours.day            -= Day;

        DayCycle_24Hours.dawn           -= DawnLight;
        DayCycle_24Hours.noon           -= NoonLight;
        DayCycle_24Hours.dusk           -= DuskLight;
        DayCycle_24Hours.earlyEvening   -= EarlyEveningLight;
        DayCycle_24Hours.midnight       -= MidnightLight;
        DayCycle_24Hours.lateEvening    -= LateEveningLight;
    }

    //LIGHT SETTING FUNCTIONS
    void ClearAllLights()
    {
        foreach (var light in _lightPalettes)
        {
            light.SetActive(false);
        }
    }

    void DisplayCurrentLight()
    {
        _lightPalettes[_lightingID].SetActive(true);
    }

    void SelectNewLighting()
    {
        _lightingID++;

        if (_lightingID > _lightPalettes.Length - 1)
            _lightingID = 0;

        ClearAllLights();
        DisplayCurrentLight();
    }

    //DELEGATE CALLED FUNCTIONS
    //Day Functions
    void newDay()               {       }
    void Day()                  {       }

    //Lighting Functions
    void DawnLight()            {   SelectNewLighting();    }
    void NoonLight()            {   SelectNewLighting();    }
    void DuskLight()            {   SelectNewLighting();    }
    void EarlyEveningLight()    {   SelectNewLighting();    }
    void MidnightLight()        {   SelectNewLighting();    }
    void LateEveningLight()     {   SelectNewLighting();    }    
}
