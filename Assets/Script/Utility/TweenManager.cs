/**    
@file    TweenManager.cs
@author  김경호(kyoungho@nlabsoft.com)
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
@class	TweenManager
@author 김경호(kyoungho@nlabsoft.com)
@brief	GameObject에 Tween을 사용할 수 있게 해준다.
*/

public class TweenManager : MonoBehaviour {
	
	static private TweenManager _tweenManager;
	
	private List<TweenInformation> _tweenObjectList = new List<TweenInformation>();	/**< Tween이 진행중인 GameObject들의 List */
	
	public enum EaseType
	{
		Linear,
		Clerp,
		Spring,
		EaseInQuad,
		EaseOutQuad,
		EaseInOutQuad,
		EaseInCubic,
		EaseOutCubic,
		EaseInOutCubic,
		EaseInQuart,
		EaseOutQuart,
		EaseInOutQuart,
		EaseInQuint,
		EaseOutQuint,
		EaseInOutQuint,
		EaseInSine,
		EaseOutSine,
		EaseInOutSine,
		EaseInExpo,
		EaseOutExpo,
		EaseInOutExpo,
		EaseInCirc,
		EaseOutCirc,
		EaseInOutCirc,
		EaseInBounce,
		EaseOutBounce,
		EaseInOutBounce,
		EaseInBack,
		EaseOutBack,
		EaseInOutBack,
		EaseInElastic,
		EaseOutElastic,
		EaseInOutElastic
	}
	
	public enum TweenType
	{
		Position,
		Scale,
		Rotation,
		Ambient,
		Fog,
		TimeScale,
		PositionX,
		PositionY,
		PositionZ
	}
	bool _isPause = false;
	
	
	static public TweenManager GetSharedInstance()
	{
		if (_tweenManager == null)
		{
			GameObject gameObj = new GameObject();
			gameObj.name = "TweenManager";
			gameObj.AddComponent<TweenManager>();
			_tweenManager = gameObj.GetComponent<TweenManager>();
		}
		return _tweenManager;
	}
	
	public void SetIsPause( bool onoff )
	{
		_isPause = onoff;
	}
	
	public void PositionXYZEaseDelay(GameObject targetObject, EaseType type,TweenType tweentype, float start, float end,float delay, float duration, bool isLocal = false, EventHandler hdr = null)
	{
		TweenInformation info = new TweenInformation();
		
		info.SetTweenValue(type, tweentype , targetObject, duration, delay, isLocal, hdr, new Vector2(start, end));
		
		_tweenObjectList.Add(info);
	}
	
	/**		
	@fn 	public void FloatEase(GameObject targetObject, EaseType type, Vector3 start, Vector3 end, float duration, bool isLocal = false, EventHandler hdr = null)
	@author 김경호(kyoungho@nlabsoft.com)
	@brief	GameObject position을 트윈한다.
	@param	targetObject tween할 GameObject
	@param	type	Tween에 사용할 Ease Type	
	@param	start	시작점
	@param 	end 도착점
	@param	duration Tween의 지속시간
	@param	isLocal	위치 이동의 공간이 로컬인지 월드인지 셋팅
	@param	hdr	이동이 끝난 후 호출될 Event함수
	*/
	public void PositionXYZEase(GameObject targetObject, EaseType type,TweenType tweentype, float start, float end, float duration, bool isLocal = false, EventHandler hdr = null)
	{
		TweenInformation info = new TweenInformation();
		
		info.SetTweenValue(type, tweentype , targetObject, duration, 0.0f, isLocal, hdr, new Vector2(start, end));
		
		_tweenObjectList.Add(info);
	}
	
	
	/**		
	@fn 	public void PositionEase(GameObject targetObject, EaseType type, Vector3 start, Vector3 end, float duration, bool isLocal = false, EventHandler hdr = null)
	@author 김경호(kyoungho@nlabsoft.com)
	@brief	GameObject position을 트윈한다.
	@param	targetObject tween할 GameObject
	@param	type	Tween에 사용할 Ease Type	
	@param	start	시작점
	@param 	end 도착점
	@param	duration Tween의 지속시간
	@param	isLocal	위치 이동의 공간이 로컬인지 월드인지 셋팅
	@param	hdr	이동이 끝난 후 호출될 Event함수
	*/
	public void PositionEase(GameObject targetObject, EaseType type, Vector3 start, Vector3 end, float duration, bool isLocal = false, EventHandler hdr = null, object obj = null)
	{
		TweenInformation info = new TweenInformation();
		
		info.SetTweenValue(type, TweenType.Position, targetObject, duration, 0.0f, isLocal, hdr, obj, new Vector2(start.x, end.x), new Vector2(start.y, end.y), new Vector2(start.z, end.z));
		
		_tweenObjectList.Add(info);
	}
	
