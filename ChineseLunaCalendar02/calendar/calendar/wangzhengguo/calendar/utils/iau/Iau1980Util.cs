using System;
using static MathUtil;
using static CalendarUtil;


/**
 * 根据IAU 1980的数据计算章动
 * 
 * @author wangzhenguo
 */
public class Iau1980Util {

    /**
     * 计算黄经章动
     * 
     * @param jd
     *            儒略日
     * @return 章动的值(rad)
     */
    public static double getLongitudeNutation(double jd) {
        double t = getJulianCentury(jd);
        double el = getEl(t);
        double elp = getElp(t);
        double f = getF(t);
        double d = getD(t);
        double om = getOm(t);
        return getLongitudeNutation(t, el, elp, f, d, om);

    }

    private static double getLongitudeNutation(double t, double el, double elp, double f, double d,
            double om) {
        double n = 0.0;

        n += Math.Sin(om) * (-174.2 * t - 171996);
        n += Math.Sin(2 * (f + om - d)) * (-1.6 * t - 13187);
        n += Math.Sin(2 * (f + om)) * (-2274 - 0.2 * t);
        n += Math.Sin(2 * om) * (0.2 * t + 2062);
        n += Math.Sin(elp) * (1426 - 3.4 * t);
        n += Math.Sin(el) * (0.1 * t + 712);
        n += Math.Sin(2 * (f + om - d) + elp) * (1.2 * t - 517);
        n += Math.Sin(2 * f + om) * (-0.4 * t - 386);
        n -= 301 * Math.Sin(2 * (f + om) + el);
        n += Math.Sin(2 * (f + om - d) - elp) * (217 - 0.5 * t);
        n -= 158 * Math.Sin(el - 2 * d);
        n += Math.Sin(2 * (f - d) + om) * (129 + 0.1 * t);
        n += 123 * Math.Sin(2 * (f + om) - el);
        n += 63 * Math.Sin(2 * d);
        n += Math.Sin(el + om) * (0.1 * t + 63);
        n -= 59 * Math.Sin(2 * (d + f + om) - el);
        n += Math.Sin(om - el) * (-0.1 * t - 58);
        n -= 51 * Math.Sin(2 * f + el + om);
        n += 48 * Math.Sin(2 * (el - d));
        n += 46 * Math.Sin(2 * (f - el) + om);
        n -= 38 * Math.Sin(2 * (d + f + om));
        n -= 31 * Math.Sin(2 * (el + f + om));
        n += 29 * Math.Sin(2 * el);
        n += 29 * Math.Sin(2 * (f + om - d) + el);
        n += 26 * Math.Sin(2 * f);
        n -= 22 * Math.Sin(2 * (f - d));
        n += 21 * Math.Sin(2 * f + om - el);
        n += Math.Sin(2 * elp) * (17 - 0.1 * t);
        n += 16 * Math.Sin(2 * d - el + om);
        n += Math.Sin(2 * (elp + f + om - d)) * (0.1 * t - 16);
        n -= 15 * Math.Sin(elp + om);
        n -= 13 * Math.Sin(el + om - 2 * d);
        n -= 12 * Math.Sin(om - elp);
        n += 11 * Math.Sin(2 * (el - f));
        n -= 10 * Math.Sin(2 * (f + d) + om - el);
        n -= 8 * Math.Sin(2 * (f + d + om) + el);
        n += 7 * Math.Sin(2 * (f + om) + elp);
        n -= 7 * Math.Sin(el - 2 * d + elp);
        n -= 7 * Math.Sin(2 * (f + om) - elp);
        n -= 7 * Math.Sin(2 * d + 2 * f + om);
        n += 6 * Math.Sin(2 * d + el);
        n += 6 * Math.Sin(2 * (el + f + om - d));
        n += 6 * Math.Sin(2 * (f - d) + el + om);
        n -= 6 * Math.Sin(2 * (d - el) + om);
        n -= 6 * Math.Sin(2 * d + om);
        n += 5 * Math.Sin(el - elp);
        n -= 5 * Math.Sin(2 * (f - d) + om - elp);
        n -= 5 * Math.Sin(om - 2 * d);
        n -= 5 * Math.Sin(2 * (el + f) + om);
        n += 4 * Math.Sin(2 * (el - d) + om);
        n += 4 * Math.Sin(2 * (f - d) + elp + om);
        n += 4 * Math.Sin(el - 2 * f);
        n -= 4 * Math.Sin(el - d);
        n -= 4 * Math.Sin(elp - 2 * d);
        n -= 4 * Math.Sin(d);
        n += 3 * Math.Sin(2 * f + el);
        n -= 3 * Math.Sin(2 * (f + om - el));
        n -= 3 * Math.Sin(el - d - elp);
        n -= 3 * Math.Sin(elp + el);
        n -= 3 * Math.Sin(2 * (f + om) + el - elp);
        n -= 3 * Math.Sin(2 * (d + f + om) - elp - el);
        n -= 3 * Math.Sin(2 * (f + om) + 3 * el);
        n -= 3 * Math.Sin(2 * (d + f + om) - elp);

        n /= 36000000.0d;
        return toRadians(n);
    }

    private static double getEl(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        return toRadians(134.96298 + 477198.867398 * t + 0.0086972 * t2 + (t3 / 56250));
    }

    private static double getElp(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        return toRadians(357.52772 + 35999.05034 * t - 0.0001603 * t2 - (t3 / 300000));
    }

    private static double getF(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        return toRadians(93.27191 + 483202.017538 * t - 0.0036825 * t2 + (t3 / 327270));
    }

    private static double getD(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        return toRadians(297.85036 + 445267.11148 * t - 0.0019142 * t2 + (t3 / 189474));
    }

    private static double getOm(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        return toRadians(125.04452 - 1934.136261 * t + 0.0020708 * t2 + (t3 / 450000));
    }

	
    public static void Main(string[] args) {
        double jd = CalendarUtil.toJulianDate(2014, 5, 5, 5, 5, 5);
        double t = getJulianCentury(jd);
        double ln = getLongitudeNutation(jd);
        Console.WriteLine(jd);
        Console.WriteLine(t);
        Console.WriteLine(toDegrees(ln));
        Console.WriteLine(toDegrees(ln) * 3600);
    }
}
