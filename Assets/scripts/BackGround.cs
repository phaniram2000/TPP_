using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private Vector2 uvSpeed = new Vector2(0.0f, -1.0f);
    private Vector2 uvOffset = Vector2.zero;
    void Start()
    {

    }

    void LateUpdate()
    {
        uvOffset += (uvSpeed * Time.deltaTime);
        this.GetComponent<Renderer>().materials[0].SetTextureOffset("_MainTex", -uvOffset);
    }
}
