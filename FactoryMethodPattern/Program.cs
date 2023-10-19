using FactoryMethodPattern;
using System.ComponentModel.Design;

namespace FactoryMethodPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CaculatorFactory factory = null;
            ICaculator caculator = null;
            while (true)
            {
                Console.Write("請輸入運算方法(+, -, *, /)：");
                var opr = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (opr == '+')
                {
                    factory = new AdditionFactory();
                }
                else if (opr == '-')
                {
                    factory = new SubtractionFactory();
                }
                else if (opr == '*')
                {
                    factory = new MutiplicationFactory();
                }
                else //if (opr == '/')
                {
                    factory = new DivisionFactory();
                }

                #region 運算邏輯
                caculator = factory.CreateCaculator();
                caculator.InputOperands();
                caculator.Caculate();
                caculator.Output();
                #endregion

                Console.Write("繼續?(Y/y),  結束?(N/n))： ");
                var tryagain = Console.ReadKey().KeyChar;
                if (tryagain == 'Y' || tryagain == 'y')
                {
                    Console.Clear();
                }
                else
                {
                    break;
                }


            }



        }

    }



    #region  工廠
    /// <summary>
    /// 工廠父類別(抽象)
    /// </summary>
    public abstract class CaculatorFactory
    {
       public  abstract ICaculator CreateCaculator();
    }

    /// <summary>
    /// 加法器工廠
    /// </summary>
    public class AdditionFactory : CaculatorFactory
    {
        public  override ICaculator CreateCaculator()
        {
            return new AdditionCaculator();
        }

    }

    /// <summary>
    /// 減法器工廠
    /// </summary>
    public class SubtractionFactory : CaculatorFactory
    {
        public override ICaculator CreateCaculator()
        {
            return new SubtractionCaculator();
        }
    }

    /// <summary>
    /// 乘法器工廠
    /// </summary>
    public class MutiplicationFactory : CaculatorFactory
    {
        public override ICaculator CreateCaculator()
        {
            return new MultiplicationCaculator();
        }
    }


    /// <summary>
    /// 除法器工廠
    /// </summary>
    public class DivisionFactory : CaculatorFactory
    {
        public override ICaculator CreateCaculator()
        {
            return new DivisionCaculator();
        }
    }



    #endregion

    #region 產品
    /// <summary>
    /// 計算器 interface
    /// </summary>
    public interface ICaculator
    {

        int OperandA { get; set; }
        int OperandB { get; set; }
        float Result { get; set; }

        void InputOperands();
        void Caculate();

        void Output();
    }

    /// <summary>
    /// 加法
    /// </summary>
    public class AdditionCaculator : ICaculator
    {
        public int OperandA { get; set; }
        public int OperandB { get; set; }
        public float Result { get; set; }

        public void Caculate()
        {
            Result = OperandA + OperandB;
        }

        public void InputOperands()
        {
            Console.Write("請輸入被加數：");
            var a = Console.ReadLine();
            OperandA = Convert.ToInt32(a);
            Console.Write("請輸入加數：");
            var b = Console.ReadLine();
            OperandB = Convert.ToInt32(b);
        }

        public void Output()
        {
            Console.WriteLine($"{OperandA} + {OperandB} = {(int)Result}");
        }
    }


    /// <summary>
    /// 減法
    /// </summary>
    public class SubtractionCaculator : ICaculator
    {
        public int OperandA { get; set; }
        public int OperandB { get; set; }
        public float Result { get; set; }

        public void Caculate()
        {
            Result = OperandA - OperandB;
        }

        public void InputOperands()
        {
            Console.Write("請輸入被減數：");
            var a = Console.ReadLine();
            OperandA = Convert.ToInt32(a);
            Console.Write("請輸入減數：");
            var b = Console.ReadLine();
            OperandB = Convert.ToInt32(b);
        }

        public void Output()
        {
            Console.WriteLine($"{OperandA} - {OperandB} = {(int)Result}");
        }

    }

    public class MultiplicationCaculator : ICaculator
    {
        public int OperandA { get; set; }
        public int OperandB { get; set; }
        public float Result { get; set; }

        public void Caculate()
        {
            Result = OperandA * OperandB;
        }

        public void InputOperands()
        {
            Console.Write("請輸入被乘數：");
            var a = Console.ReadLine();
            OperandA = Convert.ToInt32(a);
            Console.Write("請輸入乘數：");
            var b = Console.ReadLine();
            OperandB = Convert.ToInt32(b);
        }

        public void Output()
        {

            Console.WriteLine($"{OperandA} * {OperandB} = {Result}");
        }
    }


    /// <summary>
    /// 除法
    /// </summary>
    public class DivisionCaculator : ICaculator
    {
        public int OperandA { get; set; }
        public int OperandB { get; set; }
        public float Result { get; set; }

        public void Caculate()
        {
            Result = OperandA / (float)OperandB;
        }

        public void InputOperands()
        {
            Console.Write("請輸入被除數：");
            var a = Console.ReadLine();
            OperandA = Convert.ToInt32(a);
            Console.Write("請輸入除數：");
            var b = Console.ReadLine();
            OperandB = Convert.ToInt32(b);
        }

        public void Output()
        {
            Console.WriteLine($"{OperandA} / {OperandB} = {Result}");
        }
    }
    #endregion
}