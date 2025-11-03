using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GJ {

    public class InputEntity {
        public InputSystem_Action input_Role;
        public InputMouseStatus MouseStatus { get; private set; }
        public Vector3 MouseScreenPosition { get; private set; }
        public bool IsDragging { get; private set; }

        public InputEntity() {
            input_Role = new InputSystem_Action();
            input_Role.Enable();
        }

        public void Dispose() {
            input_Role.Disable();
        }

        public void Process(float dt) {

            // -Mouse
            {
                var mouse = Pointer.current;
                if (mouse != null) {
                    MouseStatus = InputMouseStatus.None;
                    MouseScreenPosition = mouse.position.ReadValue();
                    if (mouse.press.wasPressedThisFrame) {
                        MouseStatus = InputMouseStatus.DownFirst;
                        IsDragging = true;
                    } else if (mouse.press.wasReleasedThisFrame) {
                        if (IsDragging) {
                            MouseStatus = InputMouseStatus.Up;
                        }
                        IsDragging = false;
                    } else if (mouse.press.isPressed) {
                        MouseStatus = InputMouseStatus.DownMaintain;
                    }
                }
            }
        }

    }
}