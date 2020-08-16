
using System;

public class MathUtil {




    /// <summary>
    /// 将弧度度转换成度
    /// </summary>
    /// <param name="degrees"></param>
    /// <returns></returns>
    public static double toDegrees(double radians)
    {

        double degrees = (180 / Math.PI) * radians;
        return degrees;
    }

    /// <summary>
    /// 将度转换成弧度
    /// </summary>
    /// <param name="degrees"></param>
    /// <returns></returns>
    public static double toRadians(double degrees)
    {
        double radians = (Math.PI / 180) * degrees;
        return (radians);
    }

    /**
     * 把角秒换算成弧度
     * 
     * @param seconds
     *            角秒
     * @return 对应的弧度值
     */
    public static double secondsToRadians(double seconds) {
        return toRadians(secondsToDegrees(seconds));
    }

    /**
     * 把角度限制在[0, 2π]之间
     * 
     * @param r
     *            原角度(rad)
     * @return 转换后的角度(rad)
     */
    public static double mod2Pi(double r) {
        while (r < 0) {
            r += Math.PI * 2;
        }
        while (r > 2 * Math.PI) {
            r -= Math.PI * 2;
        }
        return r;
    }

    /**
     * 把角度限制在[-π, π]之间
     * 
     * @param r
     *            原角度(rad)
     * @return 转换后的角度(rad)
     */
    public static double modPi(double r) {
        while (r < -Math.PI) {
            r += Math.PI * 2;
        }
        while (r > Math.PI) {
            r -= Math.PI * 2;
        }
        return r;
    }

    /**
     * 把角秒换算成角度
     * 
     * @param seconds
     *            角秒
     * @return 对应的弧度值
     */
    public static double secondsToDegrees(double seconds) {
        return seconds / 3600;
    }

    /**
     * 把度分秒表示的角度换算成度(deg)
     * 
     * @param d
     *            度
     * @param m
     *            分
     * @param s
     *            秒
     * @return 换算成度的值
     */
    public static double dmsToDegrees(int d, int m, double s) {
        return d + m / 60.0 + s / 3600;
    }

    /**
     * 把度分秒表示的角度换算成秒(arcsecond)
     * 
     * @param d
     *            度
     * @param m
     *            分
     * @param s
     *            秒
     * @return 换算成秒的值
     */
    public static double dmsToSeconds(int d, int m, double s) {
        return d * 3600 + m * 60 + s;
    }

    /**
     * 把度分秒表示的角度换算成弧度(rad)
     * 
     * @param d
     *            度
     * @param m
     *            分
     * @param s
     *            秒
     * @return 换算成弧度的值
     */
    public static double dmsToRadians(int d, int m, double s) {
        return toRadians(dmsToDegrees(d, m, s));
    }

    /**
     * 牛顿迭代求解方程的根
     *
     * @param f
     *            方程表达式
     * @param x0
     *            对根的估值
     * @return 在x0附近的一个根
     */
    public static double newtonIteration( Func<double,double> f, double x0) {
        const double EPSILON = 1e-7;
       const double DELTA = 5e-6;
        double x;
        do {
            x = x0;
            double fx = f(x);
            double fpx = (f(x + DELTA) - f(x - DELTA)) / DELTA / 2;
            x0 = x - fx / fpx;
        } while (Math.Abs(x0 - x) > EPSILON);
        return x;
    }



    /**
 * 牛顿迭代求解方程的根
 *
 * @param f
 *            方程表达式
 * @param x0
 *            对根的估值
 * @return 在x0附近的一个根
 */
    public static double newtonIterationCopy(Function f, double x0)
    {
        const double EPSILON = 1e-7;
        const double DELTA = 5e-6;
        double x;
        do
        {
            x = x0;
            double fx = f.f(x);
            double fpx = (f.f(x + DELTA) - f.f(x - DELTA)) / DELTA / 2;
            x0 = x - fx / fpx;
        } while (Math.Abs(x0 - x) > EPSILON);
        return x;
    }
}