	/**		
	@fn 	public void PositionEase(GameObject targetObject, EaseType type, Vector3 end, float duration, bool isLocal = false, EventHandler hdr = null)
	@author 김경호(kyoungho@nlabsoft.com)
	@brief	GameObject position을 트윈한다.
	@param	targetObject tween할 GameObject
	@param	type	Tween에 사용할 Ease Type	
	@param 	end 도착점. start는 현재위치
	@param	duration Tween의 지속시간
	@param	isLocal	위치 이동의 공간이 로컬인지 월드인지 셋팅
	@param	hdr	이동이 끝난 후 호출될 Event함수
	*/
	public void PositionEase(GameObject targetObject, EaseType type, Vector3 end, float duration, bool isLocal = false, EventHandler hdr = null, object obj = null)
	{
		if(isLocal == true)
		{
			PositionEase(targetObject, type, targetObject.transform.localPosition, end, duration, isLocal, hdr, obj);
		}
		else
		{
			PositionEase(targetObject, type, targetObject.transform.position, end, duration, isLocal, hdr, obj);
		}
	}
	
	public void PositionEaseDelay(GameObject targetObject, EaseType type, Vector3 end, float duration, float delay, bool isLocal = false, EventHandler hdr = null)
	{
		if(isLocal == true)
		{
			TweenInformation info = new TweenInformation();
			
			info.SetTweenValue(type, TweenType.Position, targetObject, duration, delay, isLocal, hdr, new Vector2(targetObject.transform.localPosition.x, end.x),
			                   new Vector2(targetObject.transform.localPosition.y, end.y), new Vector2(targetObject.transform.localPosition.z, end.z));
			
			_tweenObjectList.Add(info);
		}
		else
		{
			TweenInformation info = new TweenInformation();
			
			info.SetTweenValue(type, TweenType.Position, targetObject, duration, delay, isLocal, hdr, new Vector2(targetObject.transform.position.x, end.x),
			                   new Vector2(targetObject.transform.position.y, end.y), new Vector2(targetObject.transform.position.z, end.z));
			
			_tweenObjectList.Add(info);
		}
	}
	
	public void PositionEaseStop(GameObject targetObject)
	{	
		for(int i = 0 ; i < _tweenObjectList.Count ; i++)
		{
			TweenInformation info = _tweenObjectList[i];
			if(info._targetObject == targetObject && info._tweenType == TweenType.Position)
			{
				_tweenObjectList.Remove(info);
				return;
			}
		}
	}
	
	/**		
	@fn 	public void ScaleEase(GameObject targetObject, EaseType type, Vector3 start, Vector3 end, float duration, EventHandler hdr = null)
	@author 김경호(kyoungho@nlabsoft.com)
	@brief	GameObject Scale을 트윈한다.
	@param	targetObject tween할 GameObject
	@param	type	Tween에 사용할 Ease Type	
	@param	start	시작크기
	@param 	end 목표크기
	@param	duration Tween의 지속시간
	@param	hdr	Tween이 끝난 후 호출될 Event함수
	*/
	public void ScaleEase(GameObject targetObject, EaseType type, Vector3 start, Vector3 end, float duration, EventHandler hdr = null)
	{
		TweenInformation info = new TweenInformation();
		
		info.SetTweenValue(type, TweenType.Scale, targetObject, duration, 0.0f, true, hdr, new Vector2(start.x, end.x), new Vector2(start.y, end.y), new Vector2(start.z, end.z));
		
		_tweenObjectList.Add(info);
	}
	
	/**		
	@fn 	public void ScaleEase(GameObject targetObject, EaseType type, Vector3 end, float duration, EventHandler hdr = null)
	@author 김경호(kyoungho@nlabsoft.com)
	@brief	GameObject Scale을 트윈한다.
	@param	targetObject tween할 GameObject
	@param	type	Tween에 사용할 Ease Type	
	@param 	end 목표크기
	@param	duration Tween의 지속시간
	@param	hdr	Tween 이 끝난 후 호출될 Event함수
	*/
	public void ScaleEase(GameObject targetObject, EaseType type, Vector3 end, float duration, EventHandler hdr = null)
	{
		ScaleEase(targetObject, type, targetObject.transform.localScale, end, duration, hdr);
	}
	
