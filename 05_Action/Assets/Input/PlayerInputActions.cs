//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Input/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Test"",
            ""id"": ""f16a1490-48a3-4ba0-9ea6-da49c917ef8d"",
            ""actions"": [
                {
                    ""name"": ""Test1"",
                    ""type"": ""Button"",
                    ""id"": ""0d711bce-9346-4ded-a515-cab37f35e8cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Test2"",
                    ""type"": ""Button"",
                    ""id"": ""744a0c1f-72f1-4e24-9857-afb1d9c8f040"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Test3"",
                    ""type"": ""Button"",
                    ""id"": ""f99c7503-ae77-48ff-8249-c757155c7670"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Test4"",
                    ""type"": ""Button"",
                    ""id"": ""73d43d64-e4de-44fb-b983-45f8a1f3792e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Test5"",
                    ""type"": ""Button"",
                    ""id"": ""3b5fb38b-44dd-4f22-96b5-3f18e91cae61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e2de0df2-0d3d-4521-9b75-6752d695aca0"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KM"",
                    ""action"": ""Test1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f78533c-81ca-4137-92d1-f3da2b6810ae"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KM"",
                    ""action"": ""Test2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21af050e-a531-418d-8696-77de5d32e1dc"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KM"",
                    ""action"": ""Test3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31226d41-2d0a-4f63-9b58-ad1b41aad685"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KM"",
                    ""action"": ""Test4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d3df37a-dd79-4040-826c-dda2fc14e89b"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KM"",
                    ""action"": ""Test5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""07df702b-6118-4dd2-9d83-cf2078af7d85"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a80848b4-a02a-4654-9141-c21cab864cbc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveModeChange"",
                    ""type"": ""Button"",
                    ""id"": ""89cd2716-8afd-4dce-8ac0-f410a2fb622e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""87c2520b-5229-47f7-945e-cfae299ad02e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dae7f5ce-0c3f-4768-ab5c-74cf0d02ee89"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c62633d5-8b9a-414a-b886-82ace952e2c5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0648e6c6-33d6-4efa-a91f-6598fa4cdf5b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""66599821-0271-4b4f-9fd2-78953a53c131"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""14334f78-0259-4551-ae6d-b02f7cffc084"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveModeChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Effect"",
            ""id"": ""972804c4-935b-4c1b-aba8-7a35f80ec681"",
            ""actions"": [
                {
                    ""name"": ""CursorMove"",
                    ""type"": ""Value"",
                    ""id"": ""e5fa45ae-aa05-4af3-8779-f25a0fe1c952"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""98a22778-6eb5-4038-862e-118340aa6104"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CursorMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KM"",
            ""bindingGroup"": ""KM"",
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
        }
    ]
}");
        // Test
        m_Test = asset.FindActionMap("Test", throwIfNotFound: true);
        m_Test_Test1 = m_Test.FindAction("Test1", throwIfNotFound: true);
        m_Test_Test2 = m_Test.FindAction("Test2", throwIfNotFound: true);
        m_Test_Test3 = m_Test.FindAction("Test3", throwIfNotFound: true);
        m_Test_Test4 = m_Test.FindAction("Test4", throwIfNotFound: true);
        m_Test_Test5 = m_Test.FindAction("Test5", throwIfNotFound: true);
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_MoveModeChange = m_Player.FindAction("MoveModeChange", throwIfNotFound: true);
        // Effect
        m_Effect = asset.FindActionMap("Effect", throwIfNotFound: true);
        m_Effect_CursorMove = m_Effect.FindAction("CursorMove", throwIfNotFound: true);
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

    // Test
    private readonly InputActionMap m_Test;
    private ITestActions m_TestActionsCallbackInterface;
    private readonly InputAction m_Test_Test1;
    private readonly InputAction m_Test_Test2;
    private readonly InputAction m_Test_Test3;
    private readonly InputAction m_Test_Test4;
    private readonly InputAction m_Test_Test5;
    public struct TestActions
    {
        private @PlayerInputActions m_Wrapper;
        public TestActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Test1 => m_Wrapper.m_Test_Test1;
        public InputAction @Test2 => m_Wrapper.m_Test_Test2;
        public InputAction @Test3 => m_Wrapper.m_Test_Test3;
        public InputAction @Test4 => m_Wrapper.m_Test_Test4;
        public InputAction @Test5 => m_Wrapper.m_Test_Test5;
        public InputActionMap Get() { return m_Wrapper.m_Test; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestActions set) { return set.Get(); }
        public void SetCallbacks(ITestActions instance)
        {
            if (m_Wrapper.m_TestActionsCallbackInterface != null)
            {
                @Test1.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest1;
                @Test1.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest1;
                @Test1.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest1;
                @Test2.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest2;
                @Test2.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest2;
                @Test2.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest2;
                @Test3.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest3;
                @Test3.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest3;
                @Test3.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest3;
                @Test4.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest4;
                @Test4.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest4;
                @Test4.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest4;
                @Test5.started -= m_Wrapper.m_TestActionsCallbackInterface.OnTest5;
                @Test5.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnTest5;
                @Test5.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnTest5;
            }
            m_Wrapper.m_TestActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Test1.started += instance.OnTest1;
                @Test1.performed += instance.OnTest1;
                @Test1.canceled += instance.OnTest1;
                @Test2.started += instance.OnTest2;
                @Test2.performed += instance.OnTest2;
                @Test2.canceled += instance.OnTest2;
                @Test3.started += instance.OnTest3;
                @Test3.performed += instance.OnTest3;
                @Test3.canceled += instance.OnTest3;
                @Test4.started += instance.OnTest4;
                @Test4.performed += instance.OnTest4;
                @Test4.canceled += instance.OnTest4;
                @Test5.started += instance.OnTest5;
                @Test5.performed += instance.OnTest5;
                @Test5.canceled += instance.OnTest5;
            }
        }
    }
    public TestActions @Test => new TestActions(this);

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_MoveModeChange;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @MoveModeChange => m_Wrapper.m_Player_MoveModeChange;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @MoveModeChange.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveModeChange;
                @MoveModeChange.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveModeChange;
                @MoveModeChange.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveModeChange;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MoveModeChange.started += instance.OnMoveModeChange;
                @MoveModeChange.performed += instance.OnMoveModeChange;
                @MoveModeChange.canceled += instance.OnMoveModeChange;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Effect
    private readonly InputActionMap m_Effect;
    private IEffectActions m_EffectActionsCallbackInterface;
    private readonly InputAction m_Effect_CursorMove;
    public struct EffectActions
    {
        private @PlayerInputActions m_Wrapper;
        public EffectActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @CursorMove => m_Wrapper.m_Effect_CursorMove;
        public InputActionMap Get() { return m_Wrapper.m_Effect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EffectActions set) { return set.Get(); }
        public void SetCallbacks(IEffectActions instance)
        {
            if (m_Wrapper.m_EffectActionsCallbackInterface != null)
            {
                @CursorMove.started -= m_Wrapper.m_EffectActionsCallbackInterface.OnCursorMove;
                @CursorMove.performed -= m_Wrapper.m_EffectActionsCallbackInterface.OnCursorMove;
                @CursorMove.canceled -= m_Wrapper.m_EffectActionsCallbackInterface.OnCursorMove;
            }
            m_Wrapper.m_EffectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CursorMove.started += instance.OnCursorMove;
                @CursorMove.performed += instance.OnCursorMove;
                @CursorMove.canceled += instance.OnCursorMove;
            }
        }
    }
    public EffectActions @Effect => new EffectActions(this);
    private int m_KMSchemeIndex = -1;
    public InputControlScheme KMScheme
    {
        get
        {
            if (m_KMSchemeIndex == -1) m_KMSchemeIndex = asset.FindControlSchemeIndex("KM");
            return asset.controlSchemes[m_KMSchemeIndex];
        }
    }
    public interface ITestActions
    {
        void OnTest1(InputAction.CallbackContext context);
        void OnTest2(InputAction.CallbackContext context);
        void OnTest3(InputAction.CallbackContext context);
        void OnTest4(InputAction.CallbackContext context);
        void OnTest5(InputAction.CallbackContext context);
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMoveModeChange(InputAction.CallbackContext context);
    }
    public interface IEffectActions
    {
        void OnCursorMove(InputAction.CallbackContext context);
    }
}
