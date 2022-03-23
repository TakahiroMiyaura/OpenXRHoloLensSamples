// Copyright (c) 2022 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using UnityEngine;

namespace ReSeul.OpenXRHoloLens2
{
    public class DeleteObject : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            Destroy(gameObject, 15f);
        }
    }
}