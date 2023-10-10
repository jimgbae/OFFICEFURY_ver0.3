using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE //������ Ÿ��
{
    TYPE_ACTIVE = 1,
    TYPE_PASSIVE
};

public enum RATING //������ ������
{
    RATING_BRONZE = 1,
    RATING_SILVER,
    RATING_GOLD,
    RATING_ACTIVE
};

/*BaseItem�� ��� �������� ������ �ִ� ����� �����Դϴ�.
BaseItem�� �θ�� ��� �߰��Ǵ� ������ ���� ������ �ξ����ϴ�.
��� �����۵��� ScriptableObject������� ���������
�� �����۸��� ���� ������ �ֱ⿡ �������� �ϱ� ���Ұ̴ϴ�.*/
public class BaseItem : ScriptableObject
{
    public TYPE ItemType;
    public RATING ItemRating;
    public int ItemCode;
    public string ItemName;
    public string ItemExplan;
    public int ItemPrice;
}


