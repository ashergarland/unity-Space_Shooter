using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {
    public float speed;
    private MeshRenderer mr;
    private Material material;

	// Use this for initialization
	void Start () {
        mr = GetComponent<MeshRenderer>();
        material = mr.material;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = material.mainTextureOffset;
        offset.y += Time.deltaTime / 120f * speed;
        material.mainTextureOffset = offset;
	}
}
