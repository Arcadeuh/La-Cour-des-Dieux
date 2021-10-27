// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""b8ad89e6-7f32-4e8f-ac46-2cc15b512750"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""fc3f1699-34dc-41e9-9353-f992c6eeae9f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""25be5725-6da8-4c76-b093-c60bc43983a4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""North"",
                    ""type"": ""Button"",
                    ""id"": ""5e6386f4-b857-41b2-865b-54fa9d02e045"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""East"",
                    ""type"": ""Button"",
                    ""id"": ""af7fc2c4-563b-45ee-9cde-456f72f3f2b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""West"",
                    ""type"": ""Button"",
                    ""id"": ""52e24785-68fc-45ec-b4a5-ca26d38a28aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""South"",
                    ""type"": ""Button"",
                    ""id"": ""cf6206b3-c9e4-45c4-8c85-4bd9bb99de8c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Right Trigger"",
                    ""type"": ""Button"",
                    ""id"": ""3f63642d-59d1-4600-8984-7f841a680660"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Left Trigger"",
                    ""type"": ""Button"",
                    ""id"": ""c51c19b6-11e9-4a67-9179-de06804a6a29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Shoulder"",
                    ""type"": ""Button"",
                    ""id"": ""05aa0213-d483-4887-9242-ea716d44a8dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Shoulder"",
                    ""type"": ""Button"",
                    ""id"": ""8089df75-5723-4067-b46d-0193328e4ea3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fc07ac02-a451-4d73-931d-937cd360060d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55267d18-c2e5-4652-8b4a-19cbbd640622"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89d2e48a-631f-4500-929f-3380f293b76b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d659651-acb9-4916-8c24-d6cd73834179"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""East"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b73068b6-2397-4a03-9056-833a3d0c4f58"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f303ee0-aedb-440f-ae3a-1b636bd544dd"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""South"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92411c86-182a-44ae-ad8a-6c2953d8ebfc"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""038404ce-64c4-4fec-9906-64f955e15062"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1ad88a2-5827-43fb-983d-bd969cb5b237"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Shoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""137671e9-0142-4d77-8d1b-753816401f46"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Shoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Rotate = m_Gameplay.FindAction("Rotate", throwIfNotFound: true);
        m_Gameplay_North = m_Gameplay.FindAction("North", throwIfNotFound: true);
        m_Gameplay_East = m_Gameplay.FindAction("East", throwIfNotFound: true);
        m_Gameplay_West = m_Gameplay.FindAction("West", throwIfNotFound: true);
        m_Gameplay_South = m_Gameplay.FindAction("South", throwIfNotFound: true);
        m_Gameplay_RightTrigger = m_Gameplay.FindAction("Right Trigger", throwIfNotFound: true);
        m_Gameplay_LeftTrigger = m_Gameplay.FindAction("Left Trigger", throwIfNotFound: true);
        m_Gameplay_RightShoulder = m_Gameplay.FindAction("Right Shoulder", throwIfNotFound: true);
        m_Gameplay_LeftShoulder = m_Gameplay.FindAction("Left Shoulder", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Rotate;
    private readonly InputAction m_Gameplay_North;
    private readonly InputAction m_Gameplay_East;
    private readonly InputAction m_Gameplay_West;
    private readonly InputAction m_Gameplay_South;
    private readonly InputAction m_Gameplay_RightTrigger;
    private readonly InputAction m_Gameplay_LeftTrigger;
    private readonly InputAction m_Gameplay_RightShoulder;
    private readonly InputAction m_Gameplay_LeftShoulder;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Rotate => m_Wrapper.m_Gameplay_Rotate;
        public InputAction @North => m_Wrapper.m_Gameplay_North;
        public InputAction @East => m_Wrapper.m_Gameplay_East;
        public InputAction @West => m_Wrapper.m_Gameplay_West;
        public InputAction @South => m_Wrapper.m_Gameplay_South;
        public InputAction @RightTrigger => m_Wrapper.m_Gameplay_RightTrigger;
        public InputAction @LeftTrigger => m_Wrapper.m_Gameplay_LeftTrigger;
        public InputAction @RightShoulder => m_Wrapper.m_Gameplay_RightShoulder;
        public InputAction @LeftShoulder => m_Wrapper.m_Gameplay_LeftShoulder;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @North.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNorth;
                @North.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNorth;
                @North.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNorth;
                @East.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEast;
                @East.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEast;
                @East.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEast;
                @West.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWest;
                @West.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWest;
                @West.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWest;
                @South.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSouth;
                @South.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSouth;
                @South.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSouth;
                @RightTrigger.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightTrigger;
                @LeftTrigger.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftTrigger;
                @RightShoulder.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightShoulder;
                @RightShoulder.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightShoulder;
                @RightShoulder.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightShoulder;
                @LeftShoulder.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftShoulder;
                @LeftShoulder.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftShoulder;
                @LeftShoulder.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftShoulder;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @North.started += instance.OnNorth;
                @North.performed += instance.OnNorth;
                @North.canceled += instance.OnNorth;
                @East.started += instance.OnEast;
                @East.performed += instance.OnEast;
                @East.canceled += instance.OnEast;
                @West.started += instance.OnWest;
                @West.performed += instance.OnWest;
                @West.canceled += instance.OnWest;
                @South.started += instance.OnSouth;
                @South.performed += instance.OnSouth;
                @South.canceled += instance.OnSouth;
                @RightTrigger.started += instance.OnRightTrigger;
                @RightTrigger.performed += instance.OnRightTrigger;
                @RightTrigger.canceled += instance.OnRightTrigger;
                @LeftTrigger.started += instance.OnLeftTrigger;
                @LeftTrigger.performed += instance.OnLeftTrigger;
                @LeftTrigger.canceled += instance.OnLeftTrigger;
                @RightShoulder.started += instance.OnRightShoulder;
                @RightShoulder.performed += instance.OnRightShoulder;
                @RightShoulder.canceled += instance.OnRightShoulder;
                @LeftShoulder.started += instance.OnLeftShoulder;
                @LeftShoulder.performed += instance.OnLeftShoulder;
                @LeftShoulder.canceled += instance.OnLeftShoulder;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnNorth(InputAction.CallbackContext context);
        void OnEast(InputAction.CallbackContext context);
        void OnWest(InputAction.CallbackContext context);
        void OnSouth(InputAction.CallbackContext context);
        void OnRightTrigger(InputAction.CallbackContext context);
        void OnLeftTrigger(InputAction.CallbackContext context);
        void OnRightShoulder(InputAction.CallbackContext context);
        void OnLeftShoulder(InputAction.CallbackContext context);
    }
}
