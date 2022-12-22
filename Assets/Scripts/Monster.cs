using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] ResourceObject monsterData = null;

    List<Vector2> mobPath = null;
    WaitForSeconds s1 = new WaitForSeconds(1);

    public void SettingPath(List<Vector2> path)
    {
        mobPath = path;
    }
    // Start is called before the first frame update
    void Start()
    {
        //findPath(2, 4, 1, 1);
        StartCoroutine(nameof(MoveMonster));
    }

    IEnumerator MoveMonster()
    {
        yield return s1;

        for(int i = 0; i < mobPath.Count; i++)
        {
            transform.position = mobPath[i];
            yield return s1;
        }
        Destroy(this.gameObject);
        yield return null;
    }
    

    /*
    ANode getNodeInOpenList()
    {
        ANode? node = null;
        OpenList.Sort((a, b) => a.Fscore.CompareTo(b.Fscore));
        node = OpenList[0];
        OpenList.RemoveAt(0);
        return node;
    }
    void findPath(int sy, int sx, int ey, int ex) //출발s 도착e
    {
        ANode startNode = myMaps[sy, sx];
        ANode endNode = myMaps[ey, ex];
        ANode cur = null;

        OpenList.Add(startNode);

        while (OpenList.Count > 0) //openList에 아무것도 없으면 탈출
        {
            cur = getNodeInOpenList(); //가중치 낮은 노드 꺼내옴
            if (cur == endNode)
            {
                do
                {
                    Path.Add(cur);
                } while ((cur = cur.parent) != null);
                for (int i = Path.Count - 1; i >= 0; --i)
                {
                    Console.WriteLine($"지점(y,x) : {Path[i].ypos}, {Path[i].xpos}");
                }
                break;
            } //도착지면 탈출
            ClosedList.Add(cur); //방문기록
            sy = cur.ypos; sx = cur.xpos;

            ANode target = null;
            int gscore = 0;
            for (int y = -1; y <= 1; ++y)
            {
                for (int x = -1; x <= 1; ++x)
                {
                    if (sy + y < 0 || sy + y >= map_height || sx + x < 0 || sx + x >= map_width) continue; //배열범위체크
                    target = myMaps[sy + y, sx + x];
                    if (target.IsBlock) continue; //장애물체크
                    if (ClosedList.Contains(target)) continue;//방문여부체크

                    if (Math.Abs(y) + Math.Abs(x) == 2) gscore = 14;
                    else gscore = 10;

                    if (OpenList.Contains(target))//갈수 있는 셀이면 업데이트여부 체크
                    {
                        if (target.Gscore > myMaps[sy, sx].Gscore + gscore) //새로 계산한 값이 더 작으면 업데이트
                        {
                            target.Gscore = myMaps[sy, sx].Gscore + gscore;
                            target.parent = myMaps[sy, sx];
                        }
                    }
                    else
                    {
                        target.Gscore = myMaps[sy, sx].Gscore + gscore;
                        target.Hscore = Math.Abs(ey - target.ypos) + Math.Abs(ex - target.xpos);
                        target.parent = myMaps[sy, sx];
                        OpenList.Add(target);
                    }
                }
            }
        }
    }
    */
}
