using System;
using UnityEngine;

namespace GameFieldModule
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Cell : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private BoxCollider2D collider2d;

        public event Action MouseEnter;
        public event Action MouseExit;
        public event Action<Cell> Clicked;

        public void SetSize(float size, float colliderSize)
        {
            sprite.size = new Vector2(size, size);
            collider2d.size = new Vector2(colliderSize, colliderSize);
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
            Clicked?.Invoke(this);
        }
    }
}