	public void ScaleEaseDelay(GameObject targetObject, EaseType type, Vector3 end, float duration, float delay, EventHandler hdr = null)
	{
		//StartCoroutine(
	}
	
	IEnumerator ScaleEaseDelayCoroutine(GameObject targetObject, EaseType type, Vector3 end, float duration, float delay, EventHandler hdr = null)
	{
		yield return new WaitForSeconds(delay);
		
		ScaleEase(targetObject, type, end, duration, hdr);
	}
	
	public void ScaleEaseStop(GameObject targetObject)
	{
		StopCoroutine("ScaleEaseDelayCoroutine");
		
		for(int i = 0 ; i < _tweenObjectList.Count ; i++)
		{
			TweenInformation info = _tweenObjectList[i];
			if(info._targetObject == targetObject)
			{
				_tweenObjectList.Remove(info);
				return;
			}
		}
	}
	
	/**		
	@fn 	public void RotationEase(GameObject targetObject, EaseType type, Quaternion start, Quaternion end, float duration, bool isLocal = false, EventHandler hdr = null)
	@author 김경호(kyoungho@nlabsoft.com)
	@brief	GameObject 회전을 트윈한다.
	@param	targetObject tween할 GameObject
	@param	type	Tween에 사용할 Ease Type	
	@param	start	시작 Quaternion
	@param 	end 목표 Quaternion
	@param	duration Tween의 지속시간
	@param	hdr	Tween 이 끝난 후 호출될 Event함수
	*/
	public void RotationEase(GameObject targetObject, EaseType type, Quaternion start, Quaternion end, float duration, bool isLocal = false, EventHandler hdr = null)
	{
		TweenInformation info = new TweenInformation();
		
		float tempEndX;
		float tempEndY;
		float tempEndZ;
		
		if(start.eulerAngles.x > end.eulerAngles.x)
		{
			tempEndX = end.eulerAngles.x + 360.0f;
		}
		else
		{
			tempEndX = end.eulerAngles.x - 360.0f;
		}
		
		if(Mathf.Abs(start.eulerAngles.x - end.eulerAngles.x) < Mathf.Abs(start.eulerAngles.x - tempEndX))
		{
			tempEndX = end.eulerAngles.x;
		}
		
		if(start.eulerAngles.y > end.eulerAngles.y)
		{
			tempEndY = end.eulerAngles.y + 360.0f;
		}
		else
		{
			tempEndY = end.eulerAngles.y - 360.0f;
		}
		
		if(Mathf.Abs(start.eulerAngles.y - end.eulerAngles.y) < Mathf.Abs(start.eulerAngles.y - tempEndY))
		{
			tempEndY = end.eulerAngles.y;
		}
		
		if(start.eulerAngles.z > end.eulerAngles.z)
		{
			tempEndZ = end.eulerAngles.z + 360.0f;	
		}
		else
		{
			tempEndZ = end.eulerAngles.z - 360.0f;
		}
		
		if(Mathf.Abs(start.eulerAngles.z - end.eulerAngles.z) < Mathf.Abs(start.eulerAngles.z - tempEndZ))
		{
			tempEndZ = end.eulerAngles.z;
		}
		
		//Debug.Log(tempEndY);
		
		info.SetTweenValue(type, TweenType.Rotation, targetObject, duration, 0.0f, isLocal, hdr, new Vector2(start.eulerAngles.x, tempEndX),
		                   new Vector2(start.eulerAngles.y, tempEndY), new Vector2(start.eulerAngles.z, tempEndZ));
		
		_tweenObjectList.Add(info);
	}
	
	/**		
	@fn 	public void RotationEase(GameObject targetObject, EaseType type, Quaternion end, float duration, bool isLocal = false, EventHandler hdr = null)
	@author 김경호(kyoungho@nlabsoft.com)
	@brief	GameObject 회전을 트윈한다.
	@param	targetObject tween할 GameObject
	@param	type	Tween에 사용할 Ease Type	
	@param 	end 목표 Quaternion
	@param	duration Tween의 지속시간
	@param	hdr	Tween 이 끝난 후 호출될 Event함수
	*/
	public void RotationEase(GameObject targetObject, EaseType type, Quaternion end, float duration, bool isLocal = false, EventHandler hdr = null)
	{
		if(isLocal == true)
		{
			RotationEase(targetObject, type, targetObject.transform.localRotation, end, duration, isLocal, hdr);
		}
		else
		{
			RotationEase(targetObject, type, targetObject.transform.rotation, end, duration, isLocal, hdr);
		}
	}
	
