using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

namespace GJ {

    public class Panel_keyboardEle : MonoBehaviour {

        // [SerializeField] Button btn_Add;
        [SerializeField] TextMeshProUGUI txt_title;

        // public Action OnStartHandle;

        public void Ctor() {
            // btn_Add.onClick.AddListener(() => {
            //     OnStartHandle?.Invoke();
            // });

        }

        public void Init() {
        }

        public void TearDown() {
            Destroy(this.gameObject);
        }
        public void Close() {
        }

    }

}