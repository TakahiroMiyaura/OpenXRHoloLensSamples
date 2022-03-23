// Copyright (c) 2022 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using TMPro;
using UnityEngine;

namespace ReSeul.OpenXRHoloLens2
{
    public class DebugWriter : MonoBehaviour
    {
        public int Lines = 12;
        private TextMeshPro textMeshPro;

        // Start is called before the first frame update
        private void Start()
        {
            textMeshPro = GetComponent<TextMeshPro>();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void SetText(string msg)
        {
            if (textMeshPro.text.Split('\n').Length > Lines)
                textMeshPro.text = textMeshPro.text.Remove(0, textMeshPro.text.IndexOf('\n') + 1);
            textMeshPro.text += msg + "\n";
        }
    }
}