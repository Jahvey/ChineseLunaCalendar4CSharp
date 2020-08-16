
using System;
using System.Collections;
using static CalendarUtil;
using static MathUtil;
using static Vsop87dEarthUtil;

/**
 * 使用牛顿迭代法计算24节气的时间 求解的方程为: <br />
 * <i>f(x) = Vsop87dEarthUtil.getEarthEclipticLongitudeForSun(x) - angle = 0</i>
 * 
 * @author wangzhenguo
 */
public class SolarTermsCalculator {

    private static readonly double RADIANS_PER_TERM = Math.PI / 12;

   // private delegate double func(double x);

    /**
     * 用牛顿迭代计算节气时间
     * 
     * @param term
     *            节气
     * @param year
     *            年份
     * @return 节气时间的儒略日
     */
    public static double getJulianDayInYearForTermOrder(SolarVo term, int year) {
        int order = term.Order;
        double angle = (order - 1) * RADIANS_PER_TERM;
        int month = term.Month;
        int estimateDate = term.EstimateDate;
        double jd1 = toJulianDate(year, month, estimateDate);
        Func<double,double> f = (x) => modPi(getEarthEclipticLongitudeForSun(x) - angle);
        double jd = newtonIteration(f, jd1);
        return jd;
    }

    public static void main(String[] args) {
        SolarTerms solarTerms = new SolarTerms();
        ArrayList list = solarTerms.listArr;
        foreach (SolarVo term in list) {
            double jd = getJulianDayInYearForTermOrder(term, 2020);
            jd -= CalendarUtil.getDeltaT(jd) / 86400; // 由TT转换成UTC
            DateTime cal = fromJulianDate(jd + 8.0 / 24.0); // 东8区
            Console.WriteLine (term.Name+ ": " +
                String.Format("%04d-%02d-%02d %02d:%02d:%02d.%03d", cal.Year,
                            cal.Month + 1, cal.Date,
                            cal.Hour, cal.Minute,
                            cal.Second, cal.Millisecond));
        }
    }

}
