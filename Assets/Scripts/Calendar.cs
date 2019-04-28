using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
	
	public GameObject cursor;
	
	private int dayCount = 1;
	private int MonthCount = 1;

	
	public void NextDay()
	{
		dayCount++;
		if(dayCount>=31)
		{
			dayCount = 1;
			MonthCount++;
			if(MonthCount >= 13)
			{
				MonthCount = 1;
			}
		}
		//cursor.Transform.Position = new Vector3( -0.8+0.3*((dayCount-dayCount%6)/6), 0.45-(0.3*((dayCount-dayCount%6)/6)),-0.01);
	}
}