	public void RotationEaseDelay(GameObject targetObject, EaseType type, Quaternion end, float duration, float delay, bool isLocal = false, EventHandler hdr = null)
	{
		StartCoroutine(RotationEaseCoroutine(targetObject, type, end, duration, delay, isLocal, hdr));
	}
	
	IEnumerator RotationEaseCoroutine(GameObject targetObject, EaseType type, Quaternion end, float duration, float delay, bool isLocal = false, EventHandler hdr = null)
	{
		yield return new WaitForSeconds(delay);
		
		RotationEase(targetObject, type, end, duration, isLocal, hdr);
	}
	
	public void RotationEaseStop(GameObject targetObject)
	{
		StopCoroutine("RotationEaseCoroutine");
		
		for(int i = 0 ; i < _tweenObjectList.Count ; i++)
		{
			TweenInformation info = _tweenObjectList[i];
			if(info._targetObject == targetObject)
			{
				_tweenObjectList.Remove(info);
				return;
			}
		}
	}
	
	/**		
	@fn 	public void AmbientLightEase(EaseType type, Color start, Color end, float duration)
	@author 김경호(kyoungho@nlabsoft.com)
	@brief	Ambient Light를 Tween한다.
	*/
	public void AmbientLightEase(EaseType type, Color start, Color end, float duration)
	{
		TweenInformation info = new TweenInformation();
		
		info.SetTweenValue(type, TweenType.Ambient, null, duration, 0.0f, false, null, new Vector2(start.r, end.r), new Vector2(start.g, end.g), new Vector2(start.b, end.b));
		
		_tweenObjectList.Add(info);
	}

    public void FogEase(EaseType type, Color start, Color end, float duration)
	{
		TweenInformation info = new TweenInformation();
		
		info.SetTweenValue(type, TweenType.Fog, null, duration, 0.0f, false, null, new Vector2(start.r, end.r), new Vector3(start.g, end.g), new Vector2(start.b, end.b));
		
		_tweenObjectList.Add(info);
	}
	
	/**		
	@fn 	public void TimeScaleEase(EaseType type, float start, float end, float duration)
	@author 김경호(kyoungho@nlabsoft.com)
	@brief	TimeScale을 Tween한다.
	*/
	public void TimeScaleEase(EaseType type, float start, float end, float duration)
	{
		TweenInformation info = new TweenInformation();
		
		info.SetTweenValue(type, TweenType.TimeScale, null, duration, 0.0f, false, null, new Vector2(start, end));
		
		_tweenObjectList.Add(info);
	}
	
