using System;
using UnityEngine;
using JetBrains.Annotations;
using Core.Utilities;
using TowerDefense.Towers;

namespace TowerDefense.UI.HUD
{
	public class GameUIYfb : Singleton<GameUIYfb>
	{
		/// <summary>
		/// The states the UI can be in
		/// </summary>
		public enum State
		{
			/// <summary>
			/// The game is in its normal state. Here the player can pan the camera, select units and towers
			/// </summary>
			Normal,

			/// <summary>
			/// The game is in 'build mode'. Here the player can pan the camera, confirm or deny placement
			/// </summary>
			Building,

			/// <summary>
			/// The game is Paused. Here, the player can restart the level, or quit to the main menu
			/// </summary>
			Paused,

			/// <summary>
			/// The game is over and the level was failed/completed
			/// </summary>
			GameOver,
			
			/// <summary>
			/// The game is in 'build mode' and the player is dragging the ghost tower
			/// </summary>
			BuildingWithDrag
		}

		/// <summary>
		/// Gets the current UI state
		/// </summary>
		public State state { get; private set; }

		/// <summary>
		/// Fires when the <see cref="State"/> changes
		/// should only allow firing when TouchUI is used
		/// </summary>
		public event Action<State, State> stateChanged;

		/// <summary>
		/// Current tower placeholder. Will be null if not in the <see cref="State.Building" /> state.
		/// </summary>
		TowerPlacementGhost m_CurrentTower;

		/// <summary>
		/// Gets whether certain build operations are valid
		/// </summary>
		public bool isBuilding
		{
			get
			{
				return state == State.Building || state == State.BuildingWithDrag;
			}
		}

		/// <summary>
		/// Changes the state and fires <see cref="stateChanged"/>
		/// </summary>
		/// <param name="newState">The state to change to</param>
		/// <exception cref="ArgumentOutOfRangeException">
		/// thrown on an invalidstate
		/// </exception>
		void SetState(State newState)
		{
			if (state == newState)
			{
				return;
			}
			State oldState = state;

			switch (newState)
			{
				case State.Normal:
				case State.Building:
				case State.BuildingWithDrag:
					break;
				default:
					throw new ArgumentOutOfRangeException(
						"newState", newState, null);
			}
			state = newState;
			if (stateChanged != null)
			{
				stateChanged(oldState, state);
			}
		}


		/// <summary>
		/// Sets the UI into a build state for a given tower
		/// </summary>
		/// <param name="towerToBuild">
		/// The tower to build
		/// </param>
		/// <exception cref="InvalidOperationException">
		/// Throws exception trying to enter Build Mode when not in Normal Mode
		/// </exception>
		public void SetToBuildMode([NotNull] Tower towerToBuild)
		{
			if (state != State.Normal)
			{
				throw new InvalidOperationException("Trying to enter Build mode when not in Normal mode");
			}
			
			//if (m_CurrentTower != null)
			//{
			//	// Destroy current ghost
			//	CancelGhostPlacement();
			//}
			SetUpGhostTower(towerToBuild);
			SetState(State.Building);
		}

		/// <summary>
		/// Set initial values, cache attached components
		/// and configure the controls
		/// </summary>
		protected override void Awake()
		{
			base.Awake();

			state = State.Normal;
		}

		/// <summary>
		/// Reset TimeScale if game is paused
		/// </summary>
		protected override void OnDestroy()
		{
			base.OnDestroy();
			Time.timeScale = 1f;
		}

		void SetUpGhostTower([NotNull] Tower towerToBuild)
		{
			if (towerToBuild == null)
			{
				throw new ArgumentNullException("towerToBuild");
			}

			m_CurrentTower = Instantiate(towerToBuild.towerGhostPrefab);
			m_CurrentTower.Initialize(towerToBuild);
			//m_CurrentTower.Hide();

		}
	}
}