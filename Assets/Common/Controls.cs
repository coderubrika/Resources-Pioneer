// GENERATED AUTOMATICALLY FROM 'Assets/Common/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""UI"",
            ""id"": ""b9e6fc1b-54ac-48e4-abb1-2460334b62ab"",
            ""actions"": [
                {
                    ""name"": ""TapPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1e26f756-abfd-4090-9fb9-300795471ea0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TapPressed"",
                    ""type"": ""PassThrough"",
                    ""id"": ""97a3e9d4-222a-454b-8035-f49dee562e13"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TapReleased"",
                    ""type"": ""PassThrough"",
                    ""id"": ""108d3193-7215-4e79-aeb0-afb0d28c4ba5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TapDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d0906a61-8af8-45f6-bcec-d1047c548dbf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cab6d351-375e-489e-8b01-7ab7c12295e8"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""TapPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f314cb97-07a9-4e98-b56a-47197a2b536b"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""TapPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4e40997-9c6a-40d1-ae29-dd78b7769ca0"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""TapReleased"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ef4ad9c-8df3-4cb0-a59e-6059c9757b10"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""TapDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Touchscreen"",
            ""bindingGroup"": ""Touchscreen"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_TapPosition = m_UI.FindAction("TapPosition", throwIfNotFound: true);
        m_UI_TapPressed = m_UI.FindAction("TapPressed", throwIfNotFound: true);
        m_UI_TapReleased = m_UI.FindAction("TapReleased", throwIfNotFound: true);
        m_UI_TapDelta = m_UI.FindAction("TapDelta", throwIfNotFound: true);
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

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_TapPosition;
    private readonly InputAction m_UI_TapPressed;
    private readonly InputAction m_UI_TapReleased;
    private readonly InputAction m_UI_TapDelta;
    public struct UIActions
    {
        private @Controls m_Wrapper;
        public UIActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TapPosition => m_Wrapper.m_UI_TapPosition;
        public InputAction @TapPressed => m_Wrapper.m_UI_TapPressed;
        public InputAction @TapReleased => m_Wrapper.m_UI_TapReleased;
        public InputAction @TapDelta => m_Wrapper.m_UI_TapDelta;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @TapPosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTapPosition;
                @TapPosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTapPosition;
                @TapPosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTapPosition;
                @TapPressed.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTapPressed;
                @TapPressed.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTapPressed;
                @TapPressed.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTapPressed;
                @TapReleased.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTapReleased;
                @TapReleased.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTapReleased;
                @TapReleased.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTapReleased;
                @TapDelta.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTapDelta;
                @TapDelta.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTapDelta;
                @TapDelta.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTapDelta;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TapPosition.started += instance.OnTapPosition;
                @TapPosition.performed += instance.OnTapPosition;
                @TapPosition.canceled += instance.OnTapPosition;
                @TapPressed.started += instance.OnTapPressed;
                @TapPressed.performed += instance.OnTapPressed;
                @TapPressed.canceled += instance.OnTapPressed;
                @TapReleased.started += instance.OnTapReleased;
                @TapReleased.performed += instance.OnTapReleased;
                @TapReleased.canceled += instance.OnTapReleased;
                @TapDelta.started += instance.OnTapDelta;
                @TapDelta.performed += instance.OnTapDelta;
                @TapDelta.canceled += instance.OnTapDelta;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_TouchscreenSchemeIndex = -1;
    public InputControlScheme TouchscreenScheme
    {
        get
        {
            if (m_TouchscreenSchemeIndex == -1) m_TouchscreenSchemeIndex = asset.FindControlSchemeIndex("Touchscreen");
            return asset.controlSchemes[m_TouchscreenSchemeIndex];
        }
    }
    public interface IUIActions
    {
        void OnTapPosition(InputAction.CallbackContext context);
        void OnTapPressed(InputAction.CallbackContext context);
        void OnTapReleased(InputAction.CallbackContext context);
        void OnTapDelta(InputAction.CallbackContext context);
    }
}
