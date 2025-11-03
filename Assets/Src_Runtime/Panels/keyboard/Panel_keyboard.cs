using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

namespace GJ {

    public class Panel_Keyboard : MonoBehaviour, IPanelAsset {

        PanelType IPanelAsset.Type => PanelType.Keyboard;

        [SerializeField] Button btn_Add;

        [SerializeField] TextMeshProUGUI txt_title;

        public Action OnStartHandle;
        public Action OnExitGameHandle;

        public void Ctor() {
            btn_Add.onClick.AddListener(() => {
                OnStartHandle?.Invoke();
            });

        }

        public void Init() {
        }

        public void TearDown() {
            Destroy(this.gameObject);
        }
        public void Close() {
            btn_Add.onClick.RemoveAllListeners();
        }

    }

}