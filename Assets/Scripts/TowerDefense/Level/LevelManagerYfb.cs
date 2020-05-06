using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Utilities;
using Core.Economy;
using TowerDefense.Towers.Data;
using TowerDefense.Economy;

namespace TowerDefense.Level
{
    /// <summary>
    /// The level manager - handles the level states and tracks the player's currency
    /// </summary>
    
    public class LevelManagerYfb : Singleton<LevelManagerYfb>
    {
        /// <summary>
        /// The configured level intro. 
        /// If this is null the LevelManager will fall through to 
        /// the gameplay state (i.e. SpawningEnemies)
        /// </summary>
        public LevelIntro intro;

        /// <summary>
        /// The tower library for this level
        /// </summary>
        public TowerLibraryYfb towerLibrary;

        /// <summary>
        /// The currency that the player starts with
        /// </summary>
        public int startingCurrency;

        /// <summary>
        /// The current state of the level
        /// </summary>
        public LevelState levelState { get; protected set; }

        /// <summary>
        /// The currency controller
        /// </summary>
        public Currency currency { get; protected set; }

        /// <summary>
        /// The controller for gaining currency
        /// </summary>
        public CurrencyGainer currencyGainer;

        /// <summary>
        /// Fired when the level state is changed 
        /// - first parameter is the old state, second parameter is the new state
        /// </summary>
        public event Action<LevelState, LevelState> levelStateChanged;

        protected override void Awake()
        {
            base.Awake();

            levelState = LevelState.Intro;

            // Ensure currency change listener is assigned
            currency = new Currency(startingCurrency);
            currencyGainer.Initialize(currency);

            // If there's an intro use it, otherwise fall through to gameplay
            if (intro != null)
            {
                intro.introCompleted += IntroCompleted;
            }
            else
            {
                IntroCompleted();
            }

        }

        /// <summary>
        /// Fired when Intro is completed or immediately, if no intro is specified
        /// </summary>
        protected virtual void IntroCompleted()
        {
            ChangeLevelState(LevelState.Building);
        }

        /// <summary>
		/// Unsubscribes from events
		/// </summary>
		protected override void OnDestroy()
        {
            base.OnDestroy();
            //if (waveManager != null)
            //{
            //    waveManager.spawningCompleted -= OnSpawningCompleted;
            //}
            if (intro != null)
            {
                intro.introCompleted -= IntroCompleted;
            }

            //// Iterate through home bases and unsubscribe
            //for (int i = 0; i < numberOfHomeBases; i++)
            //{
            //    homeBases[i].died -= OnHomeBaseDestroyed;
            //}
        }

        /// <summary>
        /// Changes the state and broadcasts the event
        /// </summary>
        /// <param name="newState">The new state to transitioned to</param>
        protected virtual void ChangeLevelState(LevelState newState)
        {
            // If the state hasn't changed then return
            if (levelState == newState)
            {
                return;
            }

            LevelState oldState = levelState;
            levelState = newState;
            if (levelStateChanged != null)
            {
                levelStateChanged(oldState, newState);
            }

            switch (newState)
            {
                //case LevelState.SpawningEnemies:
                //    waveManager.StartWaves();
                //    break;
                //case LevelState.AllEnemiesSpawned:
                //    // Win immediately if all enemies are already dead
                //    if (numberOfEnemies == 0)
                //    {
                //        ChangeLevelState(LevelState.Win);
                //    }
                //    break;
                //case LevelState.Lose:
                //    SafelyCallLevelFailed();
                //    break;
                //case LevelState.Win:
                //    SafelyCallLevelCompleted();
                //    break;
            }
        }

    }
}
