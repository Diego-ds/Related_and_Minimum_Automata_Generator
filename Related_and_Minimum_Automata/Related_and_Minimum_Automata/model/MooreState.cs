using System;
using System.Collections.Generic;

public class MooreState
{
	private string identifier;
	private string output;
	List<MooreState> transitions;

	public MooreState(string identifier, string output)
	{
		this.identifier = identifier;
		this.output = output;
		transitions = new List<MooreState>();
	}
}
