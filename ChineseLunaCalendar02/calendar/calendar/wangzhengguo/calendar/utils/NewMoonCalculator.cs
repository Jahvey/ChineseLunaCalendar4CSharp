using System;
using static MathUtil;
using static CalendarUtil;
using System.Collections;
using System.Globalization;
using static Vsop87dEarthUtil;
using static ElpMpp02Util;
/**
 * 使用牛顿迭代法计算日月合朔的时间 求解的方程为: <br />
 * <i>f(x) = Vsop87dEarthUtil.getEarthEclipticLongitudeForSun(x) -
 * ElpMpp02Util.getEarthEclipticLongitudeForMoon(x) = 0</i>
 * 
 * @author wangzhenguo 
 */
public class NewMoonCalculator {

   // private delegate double func(double x);


    /**
     * 用牛顿迭代计算日月合朔时间
     * 
     * @param term
     *            节气
     * @param year
     *            年份
     * @return 节气时间的儒略日
     */
    public static ArrayList getJulianDayInYearAndMonthForNewMoon(int year, int month) {
        ArrayList jds = new ArrayList();
        double lastJd = 0.0d;
        for (int i = 0; i < 2; i++)
        {
            double jd1 = toJulianDate(year, month, 10 * (i + 1));
            Func<double,double> f = (x) => {
                return modPi(getEarthEclipticLongitudeForSun(x) - getEarthEclipticLongitudeForMoon(x));
            } ;
            double jd = newtonIteration(f, jd1);
            DateTime cal = fromJulianDate(jd);
            if (cal.Month == month && (jd - lastJd > 1e-7))
            {
                jds.Add(jd);
                lastJd = jd;
            }
         }
        return jds;
    }

    public static void Main(string[] args) {
        for (int month = 1; month <= 12; month++) {
            ArrayList jds = getJulianDayInYearAndMonthForNewMoon(2020, month);

            foreach (double jd in jds)
            {
                DateTime cal = fromJulianDate(jd);
                Console.WriteLine (String.Format("%04d-%02d-%02d %02d:%02d:%02d.%03d",
                        cal.Year, cal.Month + 1, cal.Day,
                        cal.Hour, cal.Minute,
                        cal.Second, cal.Millisecond));
            }
        }
    }

}
