using System;
using System.Collections.Generic;

public interface IAutomata
{
    List<string> GetConnectedStates();

    List<string> GetDisconnectedStates();

    void RemoveDisconnectedStates();
}
