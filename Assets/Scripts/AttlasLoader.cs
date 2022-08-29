using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class AttlasLoader : MonoBehaviour
{
    [SerializeField] private SpriteAtlas spriteAtlas;
    [SerializeField] private string spriteName;


    private void Start()
    {
        GetComponent<Image>().sprite = spriteAtlas.GetSprite(spriteName);
    }
}
