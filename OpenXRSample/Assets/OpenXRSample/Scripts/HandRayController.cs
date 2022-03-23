// Copyright (c) 2022 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using UnityEngine;

namespace ReSeul.OpenXRSample
{
    public class HandRayController : MonoBehaviour
    {
        private BaseCursor cursor;

        private LineRenderer lineRenderer;

        // Start is called before the first frame update
        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            cursor = GetComponentInChildren<BaseCursor>();
        }

        private void Update()
        {
            if (Physics.Raycast(transform.position, transform.forward.normalized, out var hit, 15f))
            {
                lineRenderer.SetPosition(1, Quaternion.Inverse(transform.rotation) * (hit.point - transform.position));
                cursor.transform.position = hit.point;
                cursor.SetObject(hit.collider.gameObject);
            }
            else
            {
                lineRenderer.SetPosition(1, Quaternion.Inverse(transform.rotation) * transform.forward * 5f);
                cursor.transform.position = Vector3.zero;
                cursor.SetObject(null);
            }
        }
    }
}