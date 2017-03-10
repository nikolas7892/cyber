﻿
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using SimpleFirebaseUnity;
using SimpleFirebaseUnity.MiniJSON;

using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;

public class Checkout : MonoBehaviour {
	
	System.Guid myGUID = System.Guid.NewGuid();

	public static string rxsRedPurchased;
	public static string rxsBluePurchased;
	public static string rxsGreenPurchased;
	public static string rxsBlackPurchased;

	public void checkedOUT(){
		StartCoroutine (checkoutCompleted ());
	}


	IEnumerator checkoutCompleted() {

		rxsRedPurchased = RedPurchase.rxsRedShoeDetails;
		rxsBlackPurchased = BlackPurchase.rxsBlackShoeDetails;
		rxsGreenPurchased = GreenPurchase.rxsGreenShoeDetails;
			rxsBluePurchased = BluePurchase.rxsBlueShoeDetails;

//		Firebase firebase = Firebase.CreateNew ("fir-test-884fd.firebaseio.com");
		Firebase firebase = Firebase.CreateNew ("cybershop-f4213.firebaseio.com");
	
		FirebaseQueue firebaseQueue = new FirebaseQueue();

		//firebaseQueue.AddQueuePush(firebase.Child("order/customer", true), secondDetails + newDetails, true);
		firebaseQueue.AddQueuePush(firebase.Child("customers/" + myGUID, true), "{asdf}", true);
		firebaseQueue.AddQueuePush(firebase.Child("customers/" + myGUID + "/RedShoe", true), rxsRedPurchased, true);
		firebaseQueue.AddQueuePush(firebase.Child("customers/" + myGUID + "/BlueShoe", true), rxsBluePurchased, true);
		firebaseQueue.AddQueuePush(firebase.Child("customers/" + myGUID + "/GreenShoe", true), rxsGreenPurchased, true);
		firebaseQueue.AddQueuePush(firebase.Child("customers/" + myGUID + "/BlackShoe", true), rxsBlackPurchased, true);

		print ("WORKS");


		yield return new WaitForSeconds (15f);

		yield return null;


	}


}
