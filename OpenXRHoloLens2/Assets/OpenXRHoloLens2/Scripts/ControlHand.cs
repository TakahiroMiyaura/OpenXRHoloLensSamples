// Copyright (c) 2022 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ReSeul.OpenXRHoloLens2
{
    public class ControlHand : MonoBehaviour
    {
        private bool isToggle;
        public GameObject ObjectPrefab;

        private bool requestCreate;

        // Update is called once per frame
        private void Update()
        {
            if (requestCreate)
            {
                requestCreate = false;
                Instantiate(ObjectPrefab, Camera.main.transform.position + Camera.main.transform.forward * 2f,
                    Quaternion.identity);
            }
        }

        public void OnTap(InputAction.CallbackContext obj)
        {
            var handedness = "Right";
            if (obj.action.name.Equals("SelectLeft")) handedness = "Left";

            var selectedObj = BaseCursor.Instance.FirstOrDefault(x => x.Handedness.Equals(handedness));

            if (selectedObj == null)
            {
                requestCreate = true;
                return;
            }

            var meshRenderer = selectedObj.SelectedObject?.GetComponent<MeshRenderer>();
            if (meshRenderer == null)
            {
                requestCreate = true;
                return;
            }

            meshRenderer.material.color = isToggle ? Color.blue : Color.red;

            isToggle = !isToggle;
        }
    }
}