using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChooserProps : Chooser
{
	public float[] probs;
	
	public int chooseItem()
	{
		return choose( probs );
	}
	
	public int chooseItemWithNoRepetition( List<int> reachedItems )
	{
		List<ChooserItem> validItems = new List<ChooserItem>();
		for ( int i = 0; i < probs.Length; i++ ) {
			if ( !reachedItems.Contains( i ) ) {
				validItems.Add( new ChooserItem( i, probs[i] ) );
			}
		}
		
		return chooseWithNoRepetition( validItems );
	}
	
	private int chooseWithNoRepetition( List<ChooserItem> validItems )
	{
		float total = 0.0f;
		foreach( ChooserItem item in validItems ) {
			total += item.prob;
		}
	
		float randomPoint = Random.value * total;
		for ( int i = 0; i < validItems.Count; i++ ) {
			if ( randomPoint < validItems[i].prob )
				return validItems[i].id;
			else
				randomPoint -= validItems[i].prob;
		}
	
		return validItems[validItems.Count - 1].id;
	}
}

public class ChooserItem
{
	public int id;
	public float prob;
	
	public ChooserItem( int id, float prob )
	{
		this.id = id;
		this.prob = prob;
	}
}