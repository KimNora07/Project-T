namespace ProjectT.BackGround
{
    //System
    using System.Collections;
    using System.Collections.Generic;

    //UnityEngine
    using UnityEngine;

    public class ParallaxBackGround : MonoBehaviour
    {
        [SerializeField]
        [Range(-1.0f, 1.0f)]
        private float moveSpeed = 0.1f;
        private Material material;

        private void Awake()
        {
            material = GetComponent<Renderer>().material;
        }

        private void Update()
        {
            material.SetTextureOffset("_MainTex", Vector2.right * moveSpeed * Time.time);
        }
    }
}

