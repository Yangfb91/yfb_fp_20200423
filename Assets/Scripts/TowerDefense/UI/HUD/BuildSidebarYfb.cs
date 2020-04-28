using TowerDefense.Level;
using TowerDefense.Towers;
using UnityEngine;

namespace TowerDefense.UI.HUD
{
	/// <summary>
	/// UI component that displays towers that can be built on this level.
	/// </summary>
	public class BuildSidebarYfb : MonoBehaviour
	{
		/// <summary>
		/// The prefab spawned for each button
		/// </summary>
		public TowerSpawnButton towerSpawnButton;

		/// <summary>
		/// Initialize the tower spawn buttons
		/// </summary>
		protected virtual void Start()
		{
			if (!LevelManagerYfb.instanceExists)
			{
				Debug.LogError("[UI] No level manager for tower list");
			}
			foreach (Tower tower in LevelManagerYfb.instance.towerLibrary)
			{
				TowerSpawnButton button = Instantiate(towerSpawnButton, transform);
				button.InitializeButton(tower);
				button.buttonTapped += OnButtonTapped;
				button.draggedOff += OnButtonDraggedOff;
			}
		}

		/// <summary>
		/// Sets the GameUI to build mode with the <see cref="towerData"/>
		/// </summary>
		/// <param name="towerData"></param>
		void OnButtonTapped(Tower towerData)
		{
			var gameUI = GameUI.instance;
			if (gameUI.isBuilding)
			{
				gameUI.CancelGhostPlacement();
			}
			gameUI.SetToBuildMode(towerData);
		}

		/// <summary>
		/// Sets the GameUI to build mode with the <see cref="towerData"/> 
		/// </summary>
		/// <param name="towerData"></param>
		void OnButtonDraggedOff(Tower towerData)
		{
			if (!GameUI.instance.isBuilding)
			{
				GameUI.instance.SetToDragMode(towerData);
			}
		}

		/// <summary>
		/// Unsubscribes from all the tower spawn buttons
		/// </summary>
		void OnDestroy()
		{
			TowerSpawnButton[] childButtons = GetComponentsInChildren<TowerSpawnButton>();

			foreach (TowerSpawnButton towerButton in childButtons)
			{
				towerButton.buttonTapped -= OnButtonTapped;
				towerButton.draggedOff -= OnButtonDraggedOff;
			}
		}

	}
}