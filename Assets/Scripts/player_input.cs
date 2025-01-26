using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Movement
{
    [RequireComponent(typeof(PlayerInput))]
    public class player_input : player_move
    {
        private void OnMove(InputValue value)
        {
            if (player_health.dead) return;

            Vector3 playerInput = new Vector3(value.Get<Vector2>().x, value.Get<Vector2>().y, 0);
            input = playerInput;
        }
    }
}