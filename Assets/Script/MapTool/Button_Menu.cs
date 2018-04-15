using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.
using System;

public class Button_Menu
    : MonoBehaviour
    , IPointerEnterHandler  // required interface when using the OnPointerEnter method.
    , IPointerExitHandler   // required interface when using the OnPointerExit method.
    , IPointerDownHandler   // required interface when using the OnPointerDown method.
    , ISelectHandler        // required interface when using the OnSelect method.
    , IDeselectHandler      //This Interface is required to receive OnDeselect callbacks.
{
    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {

    }

    //Do this when the cursor enters the rect area of this selectable UI object.
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
    }

    //Do this when the cursor exits the rect area of this selectable UI object.
    //앞에 public 키워드를 붙일라면 IPointerExitHandler 을 없애야하넹
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("The cursor exited the selectable UI element.");
    }

    //Do this when the mouse is clicked over the selectable object this script is attached to.
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
    }

    //Do this when the selectable UI object is selected.
    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");
    }

    void IDeselectHandler.OnDeselect(BaseEventData eventData)
    {
        Debug.Log("Deselected");
    }

    /*
     * This function is not called on objects that belong to Ignore Raycast layer.
     * This function is called on Colliders marked as Trigger if and only if Physics.queriesHitTriggers is true.
     * https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseOver.html
    
    void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter");
    }
    void OnMouseOver()
    {
        Debug.Log("OnMouseOver");
    }
    void OnMouseExit()
    {
        Debug.Log("OnMouseExit");
    }
    */
}
