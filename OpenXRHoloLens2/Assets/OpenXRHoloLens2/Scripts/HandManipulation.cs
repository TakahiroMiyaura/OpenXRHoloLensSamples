// Copyright (c) 2022 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using UnityEngine;
using UnityEngine.InputSystem;

namespace ReSeul.OpenXRHoloLens2
{
    public class HandManipulation : MonoBehaviour
    {
        private bool isOperate;

        private bool isFirst;

        private Vector3 position;

        private Quaternion rotation;

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void OnHold(InputAction.CallbackContext obj)
        {
            var temp = obj.ReadValueAsButton();
            if (temp && temp != isOperate)
                isFirst = true;
            else if (!temp && temp != isOperate) isFirst = false;

            isOperate = temp;
        }

        public void OnManipulate(InputAction.CallbackContext obj)
        {
            if (!isOperate) return;

            var data = obj.ReadValueAsObject();

            if (isFirst)
            {
                isFirst = false;
                if (data is Vector3 initPos)
                    position = initPos;
                else if (data is Quaternion initRotate) rotation = initRotate;
            }

            if (data is Vector3 pos)
            {
                transform.position = pos - position;
                position = pos;
            }
            else if (data is Quaternion quaternion)
            {
                transform.rotation = quaternion * Quaternion.Inverse(rotation);
                rotation = quaternion;
            }
        }
    }
}