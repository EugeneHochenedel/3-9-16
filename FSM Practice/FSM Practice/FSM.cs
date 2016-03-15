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
		/// 
		/// </summary>
		/// <param name="initial"></param>
		public FiniteStateMachine(Enum initial)
		{
			_States = new List<Enum>();
			_TransitionTable = new Dictionary<Enum, List<Transition>>();
			_currentState = initial;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="state"></param>
		/// <returns></returns>
		public bool AddState(Enum state)
		{
			if (!_States.Contains(state))
			{
				_States.Add(state);
				_TransitionTable.Add(state, new List<Transition>());
				return true;
			}
			else
			{
				Console.WriteLine("Can't do that.");
				return false;
			}

		}

		/// <summary>
		/// 
		/// </summary>
		public void info()
		{
			Console.WriteLine("Finite State Machine is comprised of...");
			foreach (Enum s in _States)
			{
				Console.WriteLine("State " + s.GetHashCode() + ": " + s.ToString());
			}

			Console.WriteLine("The current state is: " + _currentState.ToString());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="transition">Must match the state->state format</param>
		/// <returns>False if this is not a valid transition</returns>
		public void AddTransition(Enum from, Enum to)
		{
			if (_TransitionTable.ContainsKey(from))
			{
				_TransitionTable[from].Add(new Transition(from, to));
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="change"></param>
		public void ChangeState(Enum change)
		{
			Console.WriteLine("Change from " + _currentState.ToString() + " to " + change);

			if (change.GetHashCode() > _currentState.GetHashCode() || change.GetHashCode() < _currentState.GetHashCode() && change.GetHashCode() != 0)
			{
				foreach (Transition t in _TransitionTable[_currentState])
				{
					if (t.Desired.Equals(change))
					{
						Console.WriteLine("Transitioning from: " + _currentState);
						_currentState = change;
						Console.WriteLine("To: " + _currentState);
						Console.WriteLine("Current State: " + _currentState + "\n");
					}
				}
			}
			else if(change.GetHashCode() == 0 && _currentState.GetHashCode() > 0 || 
					change.GetHashCode() == _currentState.GetHashCode())
			{
				Console.WriteLine("That transition is invalid! \nCurrent State:" + _currentState + "\n");	
			}
		}
	}
}