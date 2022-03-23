// Copyright (c) 2022 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System.Collections.Generic;
using UnityEngine;

namespace ReSeul.OpenXRSample
{
    public class BaseCursor : MonoBehaviour
    {
        private static readonly List<BaseCursor> CursorList = new List<BaseCursor>();

        public string Handedness;

        public GameObject SelectedObject;

        public static BaseCursor[] Instance => CursorList.ToArray();

        private void Start()
        {
            CursorList.Add(this);
        }

        public void SetObject(GameObject colliderGameObject)
        {
            SelectedObject = colliderGameObject;
        }
    }
}