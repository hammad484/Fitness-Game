﻿using UnityEngine;

namespace Area730.TextureBlock
{

    public class TextureScroller : MonoBehaviour
    {
        public bool     stopped         = false;
        public float    offsetSpeed     = 0.5f;
        public bool     reverse         = false;

        private float   timePassed      = 0;
        private Mesh    mesh;

        private bool right;
        
        void Awake()
        {
            mesh = GetComponent<MeshFilter>().mesh;
            if (mesh == null)
            {
                Debug.LogError("TextureScroller: Mesh is null");
            }
        }

        void Update()
        {
            if (stopped || mesh == null)
            {
                return;
            }

            float offset = Time.time * offsetSpeed % 1;
            if (reverse)
            {
                offset = -offset;
            }

          //  if (right)
                GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
            //else GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(-offset, 0));
        }

    }

}
