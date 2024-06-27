using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    private Image arrowImage;
    private Vector3 clickPosition;

    // Start is called before the first frame update
    void Start()
    {
        // 矢印を消す
        arrowImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ドラッグ開始位置（スクリーン空間の座標）を保存する
            clickPosition = Input.mousePosition;
            arrowImage.rectTransform.sizeDelta = Vector2.zero;
            // 矢印を表示する
            arrowImage.gameObject.SetActive(true);
        }   // マウス左ボタン(0)がプレス（押下）されたことを検出する
        else if (Input.GetMouseButton(0))
        {
            // 矢印を移動する
            arrowImage.rectTransform.position = clickPosition;
            // ドラッグと逆方向のベクトルを計算する
            Vector2 dragVector = clickPosition - Input.mousePosition;
            // 矢印をベクトルの方向に向ける
            arrowImage.rectTransform.right = dragVector;
            // ドラッグのベクトルの距離を求める
            float size = dragVector.magnitude;
            // 画像のサイズを変える
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 矢印を消す
            arrowImage.gameObject.SetActive(false);
        }
    }
}
