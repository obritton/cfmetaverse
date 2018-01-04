using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CfmTrackableEventHandler : DefaultTrackableEventHandler {

	public CfmContentLoader contentLoader;

	protected override void OnTrackingFound()
	{
		base.OnTrackingFound ();
		contentLoader.targetFound(gameObject.name);
	}
}