	// Update is called once per frame
	void Update () {
		if( _isPause == false )
		{
			for(int i = 0 ; i < _tweenObjectList.Count ; i++)
			{
				TweenInformation info = _tweenObjectList[i];

				if(info._tweenType != TweenType.TimeScale)
				{
                    //if(info._targetObject == null)
                    //{
                    //    Debug.Log("Tween Target Object is Null : " + info._tweenType + "\t\t" + info._easeType + "\t\t" + info._time + "\t\t" + info._isLocal);
                    //    _tweenObjectList.Remove(info);
                    //    i--;
                    //    continue;
                    //}
				}
				
				if (info._currentTime >= 0.0f && info._currentTime < info._time)
				{
					for (int j = 0 ; j < info._start.Length ; j++)
					{
						switch(info._easeType)
						{
						case EaseType.Linear:
							info._currentValue[j] = linear(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.Clerp:
							info._currentValue[j] = clerp(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.Spring:
							info._currentValue[j] = spring(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInQuad:
							info._currentValue[j] = easeInQuad(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseOutQuad:
							info._currentValue[j] = easeOutQuad(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInOutQuad:
							info._currentValue[j] = easeInOutQuad(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInCubic:
							info._currentValue[j] = easeInCubic(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseOutCubic:
							info._currentValue[j] = easeOutCubic(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInOutCubic:
							info._currentValue[j] = easeInOutCubic(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInQuart:
							info._currentValue[j] = easeInQuart(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseOutQuart:
							info._currentValue[j] = easeOutQuart(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInOutQuart:
							info._currentValue[j] = easeInOutQuart(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInQuint:
							info._currentValue[j] = easeInQuint(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseOutQuint:
							info._currentValue[j] = easeOutQuint(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInOutQuint:
							info._currentValue[j] = easeInOutQuint(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInSine:
							info._currentValue[j] = easeInSine(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseOutSine:
							info._currentValue[j] = easeOutSine(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInOutSine:
							info._currentValue[j] = easeInOutSine(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInExpo:
							info._currentValue[j] = easeInExpo(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseOutExpo:
							info._currentValue[j] = easeOutExpo(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInOutExpo:
							info._currentValue[j] = easeInOutExpo(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInCirc:
							info._currentValue[j] = easeInCirc(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseOutCirc:
							info._currentValue[j] = easeOutCirc(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInOutCirc:
							info._currentValue[j] = easeInOutCirc(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInBounce:
							info._currentValue[j] = easeInBounce(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseOutBounce:
							info._currentValue[j] = easeOutBounce(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInOutBounce:
							info._currentValue[j] = easeInOutBounce(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInBack:
							info._currentValue[j] = easeInBack(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseOutBack:
							info._currentValue[j] = easeOutBack(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInOutBack:
							info._currentValue[j] = easeInOutBack(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInElastic:
							info._currentValue[j] = easeInElastic(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseOutElastic:
							info._currentValue[j] = easeOutElastic(info._start[j], info._end[j], info._currentTime / info._time);
							break;
							
						case EaseType.EaseInOutElastic:
							info._currentValue[j] = easeInOutElastic(info._start[j], info._end[j], info._currentTime / info._time);
							break;
						}
					}
					
					switch(info._tweenType)
					{
					case TweenType.Position:
						if(info._isLocal == true)
						{
							info._targetObject.transform.localPosition = new Vector3(info._currentValue[0], info._currentValue[1], info._currentValue[2]);
						}
						else
						{
							info._targetObject.transform.position = new Vector3(info._currentValue[0], info._currentValue[1], info._currentValue[2]);
						}
						break;
						
					case TweenType.Scale:
						info._targetObject.transform.localScale = new Vector3(info._currentValue[0], info._currentValue[1], info._currentValue[2]);
						break;
						
					case TweenType.Rotation:
						if(info._isLocal == true)
						{
							info._targetObject.transform.localRotation = Quaternion.Euler(info._currentValue[0], info._currentValue[1], info._currentValue[2]);
						}
						else
						{
							info._targetObject.transform.rotation = Quaternion.Euler(info._currentValue[0], info._currentValue[1], info._currentValue[2]);
						}
						break;
						
					case TweenType.Ambient:
						RenderSettings.ambientLight = new Color(info._currentValue[0], info._currentValue[1], info._currentValue[2], 0.0f);
						break;
						
					case TweenType.Fog:
						RenderSettings.fogColor = new Color(info._currentValue[0], info._currentValue[1], info._currentValue[2], 0.0f);
						break;
						
					case TweenType.TimeScale:
						Time.timeScale = info._currentValue[0];
						break;
					case TweenType.PositionX:
						if(info._isLocal == false)
						{
							info._targetObject.transform.position = new Vector3(info._currentValue[0] ,info._targetObject.transform.position.y, info._targetObject.transform.position.z);
						}
						else
						{
							info._targetObject.transform.localPosition = new Vector3(info._currentValue[0], info._targetObject.transform.localPosition.y, info._targetObject.transform.localPosition.z );
						}
						break;
					case TweenType.PositionY:
						if(info._isLocal == false)
						{
							info._targetObject.transform.position = new Vector3(info._targetObject.transform.position.x, info._currentValue[0], info._targetObject.transform.position.z);
						}
						else
						{
							info._targetObject.transform.localPosition = new Vector3(info._targetObject.transform.localPosition.x, info._currentValue[0], info._targetObject.transform.localPosition.z);
						}
						break;
					case TweenType.PositionZ:
						if(info._isLocal == false)
						{
							info._targetObject.transform.position = new Vector3(info._targetObject.transform.position.x, info._targetObject.transform.position.y, info._currentValue[0]);
						}
						else
						{
							info._targetObject.transform.localPosition = new Vector3(info._targetObject.transform.localPosition.x, info._targetObject.transform.localPosition.y, info._currentValue[0]);
						}
						break;		
					}
					info._currentTime += Time.deltaTime;	
				}
				else if(info._currentTime >= 0.0f && info._currentTime >= info._time)
				{
					switch(info._tweenType)
					{
					case TweenType.Position:
						if(info._isLocal == false)
						{
							info._targetObject.transform.position = new Vector3(info._end[0], info._end[1], info._end[2]);
						}
						else
						{
							info._targetObject.transform.localPosition = new Vector3(info._end[0], info._end[1], info._end[2]);
						}
						
						info.PlayEndEventHandler();
						break;
						
					case TweenType.Scale:
						info._targetObject.transform.localScale = new Vector3(info._end[0], info._end[1], info._end[2]);
						
						info.PlayEndEventHandler();
						break;
						
					case TweenType.Rotation:
						if(info._isLocal == false)
						{
							info._targetObject.transform.rotation = Quaternion.Euler(info._end[0], info._end[1], info._end[2]);
						}
						else
						{
							info._targetObject.transform.localRotation = Quaternion.Euler(info._end[0], info._end[1], info._end[2]);
						}
						
						info.PlayEndEventHandler();
						break;
						
					case TweenType.Ambient:
						RenderSettings.ambientLight = new Color(info._end[0], info._end[1], info._end[2], 0.0f);
						break;
						
					case TweenType.Fog:
						RenderSettings.fogColor = new Color(info._end[0], info._end[1], info._end[2], 0.0f);
						break;
						
					case TweenType.TimeScale:
						Time.timeScale = info._end[0];
						break;
					case TweenType.PositionX:
						if(info._isLocal == false)
						{
							info._targetObject.transform.position = new Vector3(info._end[0],info._targetObject.transform.position.y, info._targetObject.transform.position.z);
						}
						else
						{
							info._targetObject.transform.localPosition = new Vector3(info._end[0], info._targetObject.transform.localPosition.y, info._targetObject.transform.localPosition.z );
						}
						
						info.PlayEndEventHandler();
						break;
					case TweenType.PositionY:
						if(info._isLocal == false)
						{
							info._targetObject.transform.position = new Vector3(info._targetObject.transform.position.x, info._end[0], info._targetObject.transform.position.z);
						}
						else
						{
							info._targetObject.transform.localPosition = new Vector3(info._targetObject.transform.localPosition.x, info._end[0], info._targetObject.transform.localPosition.z);
						}
						
						info.PlayEndEventHandler();
						break;
					case TweenType.PositionZ:
						if(info._isLocal == false)
						{
							info._targetObject.transform.position = new Vector3(info._targetObject.transform.position.x, info._targetObject.transform.position.y, info._end[0]);
						}
						else
						{
							info._targetObject.transform.localPosition = new Vector3(info._targetObject.transform.localPosition.x, info._targetObject.transform.localPosition.y, info._end[0]);
						}
						
						info.PlayEndEventHandler();
						break;	
					}
					
					_tweenObjectList.Remove(info);
					i--;
				}
				else
				{
					info._currentTime += Time.deltaTime;
				}
			}
		}
	}
	
	static public float linear(float start, float end, float value){
		return Mathf.Lerp(start, end, value);
	}
	
	static public float clerp(float start, float end, float value){
		float min = 0.0f;
		float max = 360.0f;
		float half = Mathf.Abs((max - min) / 2.0f);
		float retval = 0.0f;
		float diff = 0.0f;
		if ((end - start) < -half){
			diff = ((max - start) + end) * value;
			retval = start + diff;
		}else if ((end - start) > half){
			diff = -((max - end) + start) * value;
			retval = start + diff;
		}else retval = start + (end - start) * value;
		return retval;
	}
	
	static public float spring(float start, float end, float value){
		value = Mathf.Clamp01(value);
		value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
		return start + (end - start) * value;
	}
	
	static public float easeInQuad(float start, float end, float value){
		end -= start;
		return end * value * value + start;
	}
	
	static public float easeOutQuad(float start, float end, float value){
		end -= start;
		return -end * value * (value - 2) + start;
	}
	
	static public float easeInOutQuad(float start, float end, float value){
		value /= .5f;
		end -= start;
		if (value < 1) return end / 2 * value * value + start;
		value--;
		return -end / 2 * (value * (value - 2) - 1) + start;
	}
	
	static public float easeInCubic(float start, float end, float value){
		end -= start;
		return end * value * value * value + start;
	}
	
	static public float easeOutCubic(float start, float end, float value){
		value--;
		end -= start;
		return end * (value * value * value + 1) + start;
	}
	
	static public float easeInOutCubic(float start, float end, float value){
		value /= .5f;
		end -= start;
		if (value < 1) return end / 2 * value * value * value + start;
		value -= 2;
		return end / 2 * (value * value * value + 2) + start;
	}
	
	static public float easeInQuart(float start, float end, float value){
		end -= start;
		return end * value * value * value * value + start;
	}
	
	static public float easeOutQuart(float start, float end, float value){
		value--;
		end -= start;
		return -end * (value * value * value * value - 1) + start;
	}
	
	static public float easeInOutQuart(float start, float end, float value){
		value /= .5f;
		end -= start;
		if (value < 1) return end / 2 * value * value * value * value + start;
		value -= 2;
		return -end / 2 * (value * value * value * value - 2) + start;
	}
	
	static public float easeInQuint(float start, float end, float value){
		end -= start;
		return end * value * value * value * value * value + start;
	}
	
	static public float easeOutQuint(float start, float end, float value){
		value--;
		end -= start;
		return end * (value * value * value * value * value + 1) + start;
	}
	
	static public float easeInOutQuint(float start, float end, float value){
		value /= .5f;
		end -= start;
		if (value < 1) return end / 2 * value * value * value * value * value + start;
		value -= 2;
		return end / 2 * (value * value * value * value * value + 2) + start;
	}
	
	static public float easeInSine(float start, float end, float value){
		end -= start;
		return -end * Mathf.Cos(value / 1 * (Mathf.PI / 2)) + end + start;
	}
	
	static public float easeOutSine(float start, float end, float value){
		end -= start;
		return end * Mathf.Sin(value / 1 * (Mathf.PI / 2)) + start;
	}
	
	static public float easeInOutSine(float start, float end, float value){
		end -= start;
		return -end / 2 * (Mathf.Cos(Mathf.PI * value / 1) - 1) + start;
	}
	
	static public float easeInExpo(float start, float end, float value){
		end -= start;
		return end * Mathf.Pow(2, 10 * (value / 1 - 1)) + start;
	}
	
	static public float easeOutExpo(float start, float end, float value){
		end -= start;
		return end * (-Mathf.Pow(2, -10 * value / 1) + 1) + start;
	}
	
	static public float easeInOutExpo(float start, float end, float value){
		value /= .5f;
		end -= start;
		if (value < 1) return end / 2 * Mathf.Pow(2, 10 * (value - 1)) + start;
		value--;
		return end / 2 * (-Mathf.Pow(2, -10 * value) + 2) + start;
	}
	
	static public float easeInCirc(float start, float end, float value){
		end -= start;
		return -end * (Mathf.Sqrt(1 - value * value) - 1) + start;
	}
	
	static public float easeOutCirc(float start, float end, float value){
		value--;
		end -= start;
		return end * Mathf.Sqrt(1 - value * value) + start;
	}
	
	static public float easeInOutCirc(float start, float end, float value){
		value /= .5f;
		end -= start;
		if (value < 1) return -end / 2 * (Mathf.Sqrt(1 - value * value) - 1) + start;
		value -= 2;
		return end / 2 * (Mathf.Sqrt(1 - value * value) + 1) + start;
	}
	
	static public float easeInBounce(float start, float end, float value){
		end -= start;
		float d = 1f;
		return end - easeOutBounce(0, end, d-value) + start;
	}
	
	static public float easeOutBounce(float start, float end, float value){
		value /= 1f;
		end -= start;
		if (value < (1 / 2.75f)){
			return end * (7.5625f * value * value) + start;
		}else if (value < (2 / 2.75f)){
			value -= (1.5f / 2.75f);
			return end * (7.5625f * (value) * value + .75f) + start;
		}else if (value < (2.5 / 2.75)){
			value -= (2.25f / 2.75f);
			return end * (7.5625f * (value) * value + .9375f) + start;
		}else{
			value -= (2.625f / 2.75f);
			return end * (7.5625f * (value) * value + .984375f) + start;
		}
	}
	
	static public float easeInOutBounce(float start, float end, float value){
		end -= start;
		float d = 1f;
		if (value < d/2) return easeInBounce(0, end, value*2) * 0.5f + start;
		else return easeOutBounce(0, end, value*2-d) * 0.5f + end*0.5f + start;
	}
	
	static public float easeInBack(float start, float end, float value){
		end -= start;
		value /= 1;
		float s = 1.70158f;
		return end * (value) * value * ((s + 1) * value - s) + start;
	}
	
	static public float easeOutBack(float start, float end, float value){
		float s = 1.70158f;
		end -= start;
		value = (value / 1) - 1;
		return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
	}
	
	static public float easeInOutBack(float start, float end, float value){
		float s = 1.70158f;
		end -= start;
		value /= .5f;
		if ((value) < 1){
			s *= (1.525f);
			return end / 2 * (value * value * (((s) + 1) * value - s)) + start;
		}
		value -= 2;
		s *= (1.525f);
		return end / 2 * ((value) * value * (((s) + 1) * value + s) + 2) + start;
	}
	
	static public float punch(float amplitude, float value){
		float s = 9;
		if (value == 0){
			return 0;
		}
		if (value == 1){
			return 0;
		}
		float period = 1 * 0.3f;
		s = period / (2 * Mathf.PI) * Mathf.Asin(0);
		return (amplitude * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * 1 - s) * (2 * Mathf.PI) / period));
	}
	
	static public float easeInElastic(float start, float end, float value){
		end -= start;
		
		float d = 1f;
		float p = d * .3f;
		float s = 0;
		float a = 0;
		
		if (value == 0) return start;
		
		if ((value /= d) == 1) return start + end;
		
		if (a == 0f || a < Mathf.Abs(end)){
			a = end;
			s = p / 4;
		}else{
			s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
		}
		
		return -(a * Mathf.Pow(2, 10 * (value-=1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
	}		
	
	static public float easeOutElastic(float start, float end, float value){
		end -= start;
		
		float d = 1f;
		float p = d * .3f;
		float s = 0;
		float a = 0;
		
		if (value == 0) return start;
		
		if ((value /= d) == 1) return start + end;
		
		if (a == 0f || a < Mathf.Abs(end)){
			a = end;
			s = p / 4;
		}else{
			s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
		}
		
		return (a * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) + end + start);
	}		
	
	static public float easeInOutElastic(float start, float end, float value){
		end -= start;
		
		float d = 1f;
		float p = d * .3f;
		float s = 0;
		float a = 0;
		
		if (value == 0) return start;
		
		if ((value /= d/2) == 2) return start + end;
		
		if (a == 0f || a < Mathf.Abs(end)){
			a = end;
			s = p / 4;
		}else{
			s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
		}
		
		if (value < 1) return -0.5f * (a * Mathf.Pow(2, 10 * (value-=1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
		return a * Mathf.Pow(2, -10 * (value-=1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) * 0.5f + end + start;
	}	
}

public delegate void EventHandler( object obj );

/**
@class	TweenInformation
@author 김경호(kyoungho@nlabsoft.com)
@brief	Tween의 정보를 담을 Container 클래스
*/
class TweenInformation 
{
	public GameObject _targetObject;
	
	public TweenManager.EaseType _easeType;
	public TweenManager.TweenType _tweenType;
	
	public float[] _start;
	public float[] _end;
	public float[] _currentValue;
	
	public float _currentTime;
	public float _time;
	
	//public float _delay;
	
	public bool _isLocal;
	
	
	public event EventHandler _endEventHandler;
	public object _obj;

	public void SetTweenValue(TweenManager.EaseType type, TweenManager.TweenType tweenType, GameObject tweenObject, float duration, float delay, bool isLocal, EventHandler hdr, object obj, params Vector2[] list)
	{
		SetTweenValue(type, tweenType, tweenObject, duration, delay, isLocal, hdr, list);
		_obj = obj;
	}
	
	public void SetTweenValue(TweenManager.EaseType type, TweenManager.TweenType tweenType, GameObject tweenObject, float duration, float delay, bool isLocal, EventHandler hdr, params Vector2[] list)
	{
		_easeType = type;
		_tweenType = tweenType;
		_targetObject = tweenObject;
		_isLocal = isLocal;
		_start = new float[list.Length];
		_end = new float[list.Length];
		_currentValue = new float[list.Length];
		_endEventHandler = hdr;
		
		for(int i = 0 ; i < list.Length ; i++)
		{
			_start[i] = list[i].x;
			_end[i] = list[i].y;
		}
		
		_currentTime = 0.0f - delay;
		_time = duration;
	}
	
	public void PlayEndEventHandler()
	{
		if(_endEventHandler != null)
		{
			_endEventHandler( _obj );
		}
	}
}
