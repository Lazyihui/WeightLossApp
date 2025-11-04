using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

namespace GJ {

    public class Panel_keyboardEle : MonoBehaviour {
        public UniqueID uniqueID;

        [SerializeField] Button btn_number;
        [SerializeField] public TextMeshProUGUI txt_title;
        public KeyboardType keyboardType;
        public Action OnnumberHandle;

        public void Ctor() {
            btn_number.onClick.AddListener(() => {
                OnnumberHandle?.Invoke();
            });
            Init();
        }

        public void Init() {
            SetData();
        }

        public void TearDown() {
            btn_number.onClick.RemoveAllListeners();
            Destroy(this.gameObject);
        }

        public void Close() {
            btn_number.onClick.RemoveAllListeners();
        }

        public void SetData() {
            // 使用更简洁的映射方式
            switch (txt_title.text) {
                case "1": keyboardType = KeyboardType.number_1; break;
                case "2": keyboardType = KeyboardType.number_2; break;
                case "3": keyboardType = KeyboardType.number_3; break;
                case "4": keyboardType = KeyboardType.number_4; break;
                case "5": keyboardType = KeyboardType.number_5; break;
                case "6": keyboardType = KeyboardType.number_6; break;
                case "7": keyboardType = KeyboardType.number_7; break;
                case "8": keyboardType = KeyboardType.number_8; break;
                case "9": keyboardType = KeyboardType.number_9; break;
                case "0": keyboardType = KeyboardType.number_0; break;
                case "删除": keyboardType = KeyboardType.delete; break;
                case "清空": keyboardType = KeyboardType.clear; break;
                case "确认": keyboardType = KeyboardType.enter; break;
                case ".": keyboardType = KeyboardType.point; break;
            }
        }
    }
}