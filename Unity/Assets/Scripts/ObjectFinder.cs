//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;

/// <summary>
/// Here 2 help.
/// Do not add variables.
/// Limit this class to FUNCTIONS.
/// Unity does not handle typical static classes well.
/// Currently this class provides persistent objects,
/// in a central location.
/// Sacrifice performance to maintain this function-only pattern
/// (Replace with better system when possible)
/// </summary>
public static class ObjectFinder
{
	/// <summary>
	/// Used internally to host components we couldn't find
	/// </summary>
	/// <returns>An "ObjectFinder" GameObject</returns>
	private static GameObject FindOrCreateObjectFinder ()
	{
		Type mine = typeof(ObjectFinder);
		string name = mine.Name;
		GameObject helper = GameObject.Find (name);
		if (helper == null) {
			helper = GameObject.CreatePrimitive (PrimitiveType.Quad);
			helper.name = name;
		}
		return helper;
	}
	
	/// <summary>
	/// Finds a component or creates one inside of an
	/// ObjectFinder Game Object
	/// </summary>
	/// <returns>Component</returns>
	public static T FindOrCreateComponent<T> () where T : Component
	{
		T item = GameObject.FindObjectOfType <T> ();
		if (item == null) {
			GameObject finder = FindOrCreateObjectFinder();
			item = finder.AddComponent<T>();
			Debug.Log("Object Finder: I couldn't find any " + typeof(T) + " so I created one."); 
		}
		return item;
	}
}
