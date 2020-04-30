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
        /// The tower library for this level
        /// </summary>
        public TowerLibrary towerLibrary;

        /// <summary>
        /// The currency that the player starts with
        /// </summary>
        public int startingCurrency;

        /// <summary>
        /// The currency controller
        /// </summary>
        public Currency currency { get; protected set; }

        /// <summary>
        /// The controller for gaining currency
        /// </summary>
        public CurrencyGainer currencyGainer;

        protected override void Awake()
        {
            base.Awake();

            // Ensure currency change listener is assigned
            currency = new Currency(startingCurrency);
            currencyGainer.Initialize(currency);

        }
    }
}
