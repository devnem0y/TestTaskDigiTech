using System;

public interface IMultimeter
{
    event Action<Mode, string> ValueChanged;
}