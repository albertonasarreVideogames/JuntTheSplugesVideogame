using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSwitchUpAnimation()
    {
        spriteRenderer.material.SetInt("_EnableColor", 1);
    }

    public void OnSwitchDownAnimation()
    {
        spriteRenderer.material.SetInt("_EnableColor", 0);
        SoundManager.PlaySoundONCE(SoundType.SWITCHDOWN);
    }
}
