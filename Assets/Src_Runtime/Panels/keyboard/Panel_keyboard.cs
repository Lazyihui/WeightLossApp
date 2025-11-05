using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GJ {

    public class Panel_Keyboard : MonoBehaviour, IPanelAsset {

        PanelType IPanelAsset.Type => PanelType.Keyboard;

        [SerializeField] Button btn_Close;
        public Action OnCloseHandle;
        [SerializeField] TextMeshProUGUI text_Number;
        [SerializeField] Transform root;

        // 存储输入的数字
        string currentInput = "";
        List<Panel_keyboardEle> keyboardElements;

        // 输入完成回调
        public Action<string> OnInputComplete;

        public void Ctor() {
            keyboardElements = new List<Panel_keyboardEle>();

            btn_Close.onClick.AddListener(() => {
                OnCloseHandle?.Invoke();
            });
            // 初始化所有键盘元素
            InitializeKeyboardElements();
        }

        void InitializeKeyboardElements() {
            // 获取所有子对象的Panel_keyboardEle组件
            Panel_keyboardEle[] elements = root.GetComponentsInChildren<Panel_keyboardEle>(true);

            foreach (var element in elements) {
                keyboardElements.Add(element);
                element.Ctor();
                element.OnnumberHandle = () => OnKeyPressed(element);
            }
        }

        void OnKeyPressed(Panel_keyboardEle keyElement) {
            switch (keyElement.keyboardType) {
                case KeyboardType.number_0:
                case KeyboardType.number_1:
                case KeyboardType.number_2:
                case KeyboardType.number_3:
                case KeyboardType.number_4:
                case KeyboardType.number_5:
                case KeyboardType.number_6:
                case KeyboardType.number_7:
                case KeyboardType.number_8:
                case KeyboardType.number_9:
                    // 添加数字
                    AddNumber(keyElement.txt_title.text);
                    Debug.Log("currentInput: " + currentInput);
                    break;

                case KeyboardType.point:
                    // 添加小数点（确保只有一个）
                    if (!currentInput.Contains(".")) {
                        AddNumber(".");
                    }
                    break;

                case KeyboardType.delete:
                    // 删除最后一个字符
                    DeleteLastCharacter();
                    break;

                case KeyboardType.clear:
                    // 清空所有输入
                    ClearInput();
                    break;

                case KeyboardType.enter:
                    // 确认输入
                    ConfirmInput();
                    break;
            }

            UpdateDisplay();
        }

        void AddNumber(string number) {
            // 检查是否已经包含小数点
            if (currentInput.Contains(".")) {
                // 获取小数点后的部分
                string[] parts = currentInput.Split('.');
                if (parts.Length == 2) {
                    // 如果小数点后已经有一位数字，就不再添加
                    if (parts[1].Length >= 1) {
                        return;
                    }
                }
            }

            // 如果是第一个字符输入0，后面只能输入小数点
            if (currentInput == "0" && number != ".") {
                return;
            }

            currentInput += number;
        }

        void DeleteLastCharacter() {
            if (currentInput.Length > 0) {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
            }
        }

        void ClearInput() {
            currentInput = "";
        }

        void ConfirmInput() {
            OnInputComplete?.Invoke(currentInput);
            Debug.Log("input: " + currentInput + text_Number.text);
            // 可以选择清空输入或保持显示
            // ClearInput();
            // UpdateDisplay();
        }

        void UpdateDisplay() {
            // 如果为空，可以显示提示文本
            if (string.IsNullOrEmpty(currentInput)) {
                text_Number.text = "input...";
            } else {
                text_Number.text = currentInput;
            }
        }

        // 公共方法供外部调用
        public void SetInput(string input) {
            currentInput = input;
            UpdateDisplay();
        }

        public string GetInput() {
            return currentInput;
        }

        public void Clear() {
            ClearInput();
            UpdateDisplay();
        }

        public void Init() {
            // 初始化时可以清空输入
            ClearInput();
            UpdateDisplay();
        }

        public void TearDown() {
            // 清理所有事件
            foreach (var element in keyboardElements) {
                element.OnnumberHandle = null;
            }
            keyboardElements.Clear();

            btn_Close.onClick.RemoveAllListeners();
            Destroy(this.gameObject);
        }

        public void SetGameObjectActive(bool isActive) {
            this.gameObject.SetActive(isActive);
        }

        public void Close() {
            btn_Close.onClick.RemoveAllListeners();
        }
    }
}