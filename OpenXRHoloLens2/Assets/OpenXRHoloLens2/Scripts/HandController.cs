// Copyright (c) 2022 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using UnityEngine;

namespace ReSeul.OpenXRHoloLens2
{
    public class HandController : MonoBehaviour
    {
        public BaseCursor Cursor;

        private void OnTriggerEnter(Collider other)
        {
            Cursor.SetObject(other.gameObject);
        }

        private void OnTriggerStay(Collider other)
        {
            Cursor.SetObject(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            Cursor.SetObject(null);
        }
    }
}