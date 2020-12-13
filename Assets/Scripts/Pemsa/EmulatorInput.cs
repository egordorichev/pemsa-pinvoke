// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Pemsa/EmulatorInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @EmulatorInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @EmulatorInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""EmulatorInput"",
    ""maps"": [
        {
            ""name"": ""PemsaControls"",
            ""id"": ""b938d8b8-2e0e-4d90-94e2-bddcd5d0d5df"",
            ""actions"": [
                {
                    ""name"": ""Z"",
                    ""type"": ""Button"",
                    ""id"": ""ab16c33a-7656-4c64-94ad-b0601ae029ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""eafcdac2-a5ac-498f-a230-abc5ebab2ca7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""7324d2f2-252d-41b5-b85b-410fdbd41937"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""d1a20eda-b387-41df-a31e-2dea0ff64856"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""e46753eb-b773-4da2-9bd9-66e08592b2f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""081e9d7a-d891-4bdf-8c45-e62a356efa7c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""65176cf4-eab4-4041-a4bf-0323db391074"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b7ffb6a-3592-410d-9afb-67c728a21fa8"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24f7f600-aaad-4f65-9b7b-a55a85cfc201"",
                    ""path"": ""<SwitchProControllerHID>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa451efb-522c-48be-b24d-410110fd018b"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d0e6c95-03fd-4e0c-8471-0d59b3c4f707"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0718575-cc36-4550-827a-3bc199987a8a"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b68d9512-59eb-448b-bebe-56c3213ba26b"",
                    ""path"": ""<SwitchProControllerHID>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fd8953c-0343-45e4-947a-505db912c0d1"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b31fe1f-a5ba-4b5a-850c-cffdec55d6bf"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""179bdd87-5a14-489d-ac95-d52ba8f1dc49"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""e5f8ff1c-ea2e-4e5f-ac38-13179e331f8d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3da5c0cc-5b97-4126-9388-0ef88787359f"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f9268c53-4fc9-4b04-8141-09b7d4b7bc6c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de626dee-e809-4ba2-9802-3ffd76a20d3c"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""43dae21b-ba96-44fe-8e45-7f6bb90da58d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c53456d9-6175-4c89-8236-04a3cbb6b57b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""110ff2d4-3c85-4967-bc54-b433ea171a0d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b378df6-1290-4ca6-8c41-a4fc1d9a9d32"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""570cc0b1-efc3-4b68-9515-b9a44234abf9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""148769ee-24f0-4e4a-8084-995bee52d071"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7f68fdb8-21c3-4c76-b59d-6432e5807f4b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ca2d8fd-6756-4198-9e52-eeaf1a4bd3f4"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""7ae6f3ae-2fee-4914-a417-d2e229e6ded3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c30a7766-a1c3-4796-a597-7548f5d9dfa6"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<AndroidGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<iOSGameController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<SwitchProControllerHID>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<WebGLGamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PemsaControls
        m_PemsaControls = asset.FindActionMap("PemsaControls", throwIfNotFound: true);
        m_PemsaControls_Z = m_PemsaControls.FindAction("Z", throwIfNotFound: true);
        m_PemsaControls_X = m_PemsaControls.FindAction("X", throwIfNotFound: true);
        m_PemsaControls_Up = m_PemsaControls.FindAction("Up", throwIfNotFound: true);
        m_PemsaControls_Down = m_PemsaControls.FindAction("Down", throwIfNotFound: true);
        m_PemsaControls_Left = m_PemsaControls.FindAction("Left", throwIfNotFound: true);
        m_PemsaControls_Right = m_PemsaControls.FindAction("Right", throwIfNotFound: true);
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

    // PemsaControls
    private readonly InputActionMap m_PemsaControls;
    private IPemsaControlsActions m_PemsaControlsActionsCallbackInterface;
    private readonly InputAction m_PemsaControls_Z;
    private readonly InputAction m_PemsaControls_X;
    private readonly InputAction m_PemsaControls_Up;
    private readonly InputAction m_PemsaControls_Down;
    private readonly InputAction m_PemsaControls_Left;
    private readonly InputAction m_PemsaControls_Right;
    public struct PemsaControlsActions
    {
        private @EmulatorInput m_Wrapper;
        public PemsaControlsActions(@EmulatorInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Z => m_Wrapper.m_PemsaControls_Z;
        public InputAction @X => m_Wrapper.m_PemsaControls_X;
        public InputAction @Up => m_Wrapper.m_PemsaControls_Up;
        public InputAction @Down => m_Wrapper.m_PemsaControls_Down;
        public InputAction @Left => m_Wrapper.m_PemsaControls_Left;
        public InputAction @Right => m_Wrapper.m_PemsaControls_Right;
        public InputActionMap Get() { return m_Wrapper.m_PemsaControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PemsaControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPemsaControlsActions instance)
        {
            if (m_Wrapper.m_PemsaControlsActionsCallbackInterface != null)
            {
                @Z.started -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnZ;
                @Z.performed -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnZ;
                @Z.canceled -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnZ;
                @X.started -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnX;
                @X.performed -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnX;
                @X.canceled -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnX;
                @Up.started -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_PemsaControlsActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_PemsaControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Z.started += instance.OnZ;
                @Z.performed += instance.OnZ;
                @Z.canceled += instance.OnZ;
                @X.started += instance.OnX;
                @X.performed += instance.OnX;
                @X.canceled += instance.OnX;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public PemsaControlsActions @PemsaControls => new PemsaControlsActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    public interface IPemsaControlsActions
    {
        void OnZ(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
