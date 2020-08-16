using System;
using static ElpMpp02Constants;
using static MathUtil;
using static CalendarUtil;
using System.Reflection;

public class ElpMpp02Util {

    /**
     * D = W1 - T + 180˚
     * 
     * @param t
     *            儒略世纪数
     * @return D的值(rad)
     */
    private static double getDu(double t) {
        return getW1u(t) - getTu(t) + Math.PI;
    }

    /**
     * F = W1 - W3
     * 
     * @param t
     *            儒略世纪数
     * @return F的值(rad)
     */
    private static double getFu(double t) {
        return getW1u(t) - getW3u(t);
    }

    /**
     * l = W1 - W2
     * 
     * @param t
     *            儒略世纪数
     * @return l的值(rad)
     */
    private static double getL(double t) {
        return getW1u(t) - getW2u(t);
    }

    /**
     * lp = T - Omp
     * 
     * @param t
     *            儒略世纪数
     * @return lp的值(rad)
     */
    private static double getLp(double t) {
        return getTu(t) - getGomegap(t);
    }

    /**
     * Me(rcury) = 252˚15´03.216919˝ + 538101628.68888˝ * t
     * 
     * @param t
     *            儒略世纪数
     * @return Me的值
     */
    private static double getMeu(double t) {
        return LAMBDA_ME_0 + LAMBDA_ME_1 * t;
    }

    /**
     * V(enus) = 181˚58´44.758419˝ + 210664136.45777˝ * t
     * 
     * @param t
     *            儒略世纪数
     * @return V的值
     */
    private static double getVu(double t) {
        return LAMBDA_V_0 + LAMBDA_V_1 * t;
    }

    /**
     * Ma(rs) = 355˚26´′03.642778˝ + 68905077.65936˝ * t
     * 
     * @param t
     *            儒略世纪数
     * @return Ma的值
     */
    private static double getMau(double t) {
        return LAMBDA_MA_0 + LAMBDA_MA_1 * t;
    }

    /**
     * J(upiter) = 34˚21´05.379392˝ + 10925660.57335˝ * t
     * 
     * @param t
     *            儒略世纪数
     * @return J的值
     */
    private static double getJu(double t) {
        return LAMBDA_J_0 + LAMBDA_J_1 * t;
    }

    /**
     * S(aturn) = 50˚04´38.902495˝ + 4399609.33632˝ * t
     * 
     * @param t
     *            儒略世纪数
     * @return S的值
     */
    private static double getSu(double t) {
        return LAMBDA_S_0 + LAMBDA_S_1 * t;
    }

    /**
     * U(ranus) = 314˚03´04.354234˝ + 1542482.57845˝ * t
     * 
     * @param t
     *            儒略世纪数
     * @return U的值
     */
    private static double getUu(double t) {
        return LAMBDA_U_0 + LAMBDA_U_1 * t;
    }

    /**
     * N(eptune) = 304˚20´56.808371˝ + 786547.89700˝ * t
     * 
     * @param t
     *            儒略世纪数
     * @return N的值
     */
    private static double getNu(double t) {
        return LAMBDA_N_0 + LAMBDA_N_1 * t;
    }

    /**
     * zeta = W1 + (5029.0966˝ - 0.29965˝) * t
     * 
     * @param t
     *            儒略世纪数
     * @return zeta的值
     */
    private static double getGzeta(double t) {
        return getW1u(t) + secondsToRadians(P - DELTAU_P) * t;
    }

    /**
     * W1 = 218˚18´59.95571˝ + 1732559343.73604˝ * t - 6.8084˝ * t² + 0.006604˝ * t³ - 0.00003169˝ *
     * t⁴
     * 
     * @param t
     *            儒略世纪数
     * @return W1的值(rad)
     */
    private static double getW1u(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        double t4 = t3 * t;
        return W1_0 + W1_1 * t + W1_2 * t2 + W1_3 * t3 + W1_4 * t4;
    }

    /**
     * W2 = 83˚21´11.67475˝ + 14643420.3171˝ * t - 38.2631˝ * t² - 0.045047˝ * t³ + 0.00021301˝ * t⁴
     * 
     * @param t
     *            儒略世纪数
     * @return W2的值(rad)
     */
    private static double getW2u(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        double t4 = t3 * t;
        return W2_0 + W2_1 * t + W2_2 * t2 + W2_3 * t3 + W2_4 * t4;
    }

    /**
     * W3 = 125˚02´40.39816˝ + 6967919.5383˝ * t - 6.3590˝ * t² + 0.007625˝ * t³ + 0.00003586˝ * t⁴
     * 
     * @param t
     *            儒略世纪数
     * @return W3的值(rad)
     */
    private static double getW3u(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        double t4 = t3 * t;
        return W3_0 + W3_1 * t + W3_2 * t2 + W3_3 * t3 + W3_4 * t4;
    }

    /**
     * T = 100˚27´59.13885˝ + 129597742.2930˝ * t - 0.0202˝ * t² + 0.000009˝ * t³ + 0.00000015˝ * t⁴
     * 
     * @param t
     *            儒略世纪数
     * @return T的值(rad)
     */
    private static double getTu(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        double t4 = t3 * t;
        return T_0 + T_1 * t + T_2 * t2 + T_3 * t3 + T_4 * t4;
    }

    /**
     * omegap = 102˚56´14.45766˝ + 1161.24342˝ * t + 0.529265˝ * t² - 0.00011814˝ * t³ +
     * 0.000011379˝ * t⁴
     * 
     * @param t
     *            儒略世纪数
     * @return omegap的值(rad)
     */
    private static double getGomegap(double t) {
        double t2 = t * t;
        double t3 = t2 * t;
        double t4 = t3 * t;
        return GOMEGAP_0 + GOMEGAP_1 * t + GOMEGAP_2 * t2 + GOMEGAP_3 * t3 + GOMEGAP_4 * t4;
    }

