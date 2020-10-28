// GENERATED AUTOMATICALLY FROM 'Assets/Button.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Button : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Button()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Button"",
    ""maps"": [
        {
            ""name"": ""MoveButton"",
            ""id"": ""31914fb9-801b-46ef-9704-2a183320a764"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""97bd52ef-0b2c-4770-80b6-bf2d1cfefc87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""35f9e79a-e00e-4b93-ba3f-5e4d2f171366"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd6b7bac-8e0f-4d2f-83ea-b55c02ed2042"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""209eeaf3-a6d7-486a-ba3e-e777e914efa5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MoveButton
        m_MoveButton = asset.FindActionMap("MoveButton", throwIfNotFound: true);
        m_MoveButton_Newaction = m_MoveButton.FindAction("New action", throwIfNotFound: true);
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

    // MoveButton
    private readonly InputActionMap m_MoveButton;
    private IMoveButtonActions m_MoveButtonActionsCallbackInterface;
    private readonly InputAction m_MoveButton_Newaction;
    public struct MoveButtonActions
    {
        private @Button m_Wrapper;
        public MoveButtonActions(@Button wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_MoveButton_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_MoveButton; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveButtonActions set) { return set.Get(); }
        public void SetCallbacks(IMoveButtonActions instance)
        {
            if (m_Wrapper.m_MoveButtonActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MoveButtonActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MoveButtonActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MoveButtonActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MoveButtonActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MoveButtonActions @MoveButton => new MoveButtonActions(this);
    public interface IMoveButtonActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
