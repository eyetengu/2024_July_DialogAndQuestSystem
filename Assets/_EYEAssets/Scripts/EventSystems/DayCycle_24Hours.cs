using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle_24Hours : MonoBehaviour
{
    //Delegates
    public delegate void Dawn();
    public delegate void Morning();
    public delegate void Noon();
    public delegate void Afternoon();
    public delegate void Dusk();
    public delegate void EarlyEvening();
    public delegate void Midnight();
    public delegate void LateEvening();
    public delegate void Day();
    public delegate void Night();

    public delegate void NewDay();

    //Events
    public static event Dawn dawn;
    public static event Morning morning;
    public static event Noon noon;
    public static event Afternoon afternoon;
    public static event Dusk dusk;
    public static event EarlyEvening earlyEvening;
    public static event Midnight midnight;
    public static event LateEvening lateEvening;
    public static event Day day;
    public static event Night night;

    public static event NewDay newDay;


    [SerializeField] private UI_Manager _uiManager;             //the ui manager reference to display data
    [SerializeField] private Transform _universalCenter;        //the transform origin of the sun/moon rotation

    [SerializeField] private float _hourDurationSec = 1;        //the hour is measured in seconds(float)
    private float _lengthOfDay;                                 //this value is a product of 24(hours) * _hourDurationSec
    [SerializeField] private float _universeSpeed = 2;          //the speed of the rotation of the sun/moon
    [SerializeField] private float _orbitMultiplier = 7.47744f; //off by -.072. This might not seem like much but the faster the time elapses the more 'off' the day cycle will become.

    private string _stateString;                                //when a state has a name it is stored here

    private int _hourID;                                        //the integer form of the time(hour)
    private int _dayYear;                                       //the max days of the year: 364(zero-indexed)
    private int _dayMonth;                                      //max: 6(zero-indexed)
    private int _month;
    private int _year;                                          //which year is it

    private bool _isDay;                                        //day and night will have individual needs when it comes to lighting

    //public delegate void ActionClick();
    //public static event ActionClick actionClick;
    //public static event ActionClick actionClick2;


    private void Start()
    {
        _lengthOfDay = _hourDurationSec * 24;

        FiniteStateMachine_DayCycle();
        
    }

    private void Update()
    {
        RotateUniverse();
    }
    
    //UNIVERSE
    void RotateUniverse()
    {
        _universalCenter.Rotate(0, 0, _universeSpeed * _orbitMultiplier * Time.deltaTime);
    }

    //Progress through the day
    void NextHour()
    {
        _hourID++;

        if (_hourID >= 24)          //Increase Day Integer
        {
            _hourID = 0;
            _dayMonth++;
            newDay();
            _dayYear++;

            if (_dayMonth > 29)     //Increase Month integer
            {
                _dayMonth = 0;
                _month++;

                if (_month > 11)      //Increase Year integer
                {
                    _month = 0;
                    _year++;
                }
            }
        }
        FiniteStateMachine_DayCycle();
    }

    //FINITE STATE MACHINE
    void FiniteStateMachine_DayCycle()
    {
        switch (_hourID)
        {
            case 0:         _stateString = "Midnight";              midnight();                                         break;
            case 1:         _stateString = "Late Evening";          lateEvening();                                      break;
            case 2:                                                                                                     break;
            case 3:                                                                                                     break;
            case 4:                                                                                                     break;
            case 5:         _stateString = "Dawn";                  dawn();                _isDay = true;               break;
            case 6:                                                 day();                                              break;
            case 7:         _stateString = "Morning";                                                                   break;
            case 8:                                                                                                     break;
            case 9:                                                                                                     break;
            case 10:                                                                                                    break;
            case 11:                                                                                                    break;
            case 12:        _stateString = "Noon";                  noon();                                             break;
            case 13:                                                                                                    break;
            case 14:        _stateString = "Afternoon";                                                                 break;
            case 15:                                                                                                    break;
            case 16:                                                                                                    break;
            case 17:        _stateString = "Dusk";                  dusk();                                             break;
            case 18:                                                                                                    break;
            case 19:                                                                                                    break;
            case 20:        _stateString = "Early Evening";         earlyEvening();         _isDay = false;             break;
            case 21:                                                                                                    break;
            case 22:                                                                                                    break;
            case 23:                                                                                                    break;
            default:                                                                                                    break;
        }
        UpdateUI();
        StartCoroutine(HourLength());
    }

    //UI FUNCTIONS
    void UpdateUI()
    {
        var dayOfYear = _dayYear + 1;
        _uiManager.UpdateUIMessage(_stateString, _hourID, dayOfYear);
    }

    //COROUTINES
    IEnumerator HourLength()
    {
        yield return new WaitForSeconds(_hourDurationSec);
        NextHour();
    }
}
