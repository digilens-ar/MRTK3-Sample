using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MixedReality.Toolkit.UX;
using TMPro;

public class MenuStateController : MonoBehaviour
{

    [SerializeField]
    GameObject pageBtn1, pageBtn2, pageBtn3;

    [SerializeField]
    GameObject nextBtn, prevBtn;

    [SerializeField]
    GameObject textBtn1, textBtn2, textBtn3, txtBtnPrev, txtBtnNext;

    [SerializeField]
    GameObject  handObjs, voiceObj;

    PressableButton pressablePageBtn1, pressablePageBtn2, pressablePageBtn3;
    PressableButton pressableNextBtn, pressablePrevBtn;

    [SerializeField]
    GameObject handMenu, scrollMenu, voiceMenu;

    [SerializeField] 
    TMPro.TMP_Text txtBtnTitle;

    /// <summary>
    /// States:
    /// 1 - page 1
    /// 2 - page 2
    /// 3 - page 3
    /// </summary>
    int currentState;
    int prevState;


    /// <summary>
    /// Initialize state and variables
    /// </summary>
    void Start()
    {
        prevState = 1;
        currentState = 1;
        InitVariables();
    }

    /// <summary>
    /// Initializes buttons
    /// </summary>
    void InitVariables()
    {
        pressablePageBtn1 = pageBtn1.GetComponent<PressableButton>();
        pressablePageBtn2 = pageBtn2.GetComponent<PressableButton>();
        pressablePageBtn3 = pageBtn3.GetComponent<PressableButton>();
        pressableNextBtn = nextBtn.GetComponent<PressableButton>();
        pressablePrevBtn = prevBtn.GetComponent<PressableButton>();

    }


    public void OnPrevClick()
    {
        
        if (currentState > 1) //only decrease state if larger than 1, otherwise do nothing
        {
            currentState--;
            
        }

        UpdateState(currentState);
    }

    /// <summary>
    /// Sets state to the next state
    /// </summary>
    public void OnNextClick()
    {

        if (currentState < 3) //only increase state if current state is less than 3, otherwise do nothing
        {
            currentState++;
           
        }

        UpdateState(currentState);
    }

    /// <summary>
    /// Button 1 click event. Sets state to 1 and activates corresponding menus and objects
    /// </summary>
    public void OnBtn1Click()
    {
        currentState = 1;
        UpdateState(currentState);
    }

    /// <summary>
    /// Button 2 click event. Sets state to 2 and activates corresponding menus and objects
    /// </summary>
    public void OnBtn2Click()
    {
        currentState = 2;
        UpdateState(currentState);
    }

    /// <summary>
    /// Button 3 click event. Sets state to 3 and activates corresponding menus and objects
    /// </summary>
    public void OnBtn3Click()
    {
        currentState = 3;
        UpdateState(currentState);
    }

    /// <summary>
    /// Activates handtracking menu and visually indicates page 1 is active
    /// </summary>
    void ActivateHandMenu()
    {
        handMenu.SetActive(true);
        ResetSelectedColor(textBtn1, true);
        ResetSelectedColor(txtBtnPrev, true);
        pressablePrevBtn.enabled = false;
        pressablePageBtn1.enabled = false;
        Debug.Log("Hand menu activated");
    }

    /// <summary>
    /// Deactivates handtracking menu and resets visuals
    /// </summary>
    void DeactivateHandMenu()
    {
        if (!handMenu.activeInHierarchy) //if already deactivated, skip
        {
            return;
        }

        handMenu.SetActive(false);
        ResetSelectedColor(textBtn1, false);
        ResetSelectedColor(txtBtnPrev, false);
        pressablePrevBtn.enabled = true;
        pressablePageBtn1.enabled = true;
    }

    /// <summary>
    /// Activates scroll menu and visually indicates page 2 is active
    /// </summary>
    void ActivateScrollMenu()
    {
        scrollMenu.SetActive(true);
        ResetSelectedColor(textBtn2, true);
        pressablePageBtn2.enabled = false;

        Debug.Log("scroll menu activated");
    }

    /// <summary>
    /// Deactivates scroll menu and resets visuals
    /// </summary>
    void DeactivateScrollMenu()
    {
        if (!scrollMenu.activeInHierarchy)//if already deactivated, skip
        {
            return;
        }

        scrollMenu.SetActive(false);
        ResetSelectedColor(textBtn2, false);
        pressablePageBtn2.enabled = true;

    }


    /// <summary>
    /// Activates voice menu and visually indicates page 3 is active
    /// </summary>
    void ActivateVoiceMenu()
    {
        voiceMenu.SetActive(true);
        ResetSelectedColor(textBtn3, true);
        ResetSelectedColor(txtBtnNext, true);
        pressableNextBtn.enabled = false;
        pressablePageBtn3.enabled = false;
        voiceObj.SetActive(true);
        Debug.Log("activated voice menu");
    }

    /// <summary>
    /// Deactivates voice menu and resets visuals
    /// </summary>
    void DeactivateVoiceMenu()
    {
        if (!voiceMenu.activeInHierarchy)//if already deactivated, skip
        {
            return;
        }

        voiceMenu.SetActive(false);
        ResetSelectedColor(textBtn3, false);
        ResetSelectedColor(txtBtnNext, false);
        pressableNextBtn.enabled = true;
        pressablePageBtn3.enabled = true;
        voiceObj.SetActive(false);

    }

    /// <summary>
    /// Updates the state behaviors
    /// </summary>
    void UpdateState(int state)
    {
        if (state == prevState) //If no change, do nothing
        {
            Debug.Log("no change");
            return;
        }

        switch (state)
        {
            case 1:
                Debug.Log("case1");
                DeactivateScrollMenu();
                DeactivateVoiceMenu();
                ActivateHandMenu();
                txtBtnTitle.text = "MRTK Hand Tracking";
               
                break;
            case 2:
                Debug.Log("case2");
                DeactivateHandMenu();
                DeactivateVoiceMenu();
                ActivateScrollMenu();
                txtBtnTitle.text = "Scroll Wheel Demo";
               
                break;
            case 3:
                Debug.Log("case3");
                DeactivateHandMenu();
                DeactivateScrollMenu();
                ActivateVoiceMenu();
                txtBtnTitle.text = "Voice UI Demo";
                
                break;
            default:
                break;
        }

        Debug.Log("Page number " + state);
        prevState = currentState;
    }

    /// <summary>
    /// Changes button color to either interactable or non interactable
    /// </summary>
    /// <param name="btn"></param>
    /// <param name="interactable"></param>
    void ResetSelectedColor(GameObject btn, bool selected)
    {
        GameObject selectedBtn, defaultBtn;

        selectedBtn = btn.transform.Find("Selected").gameObject;
        defaultBtn = btn.transform.Find("Default").gameObject; 

        selectedBtn.SetActive(selected);
        defaultBtn.SetActive(!selected);
        
        
    }

    

   
}
