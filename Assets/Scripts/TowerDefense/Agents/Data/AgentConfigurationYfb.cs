using UnityEngine;

namespace TowerDefense.Agents.Data
{
	[CreateAssetMenu(fileName = "AgentConfigurationYfb.asset", menuName = "TowerDefense/Agent ConfigurationYfb", order = 1)]
	public class AgentConfigurationYfb : ScriptableObject
	{
		/// <summary>
		/// The name of the agent
		/// </summary>
		public string agentName;

		/// <summary>
		/// Short summary of the agent
		/// </summary>
		[Multiline]
		public string agentDescription;

		/// <summary>
		/// The Agent prefab that will be used on instantiation
		/// </summary>
		public AgentYfb agentPrefab;
	}
}