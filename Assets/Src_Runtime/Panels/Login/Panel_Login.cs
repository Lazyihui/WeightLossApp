using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

namespace GJ {

    public class Panel_Login : MonoBehaviour, IPanelAsset {

        PanelType IPanelAsset.Type => PanelType.Login;

        [SerializeField] Button btn_Add;
        [SerializeField] Button btn_exitGame;

        [SerializeField] TextMeshProUGUI txt_title;

        public Action OnAddHandle;
        public Action OnExitGameHandle;

        public void Ctor() {
            btn_Add.onClick.AddListener(() => {
                OnAddHandle?.Invoke();
            });

            btn_exitGame.onClick.AddListener(() => {
                OnExitGameHandle?.Invoke();
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