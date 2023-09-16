namespace Problems;

public interface IEulerProblem<out TUnit>
{
    public TUnit Example();

    public TUnit Solution();
}