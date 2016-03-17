using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Practice
{
	//finite state machine
	//Helps to determine how it'll be used ahead of time
	//Might only need to be made once, then just reused
	class FiniteStateMachine
	{
		public class Transition
		{
			public Enum Present;
			public Enum Desired;
			public Transition(Enum first, Enum second)
			{
				Present = first;
				Desired = second;
			}
		}

		Enum _currentState;
		Dictionary<Enum, List<Transition>> _TransitionTable;
		private List<Enum> _States;

		/// <summary>
		/// Constructs the FSM 
		/// </summary>
		/// <param name="initial"></param>
		public FiniteStateMachine(Enum initial)
		{
			_States = new List<Enum>();
			_TransitionTable = new Dictionary<Enum, List<Transition>>();
			_currentState = initial;
		}

		/// <summary>
		/// Checks that the _States list doesn't contain a specified Enum.
		/// If it doesn't, it then the Enum is added to it.
		/// From there the Enums are also added to the dictionary _TransitionTable with a new List.
		/// If the _States list already contains the specified Enum it then outputs a notification and does not add the Enum again.
		/// </summary>
		/// <param name="state"></param>
		public void AddState(Enum state)
		{
			if (!_States.Contains(state))
			{
				_States.Add(state);
				_TransitionTable.Add(state, new List<Transition>());
			}
			else
			{
				Console.WriteLine("Can't do that.");
			}

		}

		/// <summary>
		/// Simply outputs the a list of states specified by the program.
		/// </summary>
		public void info()
		{
			Console.WriteLine("Finite State Machine is comprised of...");
			foreach (Enum s in _States)
			{
				Console.WriteLine("State " + s.GetHashCode() + ": " + s.ToString());
			}

			Console.WriteLine("The current state is: " + _currentState.ToString() + "\n");
		}
		
		/// <summary>
		/// Adds transitions to the Dictionary.
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		public void AddTransition(Enum from, Enum to)
		{
			if (_TransitionTable.ContainsKey(from))
			{
				_TransitionTable[from].Add(new Transition(from, to));
			}
		}

		/// <summary>
		/// Allows for transitions between states based on deffinitions in the Dictionary.
		/// Checks if the transition is valid.
		/// Outputs an error message if the transition is invalid.
		/// </summary>
		/// <param name="change"></param>
		public void ChangeState(Enum change)
		{
			Console.WriteLine("Change from " + _currentState.ToString() + " to " + change);

			if (change.GetHashCode() > _currentState.GetHashCode() ||
				change.GetHashCode() < _currentState.GetHashCode() && !change.GetHashCode().Equals(0))
			{
				foreach (Transition t in _TransitionTable[_currentState])
				{
					if (t.Desired.Equals(change))
					{
						_currentState = change;
						Console.WriteLine("Current State: " + _currentState + "\n");
					}
					else if (t.Present.Equals(_currentState))
					{
						Console.WriteLine("That transition is invalid! \nCurrent State: " + _currentState + "\n");
					}
				}
			}
			else if (change.GetHashCode().Equals(0) && !_currentState.GetHashCode().Equals(0) ||
					change.GetHashCode().Equals(_currentState.GetHashCode()))
			{
				Console.WriteLine("That transition is invalid! \nCurrent State: " + _currentState + "\n");
			}

		}
	}
}