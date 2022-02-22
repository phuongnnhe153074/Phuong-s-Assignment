using System.Linq.Expressions;
namespace Assignment_API_2.Common;


public class ExpressionRebinder : ExpressionVisitor
{
    private readonly Expression _oldValue;
    private readonly Expression _newValue;
    public ExpressionRebinder(Expression oldValue, Expression newValue)
    {
        _oldValue = oldValue;
        _newValue = newValue;
    }
    public override Expression Visit(Expression node)
    {
        return node == _oldValue ? _newValue : base.Visit(node);
    }
}
public static class LambdaExtensions
{
    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)

    {
        var parameter = Expression.Parameter(typeof(T));

        var leftVisitor = new ExpressionRebinder(expr1.Parameters[0], parameter);
        var left = leftVisitor.Visit(expr1.Body);

        var rightVisitor = new ExpressionRebinder(expr2.Parameters[0], parameter);
        var right = rightVisitor.Visit(expr2.Body);


        return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left ?? throw new InvalidOperationException(), right ?? throw new InvalidOperationException()),parameter);

    }



    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)

    {
        var parameter = Expression.Parameter(typeof(T));

        var leftVisitor = new ExpressionRebinder(expr1.Parameters[0], parameter);
        var left = leftVisitor.Visit(expr1.Body);

        var rightVisitor = new ExpressionRebinder(expr2.Parameters[0], parameter);
        var right = rightVisitor.Visit(expr2.Body);


        return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left ?? throw new InvalidOperationException(), right ?? throw new InvalidOperationException()),parameter);

    }
}