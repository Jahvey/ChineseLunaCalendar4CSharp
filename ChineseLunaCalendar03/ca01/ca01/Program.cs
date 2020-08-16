using ca01.test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using  calendar;
using System.Collections;
using static NewMoonCalculator;
using static CalendarUtil;
using static SolarTermsCalculator;
using static MathUtil;
using static Elp82Util;
using static Vsop87dEarthUtil;
namespace ca01
{
    class Program
    {
        static void Main(string[] args)
        {
            Test24Calendar1();
            Test24Calendar();

            // Test1.TestData();
            TestOtherFunction();
            //Console.WriteLine(toDegrees(getEarthEclipticLongitudeForMoon(2448724.5)));
            Console.ReadKey();

        }

        public static void TestOtherFunction() {


            double jd = CalendarUtil.toJulianDate(1987, 4, 10, 0, 0, 0.0);
            double l = getSunEclipticLongitudeForEarth(jd);
            double b = getSunEclipticLatitudeForEarth(jd);
            double r = getSunRadiusForEarth(jd);
            double dl = vsop2Fk5LongitudeCorrection(l, b, jd);
            double db = vsop2Fk5LatitudeCorrection(l, b, jd);
            Console.WriteLine(jd);
            Console.WriteLine(l);
            Console.WriteLine(b);
            Console.WriteLine(r);
            Console.WriteLine(dl);
            Console.WriteLine(db);

            Console.WriteLine(toDegrees(getEarthEclipticLongitudeForMoon(2448724.5)));
        }

        public static void Test24Calendar1() {
            SolarTerms solarTerms = new SolarTerms();
            ArrayList list = solarTerms.listArr;
            foreach (SolarVo term in list)
            {
                double jd = getJulianDayInYearForTermOrder(term, 2020);
                jd -= CalendarUtil.getDeltaT(jd) / 86400; // 由TT转换成UTC
                DateTime cal = fromJulianDate(jd + 8.0 / 24.0); // 东8区
                Console.WriteLine(term.Name + ": " +
                    String.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", cal.Year,
                                cal.Month, cal.Day,
                                cal.Hour, cal.Minute,
                                cal.Second, cal.Millisecond));
            }

        }
        public static void Test24Calendar() {

            for (int month = 1; month <= 12; month++)
            {
                ArrayList jds = getJulianDayInYearAndMonthForNewMoon(2020, month);

                for (int i = 0; i < jds.Count; i++)
                {
                    double jd = (double)jds[i];
                    jd -= CalendarUtil.getDeltaT(jd) / 86400; // 由TT转换成UTC
                    DateTime cal = fromJulianDate(jd + 8.0 / 24.0); // 东8区
                   // DateTime cal = fromJulianDate(jd);
                    Console.WriteLine(String.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}",
                            cal.Year, cal.Month, cal.Day,
                            cal.Hour, cal.Minute,
                            cal.Second, cal.Millisecond));
                }
                    
               
            }
        }
    }


    public  class Test1 {
        public static  void TestData() {
            //ReflectionTest test1 = new ReflectionTest();
            // ReflectionTest.test<Animal>(new Animal("heheda"));
            //  ReflectionTest.test<Dog>(new Dog("111"));
            // ReflectionTest.show<Dog>();
            ReflectionTest.getOutElpMain<Elp_Main_S1_001>();
            //CalendarTest calendar = new CalendarTest();
            //calendar.printTimeZone();
            Console.ReadKey();
        }

    }

    class CalendarTest
    {

        private static TimeZone timezone= TimeZone.CurrentTimeZone;
        private static TimeZoneInfo timezoneinfo=TimeZoneInfo.Local;

        public  void printTimeZone() {
            DateTime convertedDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            DateTime localDateTime = DateTime.Now;//本地时间
            DateTime utcDateTime = DateTime.UtcNow;//协调世界时 
            DateTime temp1 = DateTime.SpecifyKind(localDateTime, DateTimeKind.Utc);//本地时间转成UTC时间
            DateTime temp2 = DateTime.SpecifyKind(utcDateTime, DateTimeKind.Local);//将UTC时间转成本地时间
            DateTime temp3 = DateTime.SpecifyKind(localDateTime, DateTimeKind.Unspecified);//既不是本地时间也不是UTC时间

            temp1.Add(TimeSpan.Parse("1"));
            Console.WriteLine("localDateTime="+ localDateTime+ ",utcDateTime="+ utcDateTime);
            Console.WriteLine("temp1="+ temp1+ ",temp2="+ temp2+ ",temp3="+temp3);
            Console.WriteLine("Tz="+timezone.ToString()+",TZinfo="+timezoneinfo+ ",convertedDate="+ convertedDate);
        }

    }






    class ReflectionTest
    {

        public static void getOutElpMain<T>()where T : Elp_Main_S1_001
        {

            Type type = typeof(T);
           // MethodInfo memberA = type.GetMethod("test1");
           FieldInfo fieldInfo = type.GetField("PARAMS");
            Double[]arr=(Double[]) fieldInfo.GetValue(type);
            Console.WriteLine(arr+";"+arr.Length+";"+arr[0]);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine(type.Name== "Elp_Main_S1_001");
            Console.WriteLine(type.Name);
            int lineItems = (Int32)type.GetField("LINE_ITEMS").GetValue(type);
          
            Console.WriteLine(lineItems);


            for (int i = 0; i < 2; i++)
            {
                Double[] paramsNumbers = (Double[])type.GetField("PARAMS" + i).GetValue(type);
                Console.WriteLine(i+":"+paramsNumbers[i]);
            }

        }

        public static void show<T>()where T : Animal
        {
            Type type = typeof(T);
            MethodInfo memberA = type.GetMethod("test1");
            Console.WriteLine(memberA == null ? true : false);
            memberA.Invoke(type, null);

            MethodInfo member2 = type.GetMethod("test2");
            Console.WriteLine(memberA == null ? true : false);
            member2.Invoke(type, new object[] { 12, "wanghao" });

        }

        public static void test<T>(T clazz) where T : Animal {

            Type type = clazz.GetType();
           ConstructorInfo[] arr= type.GetConstructors();
           MethodInfo[]methods= type.GetMethods();
            object obj = Activator.CreateInstance(type,new Object[] {});
            //foreach (var item in methods)
            //{
            //    Console.WriteLine(item.GetMethodBody());
            //}

            //使用 C# 的相关方式 来调用相关 成员的方法
            MethodInfo memberA = type.GetMethod("test1");
            Console.WriteLine(memberA==null? true :false);
           memberA.Invoke(type, null);

            MethodInfo member2 = type.GetMethod("test2");
            Console.WriteLine(memberA == null ? true : false);
            member2.Invoke(type, new object[] {12,"wanghao" });
            //修改成员变量的值
            FieldInfo nameInfo =type.GetField("name");
            
           // nameInfo.SetValue(type, "heheda333");
            
            

        }
    }

    class Dog : Animal {
         private string name ="";



        public Dog() {
        }
        public Dog(String name)
        {
            this.Name = name;
            Console.WriteLine(name);
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

        public static void test1() {

            Console.WriteLine("this is test1......");

        }
        public static void test2(int age,string name)
        {

            Console.WriteLine("this is test2......"+age+":"+name);

        }


    }

    class Animal {

        private String name="";
        public Animal() {
            name = "animal";
        }
       public Animal(String name) {

            Console.WriteLine("Animail:"+name);
        }


    }

}
