using System;
using System.Collections;
using UnityEngine;
namespace GJ {

    public class Panel_List : MonoBehaviour, IPanelAsset {

        PanelType IPanelAsset.Type => PanelType.List;

        public void Ctor() {

        }


        public void Init() {
        }

        public void TearDown() {
            Destroy(this.gameObject);
        }
    }

}