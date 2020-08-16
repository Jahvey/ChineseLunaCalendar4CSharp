using System;
using System.Collections;
using System.ComponentModel;

public class SolarTerms {
    public  ArrayList listArr=new ArrayList();
    //[Description(new SolarVo(20, "小寒", 1, 5) + "")]
   public  SolarVo XIAO_HAN = new SolarVo(20, "小寒", 1, 5);
    public  SolarVo DA_HAN = new SolarVo(21, "大寒", 1, 22);
    public  SolarVo LI_CHUN = new SolarVo(22, "立春", 2, 5);
    public  SolarVo YU_SHUI = new SolarVo(23, "雨水", 2, 22);
    public  SolarVo JING_ZHE = new SolarVo(24, "惊蛰", 3, 5);
    public  SolarVo CHUN_FEN = new SolarVo(1, "春分", 3, 22);
    public  SolarVo QING_MING = new SolarVo(2, "清明", 4, 5);
    public  SolarVo GU_YU = new SolarVo(3, "谷雨", 4, 22);
    public  SolarVo LI_XIA = new SolarVo(4, "立夏", 5, 5);
    public  SolarVo XIAO_MAN = new SolarVo(5, "小满", 5, 22);
    public  SolarVo MANG_ZHONG = new SolarVo(6, "芒种", 6, 5);
    public  SolarVo XIA_ZHI = new SolarVo(7, "夏至", 6, 22);
    public  SolarVo XIAO_SHU = new SolarVo(8, "小暑", 7, 5);
    public  SolarVo DA_SHU = new SolarVo(9, "大暑", 7, 22);
    public  SolarVo LI_QIU = new SolarVo(10, "立秋", 8, 5);
    public  SolarVo CHU_SHU = new SolarVo(11, "处暑", 8, 22);
    public  SolarVo BAI_LU = new SolarVo(12, "白露", 9, 5);
    public  SolarVo QIU_FEN = new SolarVo(13, "秋分", 9, 22);
    public  SolarVo HAN_LU = new SolarVo(14, "寒露", 10, 5);
    public  SolarVo SHUANG_JIANG = new SolarVo(15, "霜降", 10, 22);
    public  SolarVo LI_DONG = new SolarVo(16, "立冬", 11, 5);
    public  SolarVo XIAO_XUE = new SolarVo(17, "小雪", 11, 22);
    public  SolarVo DA_XUE = new SolarVo(18, "大雪", 12, 5);
    public  SolarVo DONG_ZHI = new SolarVo(19, "冬至", 12, 22);
    public SolarTerms() {

        listArr.Add(XIAO_HAN);
        listArr.Add(DA_HAN);
        listArr.Add(LI_CHUN);
        listArr.Add(YU_SHUI);
        listArr.Add(JING_ZHE);
        listArr.Add(CHUN_FEN);
        listArr.Add(QING_MING);
        listArr.Add(GU_YU);
        listArr.Add(LI_XIA);
        listArr.Add(XIAO_MAN);
        listArr.Add(MANG_ZHONG);
        listArr.Add(XIA_ZHI);
        listArr.Add(XIAO_SHU);
        listArr.Add(DA_SHU);
        listArr.Add(LI_QIU);
        listArr.Add(CHU_SHU);
        listArr.Add(BAI_LU);
        listArr.Add(QIU_FEN);
        listArr.Add(HAN_LU);
        listArr.Add(SHUANG_JIANG);
        listArr.Add(LI_DONG);
        listArr.Add(XIAO_XUE);
        listArr.Add(DA_XUE);
        listArr.Add(DONG_ZHI);


    }


}


public class SolarVo {
    private int order;
    private String name;
    private int month;
    private int estimateDate;
    private int index;

    public SolarVo(int order, String name, int month, int estimateDate)
    {
        this.Order = order;
        this.Name = name;
        this.Month = month;
        this.EstimateDate = estimateDate;
    }
    public override string ToString()
    {
        return "order="+this.order+",name="+this.name+",month="+this.month+",estimateDate="+this.estimateDate;
    }
    public int Order
    {
        get
        {
            return order;
        }

        set
        {
            order = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public int Month
    {
        get
        {
            return month;
        }

        set
        {
            month = value;
        }
    }

    public int EstimateDate
    {
        get
        {
            return estimateDate;
        }

        set
        {
            estimateDate = value;
        }
    }

    public int Index
    {
        get
        {
            return index;
        }

        set
        {
            index = value;
        }
    }




}
