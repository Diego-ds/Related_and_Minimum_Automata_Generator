using System;
using System.Collections.Generic;
using System.model.MooreState;

public class MooreAutomata : IAutomata
{
	private List<MooreState> states;
	private List<string> inputs;
	private List<string> outputs;
	private MooreState initial;

	public MooreAutomata(List<State> states, List<string> inputs, List<string> outputs, MooreState initial)
	{
		this.states = new List<State>();
		this.inputs = new List<string>();
		this.outputs = new List<string>();
		this.initial = initial;
	}

	public override List<string> GetConnectedStates()
    {

    }

	public override List<string> GetDisconnectedStates()
	{

	}

	public override void RemoveDisconnectedStates()
	{

	}
}
