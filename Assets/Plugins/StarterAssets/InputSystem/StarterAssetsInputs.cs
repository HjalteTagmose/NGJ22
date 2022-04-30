using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		[HideInInspector]
		public bool canControl = true;

		public void Stop()
        {
			canControl = false;
			move = Vector2.zero;
			jump = false;
			sprint = false;
		}

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			if (canControl) MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				if (canControl) LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			if (canControl) JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			if (canControl) SprintInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			if (canControl) move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			if (canControl) look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			if (canControl) jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			if (canControl) sprint = newSprintState;
		}
		
		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}