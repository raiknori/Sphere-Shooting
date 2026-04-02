using System;

public interface IFinishChecker
{
    event Action OnFinishReached;
}
