using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearDetector : MonoBehaviour
{
    // hole型のオブジェクトのフィールド
    public Hole holeRed;
    public Hole holeBlue;
    public Hole holeGreen;

    //1秒間役60回動く画面に出力するメソッド
    void OnGUI() {
        //すべてのボールが入ったらラベルを表示
        if (holeRed.IsHolding() && holeBlue.IsHolding() && holeGreen.IsHolding()) {
            GUI.Label(new Rect(50, 50, 100, 30), "Game Clear!"); //x座標,y座標,width,heightを表す
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
