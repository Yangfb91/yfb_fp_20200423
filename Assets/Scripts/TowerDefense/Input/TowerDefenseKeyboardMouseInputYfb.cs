using Core.Input;
using TowerDefense.Level;
using TowerDefense.Towers;
using TowerDefense.UI.HUD;
using UnityEngine;
using UnityInput = UnityEngine.Input;
using State = TowerDefense.UI.HUD.GameUIYfb.State;

namespace TowerDefense.Input
{
	[RequireComponent(typeof(GameUIYfb))]
	public class TowerDefenseKeyboardMouseInputYfb : KeyboardMouseInput
	{
		/// <summary>
		/// Cached eference to gameUI
		/// </summary>
		GameUIYfb m_GameUI;

		/// <summary>
		/// Register input events
		/// </summary>
		protected override void OnEnable()
		{
			base.OnEnable();
			
			m_GameUI = GetComponent<GameUIYfb>();

			if (InputController.instanceExists)
			{
				InputController controller = InputController.instance;

				controller.tapped += OnTap;
				controller.mouseMoved += OnMouseMoved;
			}
		}

		/// <summary>
		/// Deregister input events
		/// </summary>
		protected override void OnDisable()
		{
			if (!InputController.instanceExists)
			{
				return;
			}

			InputController controller = InputController.instance;

			controller.tapped -= OnTap;
			controller.mouseMoved -= OnMouseMoved;
		}

		/// <summary>
		/// Handle camera panning behaviour
		/// </summary>
		protected override void Update()
		{
			base.Update();
		}

		/// <summary>
		/// Ghost follows pointer
		/// </summary>
		void OnMouseMoved(PointerInfo pointer)
		{
			if ((pointer != null) && (m_GameUI.isBuilding))
			{
				m_GameUI.TryMoveGhost(pointer, false);
			}
		}

		/// <summary>
		/// Select towers or position ghosts
		/// </summary>
		void OnTap(PointerActionInfo pointer)
		{
			// We only respond to mouse info
			var mouseInfo = pointer as MouseButtonInfo;

			if (mouseInfo != null && !mouseInfo.startedOverUI)
			{
				if (m_GameUI.isBuilding)
				{
					if (mouseInfo.mouseButtonId == 0) // LMB confirms
					{
						m_GameUI.TryPlaceTower(pointer);
					}
					else // RMB cancels
					{
						m_GameUI.CancelGhostPlacement();
					}
				}
				else
				{
					if (mouseInfo.mouseButtonId == 0)
					{
						// select towers
						//m_GameUI.TrySelectTower(pointer);
					}
				}
			}
		}
	}
}