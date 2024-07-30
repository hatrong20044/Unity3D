using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField]private Rigidbody rb;
    [SerializeField]private LayerMask groundLayer;
    [SerializeField] private Transform skin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 nextPoint =JoystickControl.direct*speed*Time.deltaTime + transform.position;
            transform.position = CheckGround(nextPoint);
            skin.forward = JoystickControl.direct;
        }
        
    }
    //check diem tiep theo co phai la ground khong
    //+ tra ve vi tri next do
    //- tra ve vi tri hien tai
    public Vector3 CheckGround(Vector3 nextPoint)
    {
        RaycastHit hit;//luu tru thong tin ve va cham 
        if(Physics.Raycast(nextPoint, Vector3.down, out hit,2f,groundLayer)) {//phat 1 tia ray tu vi tri nextpoint,huong xuong duoi,
            //out hit luu tru thong tin ve va cham neu co,2f la khoang cach tia ray,groundLayer xác định các lớp mà tia sẽ tuong tác với
            //nếu nếu tua va chạm với lớp layer,bên trong câu lệnh if dc thực hiện,
            return hit.point+Vector3.up*1.1f;//trả về điểm va chạm hit.point một độ lệch Vector3.up nhân với 1.1f.
                                             ////Điều này được thực hiện để đảm bảo rằng vị trí trả về nằm phía trên mặt đất một chút.
        }
        return transform.position;
    }
}
