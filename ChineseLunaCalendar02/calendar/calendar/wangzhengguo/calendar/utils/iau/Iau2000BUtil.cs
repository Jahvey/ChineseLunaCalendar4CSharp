
using System;
using static MathUtil;
using static CalendarUtil;



/**
 * 根据IAU 2000B的数据计算章动
 * 
 * @author wangzhenguo
 */
public class Iau2000BUtil {

    private static double getLongitudeNutation(double t, double l, double lp, double f, double d,
            double om) {
        double n = 0.0;
        n = n + (-172064161 - 174666 * t) * Math.Sin(om) + 33386 * Math.Cos(om);
        n = n + (-13170906 - 1675 * t) * Math.Sin(2 * (f - d + om)) - 13696 * Math.Cos(2 * (f - d + om));
        n = n + (-2276413 - 234 * t) * Math.Sin(2 * (f + om)) + 2796 * Math.Cos(2 * (f + om));
        n = n + (2074554 + 207 * t) * Math.Sin(2 * om) - 698 * Math.Cos(2 * om);
        n = n + (1475877 - 3633 * t) * Math.Sin(lp) + 11817 * Math.Cos(lp);
        n = n + (-516821 + 1226 * t) * Math.Sin(lp + 2 * (f - d + om)) - 524
                * Math.Cos(lp + 2 * (f - d + om));
        n = n + (711159 + 73 * t) * Math.Sin(l) - 872 * Math.Cos(l);
        n = n + (-387298 - 367 * t) * Math.Sin(2 * f + om) + 380 * Math.Cos(2 * f + om);
        n = n + (-301461 - 36 * t) * Math.Sin(l + 2 * (f + om)) + 816 * Math.Cos(l + 2 * (f + om));
        n = n + (215829 - 494 * t) * Math.Sin(2 * (f - d + om) - lp) + 111 * Math.Cos(2 * (f - d + om) - lp);
        n = n + (128227 + 137 * t) * Math.Sin(2 * (f - d) + om) + 181 * Math.Cos(2 * (f - d) + om);
        n = n + (123457 + 11 * t) * Math.Sin(2 * (f + om) - l) + 19 * Math.Cos(2 * (f + om) - l);
        n = n + (156994 + 10 * t) * Math.Sin(2 * d - l) - 168 * Math.Cos(2 * d - l);
        n = n + (63110 + 63 * t) * Math.Sin(l + om) + 27 * Math.Cos(l + om);
        n = n + (-57976 - 63 * t) * Math.Sin(om - l) - 189 * Math.Cos(om - l);
        n = n + (-59641 - 11 * t) * Math.Sin(2 * (f + d + om) - l) + 149 * Math.Cos(2 * (f + d + om) - l);
        n = n + (-51613 - 42 * t) * Math.Sin(l + 2 * f + om) + 129 * Math.Cos(l + 2 * f + om);
        n = n + (45893 + 50 * t) * Math.Sin(2 * (f - l) + om) + 31 * Math.Cos(2 * (f - l) + om);
        n = n + (63384 + 11 * t) * Math.Sin(2 * d) - 150 * Math.Cos(2 * d);
        n = n + (-38571 - t) * Math.Sin(2 * (f + d + om)) + 158 * Math.Cos(2 * (f + d + om));
        n = n + 32481 * Math.Sin(2 * (f - lp - d + om));
        n = n - 47722 * Math.Sin(2 * (d - l)) + 18 * Math.Cos(2 * (d - l));
        n = n + (-31046 - t) * Math.Sin(2 * (l + f + om)) + 131 * Math.Cos(2 * (l + f + om));
        n = n + 28593 * Math.Sin(l + 2 * (f - d + om)) - Math.Cos(l + 2 * (f - d + om));
        n = n + (20441 + 21 * t) * Math.Sin(2 * f + om - l) + 10 * Math.Cos(2 * f + om - l);
        n = n + 29243 * Math.Sin(2 * l) - 74 * Math.Cos(2 * l);
        n = n + 25887 * Math.Sin(2 * f) - 66 * Math.Cos(2 * f);
        n = n + (-14053 - 25 * t) * Math.Sin(lp + om) + 79 * Math.Cos(lp + om);
        n = n + (15164 + 10 * t) * Math.Sin(-l + 2 * d + om) + 11 * Math.Cos(-l + 2 * d + om);
        n = n + (-15794 + 72 * t) * Math.Sin(2 * (lp + f - d + om)) - 16 * Math.Cos(2 * (lp + f - d + om));
        n = n + 21783 * Math.Sin(2 * (d - f)) + 13 * Math.Cos(2 * (d - f));
        n = n + (-12873 - 10 * t) * Math.Sin(l - 2 * d + om) - 37 * Math.Cos(l - 2 * d + om);
        n = n + (-12654 + 11 * t) * Math.Sin(-lp + om) + 63 * Math.Cos(-lp + om);
        n = n - 10204 * Math.Sin(2 * (f + d) + om - l) - 25 * Math.Cos(2 * (f + d) + om - l);
        n = n + (16707 - 85 * t) * Math.Sin(2 * lp) - 10 * Math.Cos(2 * lp);
        n = n - 7691 * Math.Sin(l + 2 * (f + d + om)) - 44 * Math.Cos(l + 2 * (f + d + om));
        n = n - 11024 * Math.Sin(2 * (f - l)) + 14 * Math.Cos(2 * (f - l));
        n = n + (7566 - 21 * t) * Math.Sin(lp + 2 * (f + om)) - 11 * Math.Cos(lp + 2 * (f + om));
        n = n + (-6637 - 11 * t) * Math.Sin(2 * (f + d) + om) + 25 * Math.Cos(2 * (f + d) + om);
        n = n + (-7141 + 21 * t) * Math.Sin(2 * (f + om) - lp) + 8 * Math.Cos(2 * (f + om) - lp);
        n = n + (-6302 - 11 * t) * Math.Sin(2 * d + om) + 2 * Math.Cos(2 * d + om);
        n = n + (5800 + 10 * t) * Math.Sin(l + 2 * (f - d) + om) + 2 * Math.Cos(l + 2 * (f - d) + om);
        n = n + 6443 * Math.Sin(2 * (l + f - d + om)) - 7 * Math.Cos(2 * (l + f - d + om));
        n = n + (-5774 - 11 * t) * Math.Sin(2 * (d - l) + om) - 15 * Math.Cos(2 * (d - l) + om);
        n = n - 5350 * Math.Sin(2 * (l + f) + om) - 21 * Math.Cos(2 * (l + f) + om);
        n = n + (-4752 - 11 * t) * Math.Sin(2 * (f - d) + om - lp) - 3 * Math.Cos(2 * (f - d) + om - lp);
        n = n + (-4940 - 11 * t) * Math.Sin(om - 2 * d) - 21 * Math.Cos(om - 2 * d);
        n = n + 7350 * Math.Sin(2 * d - l - lp) - 8 * Math.Cos(2 * d - l - lp);
        n = n + 4065 * Math.Sin(2 * (l - d) + om) + 6 * Math.Cos(2 * (l - d) + om);
        n = n + 6579 * Math.Sin(l + 2 * d) - 24 * Math.Cos(l + 2 * d);
        n = n + 3579 * Math.Sin(lp + 2 * (f - d) + om) + 5 * Math.Cos(lp + 2 * (f - d) + om);
        n = n + 4725 * Math.Sin(l - lp) - 6 * Math.Cos(l - lp);
        n = n - 3075 * Math.Sin(2 * (f + om - l)) + 2 * Math.Cos(2 * (f + om - l));
        n = n - 2904 * Math.Sin(3 * l + 2 * (f + om)) - 15 * Math.Cos(3 * l + 2 * (f + om));
        n = n + 4348 * Math.Sin(2 * d - lp) - 10 * Math.Cos(2 * d - lp);
        n = n - 2878 * Math.Sin(l - lp + 2 * (f + om)) - 8 * Math.Cos(l - lp + 2 * (f + om));
        n = n - 4230 * Math.Sin(d) - 5 * Math.Cos(d);
        n = n - 2819 * Math.Sin(2 * (f + d + om) - l - lp) - 7 * Math.Cos(2 * (f + d + om) - l - lp);
        n = n - 4056 * Math.Sin(2 * f - l) - 5 * Math.Cos(2 * f - l);
        n = n - 2647 * Math.Sin(2 * (f + d + om) - lp) - 11 * Math.Cos(2 * (f + d + om) - lp);
        n = n - 2294 * Math.Sin(om - 2 * l) + 10 * Math.Cos(om - 2 * l);
        n = n + 2481 * Math.Sin(l + lp + 2 * (f + om)) - 7 * Math.Cos(l + lp + 2 * (f + om));
        n = n + 2179 * Math.Sin(2 * l + om) - 2 * Math.Cos(2 * l + om);
        n = n + 3276 * Math.Sin(lp + d - l) + Math.Cos(lp + d - l);
        n = n - 3389 * Math.Sin(l + lp) - 5 * Math.Cos(l + lp);
        n = n + 3339 * Math.Sin(l + 2 * f) - 13 * Math.Cos(l + 2 * f);
        n = n - 1987 * Math.Sin(2 * (f - d) + om - l) + 6 * Math.Cos(2 * (f - d) + om - l);
        n = n - 1981 * Math.Sin(l + 2 * om);
        n = n + 4026 * Math.Sin(d - l) - 353 * Math.Cos(d - l);
        n = n + 1660 * Math.Sin(2 * f + d + 2 * om) - 5 * Math.Cos(d + 2 * (f + om));
        n = n - 1521 * Math.Sin(2 * (f + 2 * d + om) - l) - 9 * Math.Cos(2 * (f + 2 * d + om) - l);
        n = n + 1314 * Math.Sin(lp + d + om - l);
        n = n - 1283 * Math.Sin(2 * (f - d - lp) + om);
        n = n - 1331 * Math.Sin(l + 2 * f + 2 * d + om) - 8 * Math.Cos(l + 2 * (f + d) + om);
        n = n + 1383 * Math.Sin(2 * (f - l + d + om)) - 2 * Math.Cos(2 * (f - l + d + om));
        n = n + 1405 * Math.Sin(2 * om - l) + 4 * Math.Cos(2 * om - l);
        n = n + 1290 * Math.Sin(l + lp + 2 * (f - d + om));
        n /= 36000000000.0d;
        return toRadians(n);
    }

