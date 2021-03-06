﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Study
{

    public class Sample02 : MonoBehaviour
    {
        public ComputeShader compute;

        void Start()
        {
            ComputeBuffer buffer = new ComputeBuffer(4 * 4 * 2 * 2, sizeof(int));

            int kernel = compute.FindKernel("CSMain");

            compute.SetBuffer(kernel, "buffer", buffer);
            compute.Dispatch(kernel, 2, 2, 1);

            int[] data = new int[4 * 4 * 2 * 2];

            buffer.GetData(data);

            for (int i = 0; i < 8; i++)
            {
                string line = "";
                for (int j = 0; j < 8; j++)
                {
                    line += " " + data[j + i * 8];
                }
                Debug.Log(line);
            }

            buffer.Release();
        }
    }
}