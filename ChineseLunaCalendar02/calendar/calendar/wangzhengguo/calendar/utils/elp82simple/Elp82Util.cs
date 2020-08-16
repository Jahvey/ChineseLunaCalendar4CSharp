
using System;
using static MathUtil;
using static CalendarUtil;
using static Iau2000BUtil;

public class Elp82Util {

    /**
     * L' = 218.3164477 + 481267.88123421 * t - 0.0015786 * t² + t³ / 538841 - t⁴ / 6519400
     * 
     * @param t
     *            儒略世纪数
     * @return L'的值(rad)
     */
    private static double getLp(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        double t4 = t3 * t;
        return mod2Pi(toRadians(218.3164477 + 481267.88123421 * t - 0.0015786 * t2 + t3 / 538841
                - t4 / 6519400));
    }

    /**
     * D = 297.8501921 + 445267.1114034 * t - 0.0018819 * t² + t³ / 545868 - t⁴ / 113065000
     * 
     * @param t
     *            儒略世纪数
     * @return D的值(rad)
     */
    private static double getD(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        double t4 = t3 * t;
        return mod2Pi(toRadians(297.8501921 + 445267.1114034 * t - 0.0018819 * t2 + t3 / 545868
                - t4 / 113065000));
    }

    /**
     * M = 357.5291092 + 35999.0502909 * t - 0.0001536 * t² + t³ / 24490000
     * 
     * @param t
     *            儒略世纪数
     * @return M的值(rad)
     */
    private static double getM(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        return mod2Pi(toRadians(357.5291092 + 35999.0502909 * t - 0.0001536 * t2 + t3 / 24490000));
    }

    /**
     * M' = 134.9633964 + 477198.8675055 * t + 0.0087414 * t² + t³ / 69699 - t⁴ / 14712000
     * 
     * @param t
     *            儒略世纪数
     * @return M'的值(rad)
     */
    private static double getMp(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        double t4 = t3 * t;
        return mod2Pi(toRadians(134.9633964 + 477198.8675055 * t + 0.0087414 * t2 + t3 / 69699 - t4
                / 14712000));
    }

    /**
     * F = 93.2720950 + 483202.0175233 * t - 0.0036539 * t² - t³ / 3526000 + t⁴ / 863310000
     * 
     * @param t
     *            儒略世纪数
     * @return F的值(rad)
     */
    private static double getF(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        double t4 = t3 * t;
        return mod2Pi(toRadians(93.2720950 + 483202.0175233 * t - 0.0036539 * t2 - t3 / 3526000
                + t4 / 863310000));
    }

    /**
     * A1 = 119.75 + 131.849 * t
     * 
     * @param t
     *            儒略世纪数
     * @return A1的值(rad)
     */
    private static double getA1(double t) {
        return mod2Pi(toRadians(119.75 + 131.849 * t));
    }

    /**
     * A2 = 53.09 + 479264.290 * t
     * 
     * @param t
     *            儒略世纪数
     * @return A2的值(rad)
     */
    private static double getA2(double t) {
        return mod2Pi(toRadians(53.09 + 479264.290 * t));
    }

    /**
     * E = 1 - 0.002516 * t - 0.0000074 * t²
     * 
     * @param t
     *            儒略世纪数
     * @return E的值
     */
    private static double getE(double t) {
        double t2 = t * t;
        return 1 - 0.002516 * t - 0.0000074 * t2;
    }

