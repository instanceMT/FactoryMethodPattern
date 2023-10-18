using FactoryMethodPattern;

namespace FactoryMethodPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("請輸入運算子(+, -)：");
                var opr = Console.ReadKey().KeyChar;
                CaculatorFactory factory = null;
                if (opr == '+')
                {
                    factory = new AdditionCaculatorFactory();
                }
                else if (opr == '-')
                {
                    factory = new SubtractionCaculatorFactory();
                }
                Console.WriteLine();
                var caculator = factory.CreateCaculator();
                caculator.InputOperandAndCheck();
                caculator.Caculate();
                caculator.Output();

                Console.WriteLine("繼續(Y), 結束(N)");
                var re = Console.ReadKey().KeyChar;
                if (re != 'Y' && re != 'y')
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }

        }

    }
    #region   產品
    public interface ICaculate
    {
        int OperandA { get; set; }
        int OperandB { get; set; }
        float Result { get; set; }
        void InputOperandAndCheck();
        void Caculate();

        void Output();
    }

    public class AdditionCulator : ICaculate
    {
        public int OperandA { get; set; }
        public int OperandB { get; set; }
        public float Result { get; set; }
        public void Caculate()
        {
            Result = OperandA + OperandB;
        }

        public void InputOperandAndCheck()
        {
            Console.WriteLine("輸入被加數：");
            var a = Console.ReadLine();
            Console.WriteLine("輸入加數：");
            var b = Console.ReadLine();
            OperandA = Convert.ToInt32(a);
            OperandB = Convert.ToInt32(b);
        }

        public void Output()
        {
            Console.WriteLine("{0} + {1} = {2}", OperandA, OperandB, Result);
        }
    }
    public class SubtractionCulator : ICaculate
    {
        public int OperandA { get; set; }
        public int OperandB { get; set; }
        public float Result { get; set; }
        public void Caculate()
        {
            Result = OperandA - OperandB;
        }

        public void InputOperandAndCheck()
        {
            Console.WriteLine("輸入被減數：");
            var a = Console.ReadLine();
            Console.WriteLine("輸入減數：");
            var b = Console.ReadLine();
            OperandA = Convert.ToInt32(a);
            OperandB = Convert.ToInt32(b);
        }

        public void Output()
        {
            Console.WriteLine("{0} - {1} = {2}", OperandA, OperandB, Result);
        }
    }
    #endregion



    #region  工廠

    /// <summary>
    /// 各工廠的共同父類別(抽象) 
    /// </summary>
    public abstract class CaculatorFactory
    {
        public abstract ICaculate CreateCaculator();

    }

    public class AdditionCaculatorFactory : CaculatorFactory
    {
        public override ICaculate CreateCaculator()
        {
            return new AdditionCulator();
        }
    }
    public class SubtractionCaculatorFactory : CaculatorFactory
    {
        public override ICaculate CreateCaculator()
        {
            return new SubtractionCulator();
        }
    }
    #endregion

  
}