using UnityEngine;
using System.Collections;

public class mapTest : MonoBehaviour {
    public int _maxRoom;
    public int _col, _row;

    public GameObject testObject;
    public GameObject hero;

	private struct room
	{
		public bool empty;

		public bool top;
		public bool left;
		public bool bottom;
		public bool right;
	}

	private room[,] map;
    private int[,] printingMap;
    private int printRoomC, maxRoom;
    private int startC, startR;

    private const int bigRoomRimit = 6; //넓은방 제한

	void compositionRoom(int col, int row)
	{
		//위, 오른쪽, 아래, 왼쪽
		int []dirC = {-1, 0, 1, 0}; 
		int []dirR = { 0, 1, 0, -1};
		int moveCol, moveRow;

		for (int i=0; i<4; i++) {
			moveCol = col + dirC[i];
			moveRow = row + dirR[i];

			if (moveCol >= 0 && moveCol < _col && moveRow >= 0 && moveRow < _row) {
				if(map[moveCol, moveRow].empty) {
					switch(i){
						case 0:
							map[col, row].top	 = true;
							break;
						case 1:
							map[col, row].right  = true;
							break;
						case 2:
							map[col, row].bottom = true;
							break;
						case 3:
							map[col, row].left 	 = true;
							break;
					}
				}
			}
		}
	}

    bool checkBigRoom(int col, int row)
    {
        int []dirC = {-1, -1, -1, 0, 1, 1,  1,  0};
        int []dirR = {-1,  0,  1, 1, 1, 0, -1, -1};
		int roomCount = 0;
		int moveCol, moveRow;

        for (int i = 0; i < 8; i++) {
            moveCol = col + dirC[i];
            moveRow = row + dirR[i];
            if (moveCol >= 0 && moveCol < _col && moveRow >= 0 && moveRow < _row) {
                if (map[moveCol, moveRow].empty) roomCount++;
            }
        }

        if (roomCount >= bigRoomRimit)  return true;
        else                            return false;
    }//사방이 방으로 둘려쌓였는지 체크(방 구성을 이쁘게 하기 위함)

    bool createRoom(int nowC, int nowR)
    {
	    int moveC = nowC;
	    int moveR = nowR;

	    if (maxRoom > 0) {
            if (nowC >= 0 && nowC < _col && nowR >= 0 && nowR < _row)
            {
				if (!map[nowC, nowR].empty && !checkBigRoom(nowC, nowR)) {
					map[nowC, nowR].empty = true;
                    maxRoom = maxRoom - 1;

                    if (startR == -1 || startR > nowR) {
                        startC = nowC;
                        startR = nowR;
                    }
			    }
		    } else {
			    return false;
		    }

            int direction = Random.Range(0, 4);

		    //위, 아래, 오른쪽, 왼쪽
		    switch (direction) {
			    case 0:
				    moveC++;
				    break;
			    case 1:
				    moveC--;
				    break;
			    case 2:
				    moveR++;
				    break;
			    case 3:
				    moveR--;
				    break;
			    case 4:
				    return false;
		    }

		    createRoom(moveC, moveR);
	    }

	    return true;
    }

    bool createDungeon(int sCol, int sRow)
    {
	    int nowC = _col / 2;
	    int nowR = _row / 2;
        startC = -1;
        startR = -1;

	    map = new room[_col, _row];

        maxRoom = _maxRoom;
	
	    for (int i = 0; i < _col; i++) {
		    for (int j = 0; j < _row; j++) {
				map[i, j].empty = false;
		    }
	    }

	    while (maxRoom > 0) {
            createRoom(nowC, nowR);
	    }//이슈 - 방을 못만들시 대응 없음

		for (int i = 0; i < _col; i++) {
			for (int j = 0; j < _row; j++) {
				if(map[i, j].empty) compositionRoom(i, j);
			}
		}

	    return false;
    }

    void printMap()
    {
		GameObject tempRoom;
        for (int i = 0; i < _col; i++) {
            for (int j = 0; j < _row; j++) {
				if(map[i, j].empty){
					tempRoom = Instantiate(testObject, new Vector3(34 * j, -35 * i, 0), Quaternion.identity) as GameObject;
					if(map[i, j].top)	 Destroy(tempRoom.gameObject.transform.Find("TopWall").FindChild("door").gameObject);
					if(map[i, j].right)	 Destroy(tempRoom.gameObject.transform.Find("RightWall").FindChild("door").gameObject);
					if(map[i, j].bottom) Destroy(tempRoom.gameObject.transform.Find("BottomWall").FindChild("door").gameObject);
					if(map[i, j].left)	 Destroy(tempRoom.gameObject.transform.Find("LeftWall").FindChild("door").gameObject);
				}
            }
        }

        Debug.Log("스타트 지점 (" + startC.ToString() + startR.ToString() + ")");

        hero.transform.position = new Vector2(34 * startR, -35 * startC);
    }

	// Use this for initialization
	void Start () {
        createDungeon(_col, _row);
        printMap();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}