using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GyroReader : MonoBehaviour
{
    // Start is called before the first frame update
    /********************************************/
    public TMP_Text Qx,Qy,Qz,Qw,Tx,Ty,Tz,Td;
    Quaternion curRot;
    public Quaternion cur_U_Rot;
    // The Gyroscope is right-handed.  Unity is left handed.
    public GameObject CubeKey;
    void GyroModifyCamera()
    {
        cur_U_Rot = DeviceGyro.Get();
        
        //Qx.text = Input.gyro.attitude.x.ToString();
        //Qy.text = Input.gyro.attitude.y.ToString();
        //Qz.text = Input.gyro.attitude.z.ToString();
        //Qw.text = Input.gyro.attitude.w.ToString();

        Qx.text =cur_U_Rot.x.ToString();
        Qy.text =cur_U_Rot.y.ToString();
        Qz.text =cur_U_Rot.z.ToString();
        Qw.text =cur_U_Rot.w.ToString();


        //Debug.Log("qx= " + cur_U_Rot.x.ToString());
    }

    //private  Quaternion GyroToUnity(Quaternion q)
    //{
    //    return new Quaternion(q.x, q.y, -q.z, -q.w);
    //}

    //protected void OnGUI()
    //{
    //    GUI.skin.label.fontSize = Screen.width / 40;

    //    GUILayout.Label("Orientation: " + Screen.orientation);
    //    GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
    //    GUILayout.Label("iphone width/font: " + Screen.width + " : " + GUI.skin.label.fontSize);
    //}
    private void Awake()
    {
       
    }
    void Start()
    {
        Input.gyro.enabled = true;
       // StartCoroutine(doinitin());
    }
    private void Update()
    {
        GyroModifyCamera();
        CubeKey.transform.rotation = cur_U_Rot;
    }
    //IEnumerator doinitin() {
    //    yield return new WaitForSeconds(2);
    //    StartCoroutine(InitializeGyro());
    //}
    //IEnumerator InitializeGyro()
    //{
    //    Input.gyro.enabled = true;
    //    yield return null;
    //    //Debug.Log(Input.gyro.attitude); // attitude has data now
    //    GyroModifyCamera();
    //}
}
