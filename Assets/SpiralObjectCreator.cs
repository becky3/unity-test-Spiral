﻿using UnityEngine;

public class SpiralObjectCreator : MonoBehaviour {

    [SerializeField]
    private GameObject createObject; // 生成するオブジェクト

    [SerializeField]
    private int itemCount = 100; // 生成するオブジェクトの数

    [SerializeField]
    private float radius = 5f; // 半径

    [SerializeField]
    private float repeat = 5f; // 何周期するか

    [SerializeField]
    private float length = 50f; // Z軸の長さ


    void Start () {

        var oneCycle = 2.0f * Mathf.PI; // sin の周期は 2π
        var oneLength = length / itemCount; // Z軸の1単位
        var z = transform.position.z - oneLength; // Z軸初期位置 (生成前に足しこみをしているので、一回分引いておく)

        for (var i = 0; i < itemCount; ++i)
        {

            var point = ((float)i / itemCount) * oneCycle; // 周期の位置 (1.0 = 100% の時 2π となる)
            var repeatPoint = point * repeat; // 繰り返し位置

            var x = Mathf.Sin(repeatPoint) * radius;
            var y = Mathf.Cos(repeatPoint) * radius;
            z += oneLength;

            var position = new Vector3(x, y, z);

            Instantiate(
                createObject, 
                position, 
                Quaternion.identity, 
                transform
            );

             

        }

		
	}
	
}