    private static double getObliquityNutation(double t, double l, double lp, double f, double d,
            double om) {
        double n = 0.0;
        n = n + (92052331 + 9086 * t) * Math.Cos(om) + 15377 * Math.Sin(om);
        n = n + (5730336 - 3015 * t) * Math.Cos(2 * (f - d + om)) - 4587 * Math.Sin(2 * (f - d + om));
        n = n + (978459 - 485 * t) * Math.Cos(2 * (f + om)) + 1374 * Math.Sin(2 * (f + om));
        n = n + (-897492 + 470 * t) * Math.Cos(2 * om) - 291 * Math.Sin(2 * om);
        n = n + (73871 - 184 * t) * Math.Cos(lp) - 1924 * Math.Sin(lp);
        n = n + (224386 - 677 * t) * Math.Cos(lp + 2 * (f - d + om)) - 174 * Math.Sin(lp + 2 * (f - d + om));
        n = n - 6750 * Math.Cos(l) - 358 * Math.Sin(l);
        n = n + (200728 + 18 * t) * Math.Cos(2 * f + om) + 318 * Math.Sin(2 * f + om);
        n = n + (129025 - 63 * t) * Math.Cos(l + 2 * (f + om)) + 367 * Math.Sin(l + 2 * (f + om));
        n = n + (-95929 + 299 * t) * Math.Cos(2 * (f - d + om) - lp) + 132 * Math.Sin(2 * (f - d + om) - lp);
        n = n + (-68982 - 9 * t) * Math.Cos(2 * (f - d) + om) + 39 * Math.Sin(2 * (f - d) + om);
        n = n + (-53311 + 32 * t) * Math.Cos(2 * (f + om) - l) - 4 * Math.Sin(2 * (f + om) - l);
        n = n - 1235 * Math.Cos(2 * d - l) - 82 * Math.Sin(2 * d - l);
        n = n - 33228 * Math.Cos(l + om) + 9 * Math.Sin(l + om);
        n = n + 31429 * Math.Cos(om - l) - 75 * Math.Sin(om - l);
        n = n + (25543 - 11 * t) * Math.Cos(2 * (f + d + om) - l) + 66 * Math.Sin(2 * (f + d + om) - l);
        n = n + 26366 * Math.Cos(l + 2 * f + om) + 78 * Math.Sin(l + 2 * f + om);
        n = n + (-24236 - 10 * t) * Math.Cos(2 * (f - l) + om) + 20 * Math.Sin(2 * (f - l) + om);
        n = n - 1220 * Math.Cos(2 * d) - 29 * Math.Sin(2 * d);
        n = n + (16452 - 11 * t) * Math.Cos(2 * (f + d + om)) + 68 * Math.Sin(2 * (f + d + om));
        n = n - 13870 * Math.Cos(2 * (f - lp - d + om));
        n = n + 477 * Math.Cos(2 * (d - l)) - 25 * Math.Sin(2 * (d - l));
        n = n + (13238 - 11 * t) * Math.Cos(2 * (l + f + om)) + 59 * Math.Sin(2 * (l + f + om));
        n = n + (-12338 + 10 * t) * Math.Cos(l + 2 * (f - d + om)) - 3 * Math.Sin(l + 2 * (f - d + om));
        n = n - 10758 * Math.Cos(2 * f + om - l) + 3 * Math.Sin(2 * f + om - l);
        n = n - 609 * Math.Cos(2 * l) - 13 * Math.Sin(2 * l);
        n = n - 550 * Math.Cos(2 * f) - 11 * Math.Sin(2 * f);
        n = n + (8551 - 2 * t) * Math.Cos(lp + om) - 45 * Math.Sin(lp + om);
        n = n - 8001 * Math.Cos(2 * d - l + om) + Math.Sin(2 * d - l + om);
        n = n + (6850 - 42 * t) * Math.Cos(2 * (lp + f - d + om)) - 5 * Math.Sin(2 * (lp + f - d + om));
        n = n - 167 * Math.Cos(2 * (d - f)) - 13 * Math.Sin(2 * (d - f));
        n = n + 6953 * Math.Cos(l - 2 * d + om) - 14 * Math.Sin(l - 2 * d + om);
        n = n + 6415 * Math.Cos(om - lp) + 26 * Math.Sin(om - lp);
        n = n + 5222 * Math.Cos(2 * (f + d) + om - l) + 15 * Math.Sin(2 * (f + d) + om - l);
        n = n + (168 - t) * Math.Cos(2 * lp) + 10 * Math.Sin(2 * lp);
        n = n + 3268 * Math.Cos(l + 2 * (f + d + om)) + 19 * Math.Sin(l + 2 * (f + d + om));
        n = n + 104 * Math.Cos(2 * (f - l)) + 2 * Math.Sin(2 * (f - l));
        n = n - 3250 * Math.Cos(lp + 2 * (f + om)) + 5 * Math.Sin(lp + 2 * (f + om));
        n = n + 3353 * Math.Cos(2 * (f + d) + om) + 14 * Math.Sin(2 * (f + d) + om);
        n = n + 3070 * Math.Cos(2 * (f + om) - lp) + 4 * Math.Sin(2 * (f + om) - lp);
        n = n + 3272 * Math.Cos(2 * d + om) + 4 * Math.Sin(2 * d + om);
        n = n - 3045 * Math.Cos(l + 2 * (f - d) + om) + Math.Sin(l + 2 * (f - d) + om);
        n = n - 2768 * Math.Cos(2 * (l + f - d + om)) + 4 * Math.Sin(2 * (l + f - d + om));
        n = n + 3041 * Math.Cos(2 * (d - l) + om) - 5 * Math.Sin(2 * (d - l) + om);
        n = n + 2695 * Math.Cos(2 * (l + f) + om) + 12 * Math.Sin(2 * (l + f) + om);
        n = n + 2719 * Math.Cos(2 * (f - d) + om - lp) - 3 * Math.Sin(2 * (f - d) + om - lp);
        n = n + 2720 * Math.Cos(om - 2 * d) - 9 * Math.Sin(om - 2 * d);
        n = n - 51 * Math.Cos(2 * d - l - lp) - 4 * Math.Sin(2 * d - l - lp);
        n = n - 2206 * Math.Cos(2 * (l - d) + om) - Math.Sin(2 * (l - d) + om);
        n = n - 199 * Math.Cos(l + 2 * d) - 2 * Math.Sin(l + 2 * d);
        n = n - 1900 * Math.Cos(lp + 2 * (f - d) + om) - Math.Sin(lp + 2 * (f - d) + om);
        n = n - 41 * Math.Cos(l - lp) - 3 * Math.Sin(l - lp);
        n = n + 1313 * Math.Cos(2 * (f - l + om)) - Math.Sin(2 * (f - l + om));
        n = n + 1233 * Math.Cos(3 * l + 2 * (f + om)) + 7 * Math.Sin(3 * l + 2 * (f + om));
        n = n - 81 * Math.Cos(-lp + 2 * d) - 2 * Math.Sin(-lp + 2 * d);
        n = n + 1232 * Math.Cos(l - lp + 2 * (f + om)) + 4 * Math.Sin(l - lp + 2 * (f + om));
        n = n - 20 * Math.Cos(d) + 2 * Math.Sin(d);
        n = n + 1207 * Math.Cos(2 * (f + d + om) - l - lp) + 3 * Math.Sin(2 * (f + d + om) - l - lp);
        n = n + 40 * Math.Cos(2 * f - l) - 2 * Math.Sin(2 * f - l);
        n = n + 1129 * Math.Cos(2 * (f + d + om) - lp) + 5 * Math.Sin(2 * (f + d + om) - lp);
        n = n + 1266 * Math.Cos(om - 2 * l) - 4 * Math.Sin(om - 2 * l);
        n = n - 1062 * Math.Cos(l + lp + 2 * (f + om)) + 3 * Math.Sin(l + lp + 2 * (f + om));
        n = n - 1129 * Math.Cos(2 * l + om) + 2 * Math.Sin(2 * l + om);
        n = n - 9 * Math.Cos(lp + d - l);
        n = n + 35 * Math.Cos(l + lp) - 2 * Math.Sin(l + lp);
        n = n - 107 * Math.Cos(l + 2 * f) - Math.Sin(l + 2 * f);
        n = n + 1073 * Math.Cos(2 * (f - d) + om - l) - 2 * Math.Sin(2 * (f - d) + om - l);
        n = n + 854 * Math.Cos(l + 2 * om);
        n = n - 553 * Math.Cos(d - l) + 139 * Math.Sin(d - l);
        n = n - 710 * Math.Cos(2 * (f + om) + d) + 2 * Math.Sin(2 * (f + om) + d);
        n = n + 647 * Math.Cos(2 * (f + 2 * d + om) - l) + 4 * Math.Sin(2 * (f + 2 * d + om) - l);
        n = n - 700 * Math.Cos(lp + d + om - l);
        n = n + 672 * Math.Cos(2 * (f - lp - d) + om);
        n = n + 663 * Math.Cos(l + 2 * (f + d) + om) + 4 * Math.Sin(l + 2 * (f + d) + om);
        n = n - 594 * Math.Cos(2 * (f - l + d + om)) + 2 * Math.Sin(2 * (f - l + d + om));
        n = n - 610 * Math.Cos(2 * om - l) - 2 * Math.Sin(2 * om - l);
        n = n - 556 * Math.Cos(l + lp + 2 * (f - d + om));
        n /= 36000000000.0d;
        return toRadians(n);
    }

