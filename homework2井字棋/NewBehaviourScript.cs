using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour{
    public int turn;//用于规定次序
    public int count;//判断操作数
    private int[,] cells = new int[3,3];

    // Start is called before the first frame update
    void Start () {
        restart();
	}
    //重启游戏
    void restart(){
        turn = 1;
        for (int i = 0; i < 3; ++i){
            for (int j = 0; j < 3; ++j){
                cells[i, j] = 0;
            }
        }
        count = 0;
    }

    //判断输赢的函数winCheck()
    private int winCheck(){
        for(int i=0;i<3;i++){
                if(cells[i,0]==cells[i,1]&&cells[i,1]==cells[i,2]){
                    if(cells[i,0]==1){
                        return 1;
                    }
                    if(cells[i,0]==2){
                        return 2;
                    }  
                }
        }
        for(int i=0;i<3;i++){
                if((cells[0,i]==cells[1,i]&&cells[1,i]==cells[2,i])){
                    if(cells[0,i]==1){
                        return 1;
                    }
                    if(cells[0,i]==2){
                        return 2;
                    }  
                }        
        }
        if(cells[0,0]==1&&cells[1,1]==1&&cells[2,2]==1||cells[0,2]==1&&cells[1,1]==1&&cells[2,0]==1){
            return 1;
        }
        if(cells[0,0]==2&&cells[1,1]==2&&cells[2,2]==2||cells[0,2]==2&&cells[1,1]==2&&cells[2,0]==2){
            return 2;
        }
        if(count==9){
            return 3;
        }
        return 0;
    }
// Update is called once per frame
    void Update(){
        
    }
    void OnGUI (){
        // Make a background box
        GUI.Box(new Rect(10,10,300,330), "GAME");
        if(GUI.Button(new Rect(320,300,80,30),"Restart")){
            restart();
        }
        //判断谁赢；
        
        int result = winCheck();
        switch(result){
            case 1:
            GUI.Label(new Rect(420,300,80,30),"O WIN");break;
            case 2:
            GUI.Label(new Rect(420,300,80,30),"X WIN");break;
            case 3:
            GUI.Label(new Rect(420,300,80,30),"DAUL");break;
        }

        // 下子
        for(int i=0;i<3;i++){
            for(int j=0;j<3;j++){
                if(cells[i,j]==1){
                    GUI.Button(new Rect(20+100*i,50+j*100,80,80),"O");
                }
                if(cells[i,j]==2){
                    GUI.Button(new Rect(20+100*i,50+j*100,80,80),"X");
                }
                if(GUI.Button(new Rect(20+100*i,50+j*100,80,80), ""))
                {
                    if (result == 0)
                    {
                        if (turn == 1) cells[i, j] = 1;
                        else cells[i, j] = 2;
                        count++;
                        turn = -turn;
                    }
                }

            }
        }
        

    }

}
