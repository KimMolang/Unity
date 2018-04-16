using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Input_Size : MonoBehaviour
{
    private InputField comInputField;

    void Awake()
    {
        comInputField = this.GetComponent<InputField>();

        // 이런 방법도 있고
        //comInputField.onValueChanged.AddListener(delegate { OnSizeChanged(); } );
        // 아래처럼 함수의 매개변수를 맞춰주는 방법이 있다.
        comInputField.onValueChanged.AddListener(OnSizeChanged);
        comInputField.onEndEdit.AddListener(OnSizeDecided);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnSizeChanged( string _strText )
    {
        //Debug.Log(_strText);
        //Debug.Log(comInputField.text);
    }

    private void OnSizeDecided(string _strText)
    {
        Debug.Log(_strText);
        //Debug.Log(comInputField.text);
    }
}
