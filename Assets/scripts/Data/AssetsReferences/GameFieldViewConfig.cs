using System;
using GameFieldRendererModule;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data.AssetsReferences
{
    [Serializable]
    public class GameFieldViewConfig
    {

        [SerializeField] private float size;
        [SerializeField] private float cellSizeOffset;
        [Range(3, 5)] [SerializeField] private int cellsCount;
        [SerializeField] private float borderThickness;
        [SerializeField] private SpriteRenderer borderSprite;

        [SerializeField] private Sprite crossSprite;
        [SerializeField] private Sprite zeroSprite;
        
        [SerializeField] private CellView cellViewPrefab;

        [SerializeField] private bool renderOutlines;
        [SerializeField] private bool renderInnerLines;


        public float Size => size;

        public float CellSizeOffset => cellSizeOffset;

        public int CellsCount => cellsCount;

        public float BorderThickness => borderThickness;

        public SpriteRenderer BorderSprite => borderSprite;

        public Sprite CrossSprite => crossSprite;

        public Sprite ZeroSprite => zeroSprite;
        public CellView CellViewPrefab => cellViewPrefab;
    }
}