    private static double getSumL(double t) {
        double d = getD(t);
        double m = getM(t);
        double mp = getMp(t);
        double f = getF(t);
        double lp = getLp(t);
        double e = getE(t);
        double e2 = e * e;

        double a1 = getA1(t);
        double a2 = getA2(t);
        double sumL = 0.0;

        sumL += 6288774 * Math.Sin(mp);
        sumL += 1274027 * Math.Sin(2 * d - mp);
        sumL += 658314 * Math.Sin(2 * d);
        sumL += 213618 * Math.Sin(2 * mp);
        sumL += -185116 * e * Math.Sin(m);
        sumL += -114332 * Math.Sin(2 * f);
        sumL += 58793 * Math.Sin(2 * d - 2 * mp);
        sumL += 57066 * e * Math.Sin(2 * d - m - mp);
        sumL += 53322 * Math.Sin(2 * d + mp);
        sumL += 45758 * e * Math.Sin(2 * d - m);
        sumL += -40923 * e * Math.Sin(m - mp);
        sumL += -34720 * Math.Sin(d);
        sumL += -30383 * e * Math.Sin(m + mp);
        sumL += 15327 * Math.Sin(2 * d - 2 * f);
        sumL += -12528 * Math.Sin(mp + 2 * f);
        sumL += 10980 * Math.Sin(mp - 2 * f);
        sumL += 10675 * Math.Sin(4 * d - mp);
        sumL += 10034 * Math.Sin(3 * mp);
        sumL += 8548 * Math.Sin(4 * d - 2 * mp);
        sumL += -7888 * e * Math.Sin(2 * d + m - mp);
        sumL += -6766 * e * Math.Sin(2 * d + m);
        sumL += -5163 * Math.Sin(d - mp);
        sumL += 4987 * e * Math.Sin(d + m);
        sumL += 4036 * e * Math.Sin(2 * d - m + mp);
        sumL += 3994 * Math.Sin(2 * d + 2 * mp);
        sumL += 3861 * Math.Sin(4 * d);
        sumL += 3665 * Math.Sin(2 * d - 3 * mp);
        sumL += -2689 * e * Math.Sin(m - 2 * mp);
        sumL += -2602 * Math.Sin(2 * d - mp + 2 * f);
        sumL += 2390 * e * Math.Sin(2 * d - m - 2 * mp);
        sumL += -2348 * Math.Sin(d + mp);
        sumL += 2236 * e2 * Math.Sin(2 * d - 2 * m);
        sumL += -2120 * e * Math.Sin(m + 2 * mp);
        sumL += -2069 * e2 * Math.Sin(2 * m);
        sumL += 2048 * e2 * Math.Sin(2 * d - 2 * m - mp);
        sumL += -1773 * Math.Sin(2 * d + mp - 2 * f);
        sumL += -1595 * Math.Sin(2 * d + 2 * f);
        sumL += 1215 * e * Math.Sin(4 * d - m - mp);
        sumL += -1110 * Math.Sin(2 * mp + 2 * f);
        sumL += -892 * Math.Sin(3 * d - mp);
        sumL += -810 * e * Math.Sin(2 * d + m + mp);
        sumL += 759 * e * Math.Sin(4 * d - m - 2 * mp);
        sumL += -713 * e2 * Math.Sin(2 * m - mp);
        sumL += -700 * e2 * Math.Sin(2 * d + 2 * m - mp);
        sumL += 691 * e * Math.Sin(2 * d + m - 2 * mp);
        sumL += 596 * e * Math.Sin(2 * d - m - 2 * f);
        sumL += 549 * Math.Sin(4 * d + mp);
        sumL += 537 * Math.Sin(4 * mp);
        sumL += 520 * e * Math.Sin(4 * d - m);
        sumL += -487 * Math.Sin(d - 2 * mp);
        sumL += -399 * e * Math.Sin(2 * d + m - 2 * f);
        sumL += -381 * Math.Sin(2 * mp - 2 * f);
        sumL += 351 * e * Math.Sin(d + m + mp);
        sumL += -340 * Math.Sin(3 * d - 2 * mp);
        sumL += 330 * Math.Sin(4 * d - 3 * mp);
        sumL += 327 * e * Math.Sin(2 * d - m + 2 * mp);
        sumL += -323 * e2 * Math.Sin(2 * m + mp);
        sumL += 299 * e * Math.Sin(d + m - mp);
        sumL += 294 * Math.Sin(2 * d + 3 * mp);

        sumL += 3958 * Math.Sin(a1) + 1962 * Math.Sin(lp - f) + 318 * Math.Sin(a2);

        return sumL;
    }

    /**
     * 按儒略日计算月球的地心黄经
     * 
     * @param jd
     *            儒略日
     * @return 月球的地心黄经，单位是弧度(rad)
     */
    public static double getEarthEclipticLongitudeForMoon(double jd) {
        double t = getJulianCentury(jd);
        return getLp(t) + toRadians(getSumL(t) / 1000000) + getLongitudeNutation(jd);
    }

    public static void Main(String[] args) {
        Console.WriteLine(toDegrees(getEarthEclipticLongitudeForMoon(2448724.5)));
    }
}
