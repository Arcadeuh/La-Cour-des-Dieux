using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users; 

public class GamepadCursor : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform cursorTransform;
    [SerializeField] private RectTransform canvasRectTransform;
    [SerializeField] private float cursorSpeed = 1000.0f;

    private Camera mainCamera;
    private bool previousMouseState;
    private Mouse virtualMouse;

   
    void Start()
    {

    }

    private void OnEnable()
    {
        cursorTransform.position = new Vector3(0, 0, 0);
        Debug.Log(cursorTransform.position);

        mainCamera = Camera.main;   // IL FAUT QUE LA CAMERA AIT LE TAG MAINCAMERA

        if (virtualMouse == null)
            virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");
        
        else if (!virtualMouse.added)
            InputSystem.AddDevice(virtualMouse);
        

        InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

        if(cursorTransform != null)
        {
            Vector2 position = new Vector2(Screen.width / 2, Screen.height / 2);
            InputState.Change(virtualMouse.position, position);
        }

        InputSystem.onAfterUpdate += UpdateMotion;

    }

    private void OnDisable()
    {
        if(virtualMouse != null && virtualMouse.added) InputSystem.RemoveDevice(virtualMouse);
        InputSystem.onAfterUpdate -= UpdateMotion;
    }

    private void UpdateMotion()
    {
        if(virtualMouse == null || Gamepad.current == null) { return; }

        Vector2 deltaValue = Gamepad.current.leftStick.ReadValue();
        deltaValue *= cursorSpeed * Time.deltaTime;

        Vector2 currentPosition = virtualMouse.position.ReadValue();
        Vector2 newPoisition = currentPosition + deltaValue;

        newPoisition.x = Mathf.Clamp(newPoisition.x, 0, Screen.width);
        newPoisition.y = Mathf.Clamp(newPoisition.y, 0, Screen.height);

        InputState.Change(virtualMouse.position, newPoisition);
        InputState.Change(virtualMouse.delta, deltaValue);


        bool aButtonIsPressed = Gamepad.current.aButton.isPressed;
        if (previousMouseState != aButtonIsPressed)
        {
            virtualMouse.CopyState<MouseState>(out var mouseState);
            mouseState.WithButton(MouseButton.Left, aButtonIsPressed);
            InputState.Change(virtualMouse, mouseState);
            previousMouseState = aButtonIsPressed;
        }


        AnchorCursor(newPoisition);
    }

    private void AnchorCursor(Vector2 position)
    {
        Vector2 anchorPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, position, 
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : mainCamera, out anchorPosition );

        cursorTransform.anchoredPosition = anchorPosition;
    }
}
