using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CursorController : MonoBehaviour
{
    //[SerializeField, Tooltip("Main Cursor")]
    public Texture2D cursor;

    //[SerializeField, Tooltip("Clicked Cursor")]
    public Texture2D cursorClicked;

    public CursorControls controls;

    

    private void Awake()
    {
        controls = new CursorControls();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    private void Start()
    {
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
    }

    private void StartedClick()
    {
        ChangeCursor(cursorClicked);

    }


    private void EndedClick()
    {
        ChangeCursor(cursor);
        //Vector2 mousePosition = mouseInput.Mouse.mousePosition.ReadValue<Vector2>();
        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);



    }
    


    private void ChangeCursor(Texture2D cursorType)
    {
        Vector2 hotspot = new Vector2(cursorType.width, cursorType.height);
        Cursor.SetCursor(cursorType, hotspot, CursorMode.ForceSoftware);


    }


}

