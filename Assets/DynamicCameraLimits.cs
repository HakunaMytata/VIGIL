using UnityEngine;
using System.Collections;
using AC;



[RequireComponent (typeof (GameCamera2D))]

public class DynamicCameraLimits : MonoBehaviour

{



	#region Variables



	[SerializeField] private CameraLimits fourByThree = new CameraLimits (1.333f);

	[SerializeField] private CameraLimits sixteenByNine = new CameraLimits (1.778f);



	private GameCamera2D gameCamera2D;



	#endregion





	#region UnityStandards



	private void OnEnable ()

	{

		gameCamera2D = GetComponent <GameCamera2D>();

		EventManager.OnUpdatePlayableScreenArea += OnUpdatePlayableScreenArea;

	}





	private void OnDisable ()

	{

		EventManager.OnUpdatePlayableScreenArea -= OnUpdatePlayableScreenArea;

	}



	#endregion





	#region PrivateFunctions



	private void OnUpdatePlayableScreenArea ()

	{

		float aspectRatio = GetAspectRatio ();



		if (gameCamera2D.limitHorizontal)

		{

			Vector2 hLimits = GetLimits (aspectRatio, true);

			gameCamera2D.constrainHorizontal = hLimits;

		}



		if (gameCamera2D.limitVertical)

		{

			Vector2 vLimits = GetLimits (aspectRatio, false);

			gameCamera2D.constrainVertical = vLimits;

		}

	}





	private float GetAspectRatio ()

	{

		Vector2 windowSize = ACScreen.safeArea.size;

		return windowSize.x / windowSize.y;

	}





	private Vector2 GetLimits (float aspectRatio, bool isHorizontal)

	{

		Vector2 fourByThreeLimits = (isHorizontal) ? fourByThree.horizontalLimits : fourByThree.verticalLimits;

		Vector2 sixteenByNineLimits = (isHorizontal) ? sixteenByNine.horizontalLimits : sixteenByNine.verticalLimits;



		float minGradient = (sixteenByNineLimits.x - fourByThreeLimits.x) / (sixteenByNine.AspectRatio - fourByThree.AspectRatio);

		float minIntercept = fourByThreeLimits.x - (minGradient * fourByThree.AspectRatio);



		float maxGradient = (sixteenByNineLimits.y - fourByThreeLimits.y) / (sixteenByNine.AspectRatio - fourByThree.AspectRatio);

		float maxIntercept = fourByThreeLimits.y - (maxGradient * fourByThree.AspectRatio);



		Vector2 newLimits = new Vector2 (minIntercept, maxIntercept) + new Vector2 (minGradient * aspectRatio, maxGradient * aspectRatio);

		return newLimits;

	}



	#endregion





	#region PrivateClasses



	[System.Serializable]

	private class CameraLimits

	{



		public Vector2 horizontalLimits, verticalLimits;

		private float aspectRatio;





		public CameraLimits (float aspectRatio)

		{

			this.aspectRatio = aspectRatio;

			horizontalLimits = verticalLimits = Vector2.zero;

		}





		public float AspectRatio

		{

			get

			{

				return aspectRatio;

			}

		}



	}



	#endregion



}

