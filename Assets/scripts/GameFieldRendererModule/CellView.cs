using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameFieldRendererModule
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class CellView : MonoBehaviour
    { 
        [SerializeField] private SpriteRenderer background;
        [SerializeField] private SpriteRenderer symbolSpriteRenderer;
        [SerializeField] private BoxCollider2D collider2d;
        private CellCoordinate _cellCoordinate;
        private float _spriteSize;
        public event Action MouseEnter;
        public event Action MouseExit;
        public event Action<CellCoordinate> Clicked;

        public void Init(int row, int col, float size, float colliderSize)
        {
            _spriteSize = size;
            symbolSpriteRenderer.sprite = null;
            background.size = new Vector2(_spriteSize, _spriteSize);
            collider2d.size = new Vector2(colliderSize, colliderSize);
            _cellCoordinate = new CellCoordinate(row, col);
        }

        private void OnMouseEnter()
        {
            MouseEnter?.Invoke();
        }

        private void OnMouseExit()
        {
            MouseExit?.Invoke();
        }

        private void OnMouseDown()
        {
            Clicked?.Invoke(_cellCoordinate);
        }

        public void SetSprite(Sprite newSprite)
        {
            symbolSpriteRenderer.sprite = newSprite;
            symbolSpriteRenderer.size = new Vector2(_spriteSize, _spriteSize);
        }
    }
}