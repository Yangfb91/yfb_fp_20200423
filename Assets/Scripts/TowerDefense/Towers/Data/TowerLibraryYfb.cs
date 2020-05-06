using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerDefense.Towers.Data
{
	/// <summary>
	/// The asset which holds the list of different towers
	/// </summary>
	[CreateAssetMenu(fileName = "TowerLibrary.asset", menuName = "TowerDefense/Tower Library Yfb", order = 2)]
	public class TowerLibraryYfb : ScriptableObject, IList<TowerYfb>, IDictionary<string, TowerYfb>
	{
		/// <summary>
		/// The list of all the towers
		/// </summary>
		public List<TowerYfb> configurations;

		/// <summary>
		/// The internal reference to the dictionary made from the list of towers
		/// with the name of tower as the key
		/// </summary>
		Dictionary<string, TowerYfb> m_ConfigurationDictionary;

		/// <summary>
		/// The accessor to the towers by index
		/// </summary>
		/// <param name="index"></param>
		public TowerYfb this[int index]
		{
			get { return configurations[index]; }
		}

		public void OnBeforeSerialize()
		{
		}

		/// <summary>
		/// Convert the list (m_Configurations) to a dictionary for access via name
		/// </summary>
		public void OnAfterDeserialize()
		{
			if (configurations == null)
			{
				return;
			}
			m_ConfigurationDictionary = configurations.ToDictionary(t => t.towerName);
		}

		public bool ContainsKey(string key)
		{
			return m_ConfigurationDictionary.ContainsKey(key);
		}

		public void Add(string key, TowerYfb value)
		{
			m_ConfigurationDictionary.Add(key, value);
		}

		public bool Remove(string key)
		{
			return m_ConfigurationDictionary.Remove(key);
		}

		public bool TryGetValue(string key, out TowerYfb value)
		{
			return m_ConfigurationDictionary.TryGetValue(key, out value);
		}

		TowerYfb IDictionary<string, TowerYfb>.this[string key]
		{
			get { return m_ConfigurationDictionary[key]; }
			set { m_ConfigurationDictionary[key] = value; }
		}

		public ICollection<string> Keys
		{
			get { return ((IDictionary<string, TowerYfb>) m_ConfigurationDictionary).Keys; }
		}

		ICollection<TowerYfb> IDictionary<string, TowerYfb>.Values
		{
			get { return m_ConfigurationDictionary.Values; }
		}

		IEnumerator<KeyValuePair<string, TowerYfb>> IEnumerable<KeyValuePair<string, TowerYfb>>.GetEnumerator()
		{
			return m_ConfigurationDictionary.GetEnumerator();
		}

		public void Add(KeyValuePair<string, TowerYfb> item)
		{
			m_ConfigurationDictionary.Add(item.Key, item.Value);
		}

		public bool Remove(KeyValuePair<string, TowerYfb> item)
		{
			return m_ConfigurationDictionary.Remove(item.Key);
		}

		public bool Contains(KeyValuePair<string, TowerYfb> item)
		{
			return m_ConfigurationDictionary.Contains(item);
		}

		public void CopyTo(KeyValuePair<string, TowerYfb>[] array, int arrayIndex)
		{
			int count = array.Length;
			for (int i = arrayIndex; i < count; i++)
			{
				TowerYfb config = configurations[i - arrayIndex];
				KeyValuePair<string, TowerYfb> current = new KeyValuePair<string, TowerYfb>(config.towerName, config);
				array[i] = current;
			}
		}

		public int IndexOf(TowerYfb item)
		{
			return configurations.IndexOf(item);
		}

		public void Insert(int index, TowerYfb item)
		{
			configurations.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			configurations.RemoveAt(index);
		}

		TowerYfb IList<TowerYfb>.this[int index]
		{
			get { return configurations[index]; }
			set { configurations[index] = value; }
		}

		public IEnumerator<TowerYfb> GetEnumerator()
		{
			return configurations.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable) configurations).GetEnumerator();
		}

		public void Add(TowerYfb item)
		{
			configurations.Add(item);
		}

		public void Clear()
		{
			configurations.Clear();
		}

		public bool Contains(TowerYfb item)
		{
			return configurations.Contains(item);
		}

		public void CopyTo(TowerYfb[] array, int arrayIndex)
		{
			configurations.CopyTo(array, arrayIndex);
		}

		public bool Remove(TowerYfb item)
		{
			return configurations.Remove(item);
		}

		public int Count
		{
			get { return configurations.Count; }
		}

		public bool IsReadOnly
		{
			get { return ((ICollection<TowerYfb>) configurations).IsReadOnly; }
		}
	}
}