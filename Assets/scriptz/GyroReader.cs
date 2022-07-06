using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GyroReader : MonoBehaviour
{
    // Start is called before the first frame update
    /********************************************/
    public TMP_Text Qx,Qy,Qz,Qw,Tx,Ty,Tz,Td;
    // The Gyroscope is right-handed.  Unity is left handed.
    // Make the necessary change to the camera.
    void GyroModifyCamera()
    {
        Input.gyro.enabled = true;
        transform.rotation = GyroToUnity(Input.gyro.attitude);
        //Qx.text = Input.gyro.attitude.x.ToString();
        //Qy.text = Input.gyro.attitude.y.ToString();
        //Qz.text = Input.gyro.attitude.z.ToString();
        //Qw.text = Input.gyro.attitude.w.ToString();

        Qx.text = transform.rotation.x.ToString();
        Qy.text = transform.rotation.y.ToString();
        Qz.text = transform.rotation.z.ToString();
        Qw.text = transform.rotation.w.ToString();
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    //private void Update()
    //{
    //    GyroModifyCamera();
    //}
    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;

        GUILayout.Label("Orientation: " + Screen.orientation);
        GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
        GUILayout.Label("iphone width/font: " + Screen.width + " : " + GUI.skin.label.fontSize);
    }
    private void Awake()
    {
        Input.gyro.enabled = true;
    }
    void Start()
    {
        StartCoroutine(doinitin());
    }
    IEnumerator doinitin() {
        yield return new WaitForSeconds(2);
        StartCoroutine(InitializeGyro());
    }
    IEnumerator InitializeGyro()
    {
        Input.gyro.enabled = true;
        yield return null;
        //Debug.Log(Input.gyro.attitude); // attitude has data now
        GyroModifyCamera();
    }
}
