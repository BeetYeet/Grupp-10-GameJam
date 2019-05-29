using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonUI : MonoBehaviour
{
	#region Classes
	public static CanonUI i
	{
		get; private set;
	}
	public canon1 canon1
	{
		get; private set;
	}
	public canon2 canon2
	{
		get; private set;
	}
	public canon3 canon3
	{
		get; private set;
	}
	public canon4 canon4
	{
		get; private set;
	}
	public canon5 canon5
	{
		get; private set;
	}
	public canon6 canon6
	{
		get; private set;
	}
	#endregion
	private void Start()
	{
		i = this;
		canon1 = GetComponentInChildren<canon1>();
		canon2 = GetComponentInChildren<canon2>();
		canon3 = GetComponentInChildren<canon3>();
		canon4 = GetComponentInChildren<canon4>();
		canon5 = GetComponentInChildren<canon5>();
		canon6 = GetComponentInChildren<canon6>();

	}
}