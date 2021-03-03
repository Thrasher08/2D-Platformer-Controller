using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownPlatformController : MonoBehaviour
{
    public GameObject tiles;

    PlatformEffector2D pe;

    int decativationLayer = 0;
    int baseLayer = 10;

    float yInput;

    // Start is called before the first frame update
    void Start()
    {
        pe = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        yInput = Input.GetAxisRaw("Vertical");
        if (yInput < 0)
        {
            tiles.layer = decativationLayer;    // prevents the player from jumping while falling through the platform
            StartCoroutine(Reset());
            pe.rotationalOffset = 180;          // flips the collision surface
        }

    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.35f);
        pe.rotationalOffset = 0;
        tiles.layer = baseLayer;
    }
}
