using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    // Screen Rate to 9:16
    float m_fScreenSizeWidth = Screen.width;
    float m_fScreenSizeHeight = (Screen.width / 9) * 16;

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;      // 화면이 절대 꺼지지 않도록 한다.
        Screen.orientation = ScreenOrientation.Portrait;    // 화면은 가로로 설정한다.
        Screen.SetResolution((int)m_fScreenSizeWidth, (int)m_fScreenSizeHeight, true);  // 9:16해상도 셋팅
    }
}
