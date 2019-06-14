using System;
using System.IO;
using System.Xml;
using System.Web;
using System.Configuration;
using System.Collections.Generic;
using CodeEffects.Rule.Asp;
using CodeEffects.Rule.Common;

namespace CodeEffects.Rule.Demo.Asp.Common
{
	public static class Storage
	{
		#region ================================================= Static Private Properties ===========================================
		private const byte MaxNumberOfRules = 50;

		private static string ip
		{
			get
			{
				string address = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
				if (string.IsNullOrWhiteSpace(address)) return "Unknown";
				// Under certain conditions Visual Stidio gives "::1" as IP of your localhost
				else return address.Length < 7 ? "127.0.0.1" : address;
			}
		}
		private static string file
		{
			get
			{
				return string.Format(
					"{0}{1}.config",
					HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["RuleStoragePath"]),
					Storage.ip);
			}
		}
		#endregion ====================================================================================================================

		#region ================================================= Static Public Methods ===============================================
		public static List<MenuItem> GetEvaluationRules()
		{
			return LoadRules(true);
		}
		public static List<MenuItem> GetAllRules()
		{
			// Get both execution and evaluation type rules, merge then and return the result
			List<MenuItem> evals = GetEvaluationRules();
			List<MenuItem> execs = LoadRules(false);
			evals.AddRange(execs);
			return evals;
		}
		public static void SaveRule(SaveEventArgs e)
		{
			if (!File.Exists(file)) File.WriteAllText(file, e.RuleXmlAsDocument);
			else
			{
				XmlDocument xml = new XmlDocument();
				xml.Load(file);
				XmlElement temp = xml.CreateElement("temp");
				temp.InnerXml = e.RuleXmlAsNode;
				foreach (XmlNode node in xml.DocumentElement.ChildNodes)
				{
					if (node.Attributes["id"].Value == e.RuleID)
					{
						node.InnerXml = temp.FirstChild.InnerXml;
						File.Delete(file);
						xml.Save(file);
						return;
					}
				}

				if (xml.DocumentElement.ChildNodes.Count > MaxNumberOfRules)
					throw new Exception("You saved the max allowed number of rules. Delete some of existing rules before saving new ones.");
				xml.DocumentElement.AppendChild(temp.FirstChild);
				File.Delete(file);
				xml.Save(file);
			}
		}
		public static string LoadRuleXml(RuleEventArgs e)
		{
			return LoadRuleXml(e.RuleID);
		}
		public static string LoadRuleXml(string ruleId)
		{
			XmlDocument xml = new XmlDocument();
			xml.Load(file);
			foreach (XmlNode node in xml.DocumentElement.ChildNodes)
				if (node.Attributes["id"].Value == ruleId)
					return node.OuterXml;
			return null;
		}
		public static void DeleteRule(RuleEventArgs e)
		{
			DeleteRule(e.RuleID);
		}
		public static void DeleteRule(string ruleId)
		{
			XmlDocument xml = new XmlDocument();
			xml.Load(file);

			// Check if this rule is still referenced in other rules
			foreach (XmlNode node in xml.DocumentElement.ChildNodes)
				if (node.Attributes["id"].Value != ruleId && node.InnerXml.Contains(ruleId))
					throw new RuleException("The rule that you are trying to delete is still referenced in other rules. Delete those rules first.");

			// Find and remove the rule
			foreach (XmlNode node in xml.DocumentElement.ChildNodes)
			{
				if (node.Attributes["id"].Value == ruleId)
				{
					xml.DocumentElement.RemoveChild(node);
					File.Delete(file);
					xml.Save(file);
					return;
				}
			}
			throw new RuleException("Could not find the rule with ID " + ruleId);
		}
		public static void SortRules(ICollection<MenuItem> rules)
		{
			if (rules == null) return;
			((List<MenuItem>)rules).Sort(delegate(MenuItem mi1, MenuItem mi2) { return mi1.DisplayName.CompareTo(mi2.DisplayName); });
		}
		public static void AddRuleToCollection(ICollection<MenuItem> rules, string id, string name, string description)
		{
			if (rules == null) rules = new List<MenuItem>();
			MenuItem item = ((List<MenuItem>)rules).Find(delegate(MenuItem el) { return el.ID == id; });
			if (item == null) rules.Add(new MenuItem(id, name, description));
			else
			{
				item.DisplayName = name;
				item.Description = description;
			}
		}
		public static void RemoveRuleFromCollection(ICollection<MenuItem> rules, string ruleID)
		{
			if (rules == null) return;
			foreach (MenuItem item in rules)
			{
				if (item.ID == ruleID)
				{
					rules.Remove(item);
					return;
				}
			}
		}
		#endregion ====================================================================================================================

		#region ================================================= Static Private Helpers ==============================================
		private static List<MenuItem> LoadRules(bool evalOnly)
		{
			List<MenuItem> list = new List<MenuItem>();
			if (File.Exists(file))
			{
				XmlDocument xml = new XmlDocument();
				xml.Load(file);
				XmlNamespaceManager m = new XmlNamespaceManager(xml.NameTable);
				m.AddNamespace("x", xml.DocumentElement.NamespaceURI);
				foreach (XmlNode node in xml.DocumentElement.ChildNodes)
					if(node.Attributes["eval"].Value == evalOnly.ToString().ToLower())
						list.Add(new MenuItem(
							node.Attributes["id"].Value,
							node.SelectSingleNode("x:name", m).InnerText,
							node.SelectSingleNode("x:description", m) == null ? null : node.SelectSingleNode("x:description", m).InnerText));
			}
			return list;
		}
		#endregion ====================================================================================================================
	}
}