using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameFieldModule
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Cell : MonoBehaviour
    { 
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private BoxCollider2D collider2d;
        private CellCoordinate _cellCoordinate;
        private float _spriteSize;
        public event Action MouseEnter;
        public event Action MouseExit;
        public event Action<CellCoordinate> Clicked;

        public void Init(int row, int col, float size, float colliderSize)
        {
            _spriteSize = size;
            spriteRenderer.sprite = null;
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
            spriteRenderer.sprite = newSprite;
            spriteRenderer.size = new Vector2(_spriteSize, _spriteSize);
        }
    }
}