    private static double getMain<T>(double t)where T : Elp_Main  {
        Type type = typeof(T);
        double[] paramsNumber=(double[]) type.GetField("PARAMS").GetValue(type);
        //Double[] params = (Double[]) clazz.getField("PARAMS").get(null);
        // int lineItems = clazz.getField("LINE_ITEMS").getInt(null);
        int lineItems =(Int32) type.GetField("LINE_ITEMS").GetValue(type);
        double result = 0.0d;
        double du = getDu(t);
        double fu = getFu(t);
        double l = getL(t);
        double lp = getLp(t);
        for (int i = 0; i < paramsNumber.Length; i += lineItems) {
            int i1 = (int)paramsNumber[i];
            int i2 =(int) paramsNumber[i + 1];
            int i3 = (int)paramsNumber[i + 2];
            int i4 =(int) paramsNumber[i + 3];
            double aui = paramsNumber[i + 4];
            double bu1i = paramsNumber[i + 5];
            double bu2i = paramsNumber[i + 6];
            double bu3i = paramsNumber[i + 7];
            double bu4i = paramsNumber[i + 8];
            double bu5i = paramsNumber[i + 9];
            if (type.Name=="Elp_Main_S3") {
                double deltaaui = -M * (bu1i + 2 / 3.0 * GALPHA / M * bu5i + 2 / 3.0 * aui / M)
                        * DELTA_GNU / GNU + (bu1i + 2 / 3.0 * GALPHA / M * bu5i) * DELTA_NP / GNU
                        + (bu2i * DELTA_GGAMMA + bu3i * DELTA_E + bu4i * DELTA_EP);
                result += (aui + deltaaui) * (Math.Cos(i1 * du + i2 * fu + i3 * l + i4 * lp));
            } else {
                double deltaaui = -M * (bu1i + 2 / 3.0 * GALPHA / M * bu5i) * DELTA_GNU / GNU
                        + (bu1i + 2 / 3.0 * GALPHA / M * bu5i) * DELTA_NP / GNU
                        + (bu2i * DELTA_GGAMMA + bu3i * DELTA_E + bu4i * DELTA_EP);
                result += (aui + deltaaui) * (Math.Sin(i1 * du + i2 * fu + i3 * l + i4 * lp));
            }
        }
        return type.Name == "Elp_Main_S3" ? result : MathUtil.secondsToRadians(result);
    }

    private static double getPert<T>(double t) where T: Elp_Pert{
        Type type = typeof(T);
        double t2 = t * t;
        double t3 = t2 * t;
        double[] pow = {1.0, t, t2, t3};
         //int lineItems = clazz.getField("LINE_ITEMS").getInt(null);
         int lineItems=(Int32)type.GetField("LINE_ITEMS").GetValue(type);

        double du = getDu(t);
        double fu = getFu(t);
        double l = getL(t);
        double lp = getLp(t);
        double meu = getMeu(t);
        double vu = getVu(t);
        double tu = getTu(t);
        double mau = getMau(t);
        double ju = getJu(t);
        double su = getSu(t);
        double uu = getUu(t);
        double nu = getNu(t);
        double gzeta = getGzeta(t);

        double result = 0.0d;
        for (int n = 0; n < 4; n++) {
       // Double[] params = (Double[])clazz.getField("PARAMS" + n).get(null);
        Double[] paramsNumbers =(Double[]) type.GetField("PARAMS"+n).GetValue(type);
            for (int i = 0; i < paramsNumbers.Length; i += lineItems) {
                double sui = paramsNumbers[i];
                double cui = paramsNumbers[i + 1];
                int i1 = (int)paramsNumbers[i + 2];
                int i2 = (int)paramsNumbers[i + 3];
                int i3 = (int)paramsNumbers[i + 4];
                int i4 = (int)paramsNumbers[i + 5];
                int i5 = (int)paramsNumbers[i + 6];
                int i6 =(int) paramsNumbers[i + 7];
                int i7 =(int) paramsNumbers[i + 8];
                int i8 =(int) paramsNumbers[i + 9];
                int i9 = (int)paramsNumbers[i + 10];
                int i10 =(int) paramsNumbers[i + 11];
                int i11 =(int) paramsNumbers[i + 12];
                int i12 =(int) paramsNumbers[i + 13];
                int i13 =(int) paramsNumbers[i + 14];
                double gphi = i1 * du + i2 * fu + i3 * l + i4 * lp + i5 * meu + i6 * vu + i7 * tu
                        + i8 * mau + i9 * ju + i10 * su + i11 * uu + i12 * nu + i13 * gzeta;
                result += pow[n] * (sui * Math.Sin(gphi) + cui * Math.Cos(gphi));
            }
        }
        return type.Name== "Elp_Pert_S3"? result : MathUtil.secondsToRadians(result);
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
        double main1 = 0.0d;
        double pert = 0.0d;
    try
    {
        //try {
        main1 = getMain<Elp_Main_S1>(t);
        pert = getPert<Elp_Pert_S1>(t);
        //} catch (Exception e) {
        //    e.printStackTrace();
        //}
    }
    catch (Exception ex)
    {

        throw ex;
    }

        return MathUtil.mod2Pi(main1 + pert + getW1u(t));
    }

    public static void Main(string[] args) {
        Console.WriteLine(getEarthEclipticLongitudeForMoon(0));
	}
}