//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Controls/CustomControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @CustomControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CustomControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CustomControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""90041b90-17f4-4ac9-a2f4-4001b59b34ee"",
            ""actions"": [
                {
                    ""name"": ""ArmL"",
                    ""type"": ""Value"",
                    ""id"": ""e541ca63-f002-42f8-9bc8-9bd60b9c713e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ArmR"",
                    ""type"": ""Value"",
                    ""id"": ""9cc7c947-e7b1-4a46-bfe2-6db0c6ba5f27"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""HoldL"",
                    ""type"": ""Button"",
                    ""id"": ""dda30978-b815-405d-9c19-b44249e7e72c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HoldR"",
                    ""type"": ""Button"",
                    ""id"": ""f54af416-f8b9-49dd-903a-58bf06c037e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FlexR"",
                    ""type"": ""Button"",
                    ""id"": ""2f08c6b0-4edc-423a-8125-657c37dfc483"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FlexL"",
                    ""type"": ""Button"",
                    ""id"": ""c0227124-0829-4278-b299-a40880bd3287"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.1)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c9a6cbc0-4be8-4c02-973d-1809acb9c560"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone,InvertVector2"",
                    ""groups"": """",
                    ""action"": ""ArmL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58385c95-2466-4763-8b8f-3ee90ea542d8"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone,InvertVector2"",
                    ""groups"": """",
                    ""action"": ""ArmR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e790588-7dc6-43f6-bd1c-34f8858167f6"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HoldL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78fcedc3-4d5e-4683-ae4b-b3860334440c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HoldR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0182a9ff-06e5-493b-9d52-e0000af737d6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlexR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c753aefc-a43f-4f2e-b7c3-cd42d225a6e6"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlexL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_ArmL = m_Player.FindAction("ArmL", throwIfNotFound: true);
        m_Player_ArmR = m_Player.FindAction("ArmR", throwIfNotFound: true);
        m_Player_HoldL = m_Player.FindAction("HoldL", throwIfNotFound: true);
        m_Player_HoldR = m_Player.FindAction("HoldR", throwIfNotFound: true);
        m_Player_FlexR = m_Player.FindAction("FlexR", throwIfNotFound: true);
        m_Player_FlexL = m_Player.FindAction("FlexL", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_ArmL;
    private readonly InputAction m_Player_ArmR;
    private readonly InputAction m_Player_HoldL;
    private readonly InputAction m_Player_HoldR;
    private readonly InputAction m_Player_FlexR;
    private readonly InputAction m_Player_FlexL;
    public struct PlayerActions
    {
        private @CustomControls m_Wrapper;
        public PlayerActions(@CustomControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ArmL => m_Wrapper.m_Player_ArmL;
        public InputAction @ArmR => m_Wrapper.m_Player_ArmR;
        public InputAction @HoldL => m_Wrapper.m_Player_HoldL;
        public InputAction @HoldR => m_Wrapper.m_Player_HoldR;
        public InputAction @FlexR => m_Wrapper.m_Player_FlexR;
        public InputAction @FlexL => m_Wrapper.m_Player_FlexL;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @ArmL.started += instance.OnArmL;
            @ArmL.performed += instance.OnArmL;
            @ArmL.canceled += instance.OnArmL;
            @ArmR.started += instance.OnArmR;
            @ArmR.performed += instance.OnArmR;
            @ArmR.canceled += instance.OnArmR;
            @HoldL.started += instance.OnHoldL;
            @HoldL.performed += instance.OnHoldL;
            @HoldL.canceled += instance.OnHoldL;
            @HoldR.started += instance.OnHoldR;
            @HoldR.performed += instance.OnHoldR;
            @HoldR.canceled += instance.OnHoldR;
            @FlexR.started += instance.OnFlexR;
            @FlexR.performed += instance.OnFlexR;
            @FlexR.canceled += instance.OnFlexR;
            @FlexL.started += instance.OnFlexL;
            @FlexL.performed += instance.OnFlexL;
            @FlexL.canceled += instance.OnFlexL;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @ArmL.started -= instance.OnArmL;
            @ArmL.performed -= instance.OnArmL;
            @ArmL.canceled -= instance.OnArmL;
            @ArmR.started -= instance.OnArmR;
            @ArmR.performed -= instance.OnArmR;
            @ArmR.canceled -= instance.OnArmR;
            @HoldL.started -= instance.OnHoldL;
            @HoldL.performed -= instance.OnHoldL;
            @HoldL.canceled -= instance.OnHoldL;
            @HoldR.started -= instance.OnHoldR;
            @HoldR.performed -= instance.OnHoldR;
            @HoldR.canceled -= instance.OnHoldR;
            @FlexR.started -= instance.OnFlexR;
            @FlexR.performed -= instance.OnFlexR;
            @FlexR.canceled -= instance.OnFlexR;
            @FlexL.started -= instance.OnFlexL;
            @FlexL.performed -= instance.OnFlexL;
            @FlexL.canceled -= instance.OnFlexL;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnArmL(InputAction.CallbackContext context);
        void OnArmR(InputAction.CallbackContext context);
        void OnHoldL(InputAction.CallbackContext context);
        void OnHoldR(InputAction.CallbackContext context);
        void OnFlexR(InputAction.CallbackContext context);
        void OnFlexL(InputAction.CallbackContext context);
    }
}
