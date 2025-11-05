using System;
using System.Collections;
using UnityEngine;
using TMPro;

namespace GJ {

    public class Panel_ListEle : MonoBehaviour {

        [SerializeField] TextMeshProUGUI txt_date;
        [SerializeField] TextMeshProUGUI txt_weight;
        [SerializeField] TextMeshProUGUI txt_difference;

        public void Ctor() {

        }

        public void SetData(string date, string weight, string difference) {
            txt_date.text = date;
            txt_weight.text = weight;
            txt_difference.text = difference;
        }

        public void Init() {
        }

        public void TearDown() {
            Destroy(this.gameObject);
        }
    }

}