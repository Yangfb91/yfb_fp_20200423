using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Utilities;
using TowerDefense.Towers.Data;

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

        protected override void Awake()
        {
            base.Awake();
        }
    }
}
