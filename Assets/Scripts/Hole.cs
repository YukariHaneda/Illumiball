using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //どのボールを吸い寄せるかをタグで指定
    public string targetTag;
    bool isHolding;

    //getter
    //ボールが入っているかを返す
    public bool IsHolding() {
        return isHolding;
    }

    //isTriggerのコライダーに何かが侵入してきたときに動くメソッド
    //引数：侵入してきたcollider
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == targetTag) {
            isHolding = true;
        }
    }

    //isTriggerがcolliderからものが出ていったときに動くメソッド
    void OnTrrigerExit (Collider other) {
        if (other.gameObject.tag == targetTag) {
            isHolding = false;
        }
    }

    //isTriggerなコライダーにモノが接触している間中動くメソッド
    void OnTriggerStay(Collider other) {
        //コライダーに振れていBallオブジェクトのRigidbodyコンポーネントを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        //ボールがどの方向にあるかを計算　※transformのみは「GetComponent」はいらない
        // いきなりtransform：このスクリプトがアタッチされているゲームオブジェクトのtransformのこと
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();

        //タグに応じてボールに力を加える
        if (other.gameObject.tag == targetTag) {
            //中心地点でボールを止めるため速度を減速させる　なければずっとホールを行ったり来たりしてしまう
            r.velocity *= 0.9f;
            r.AddForce(direction * -20.0f, ForceMode.Acceleration); 
        }else {
            r.AddForce(direction * 80.0f, ForceMode.Acceleration);
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
