using System;
namespace InterpreterDesignPattern
{
    public class Context
    {
        public string Expression { get; set; }
        public DateTime Date { get; set; }
        public Context(DateTime date)
        {
            this.Date = date;
        }
    }
    public interface IExpression
    {
        string Evaluate(Context context);
    }
    public class DayExpression : IExpression
    {
        public string Evaluate(Context context)
        {
            return context.Date.Day.ToString();
        }
    }
    public class MonthExpression : IExpression
    {
        public string Evaluate(Context context)
        {
            return context.Date.Month.ToString();
        }
    }
    public class YearExpression : IExpression
    {
        public string Evaluate(Context context)
        {
            return context.Date.Year.ToString();
        }
    }
    public class SeparatorExpression : IExpression
    {
        public string Evaluate(Context context)
        {
            return "-";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context(DateTime.Now);
            var expressionList = new System.Collections.Generic.List<IExpression>();
            expressionList.Add(new DayExpression());
            expressionList.Add(new SeparatorExpression());
            expressionList.Add(new MonthExpression());
            expressionList.Add(new SeparatorExpression());
            expressionList.Add(new YearExpression());
            foreach (var expression in expressionList)
            {
                Console.Write(expression.Evaluate(context));
            }
            Console.ReadKey();
        }
    }
}