    private static double getL(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        double t4 = t3 * t;
        return toRadians((485868.249036 + 1717915923.2178 * t + 31.8792 * t2 + 0.051635 * t3 - 0.00024470 * t4) / 3600.0);
    }

    private static double getLp(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        double t4 = t3 * t;
        return toRadians((1287104.79305 + 129596581.0481 * t - 0.5532 * t2 + 0.000136 * t3 - 0.00001149 * t4) / 3600.0);
    }

    private static double getF(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        double t4 = t3 * t;
        return toRadians((335779.526232 + 1739527262.8478 * t - 12.7512 * t2 - 0.001037 * t3 + 0.00000417 * t4) / 3600.0);
    }

    private static double getD(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        double t4 = t3 * t;
        return toRadians((1072260.70369 + 1602961601.2090 * t - 6.3706 * t2 + 0.006593 * t3 - 0.00003169 * t4) / 3600.0);
    }

    private static double getOm(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        double t4 = t3 * t;
        return toRadians((450160.398036 - 6962890.5431 * t + 7.4722 * t2 + 0.007702 * t3 - 0.00005939 * t4) / 3600.0);
    }

    /**
     * 计算黄经章动
     * 
     * @param jd
     *            儒略日
     * @return 章动的值(rad)
     */
    public static double getLongitudeNutation(double jd) {
        double t = getJulianCentury(jd);
        double l = getL(t);
        double lp = getLp(t);
        double f = getF(t);
        double d = getD(t);
        double om = getOm(t);
        return getLongitudeNutation(t, l, lp, f, d, om);
    }

    /**
     * 计算交角章动
     * 
     * @param jd
     *            儒略日
     * @return 章动的值(rad)
     */
    public static double getObliquityNutation(double jd) {
        double t = getJulianCentury(jd);
        double l = getL(t);
        double lp = getLp(t);
        double f = getF(t);
        double d = getD(t);
        double om = getOm(t);
        return getObliquityNutation(t, l, lp, f, d, om);
    }

    public static void Main(string[] args) {
        double jd = CalendarUtil.toJulianDate(1987, 4, 10, 0, 0, 0.0);
        double t = getJulianCentury(jd);
        double ln = getLongitudeNutation(jd);
        double on = getObliquityNutation(jd);
        Console.WriteLine(jd);
        Console.WriteLine(t);
        Console.WriteLine(toDegrees(ln));
        Console.WriteLine(toDegrees(ln) * 3600);
        Console.WriteLine(toDegrees(on));
        Console.WriteLine(toDegrees(on) * 3600);
    }
}
