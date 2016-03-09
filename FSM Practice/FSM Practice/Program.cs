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
		class Transition
		{
			public Transition(Enum from, Enum to)
			{
				
			}
		}
		Enum _currentState;
		public FiniteStateMachine(Enum initial)
		{
			_States = new List<Enum>();
			_ValidTrans = new List<Enum>();
			_currentState = initial;
		}

		private List<Enum> _States;

		private List<Enum> _ValidTrans;

		public bool AddState(Enum state)
		{
			//if (_States.Contains(state))
			//{
			//	Console.WriteLine("Can't do that.");
			//	return false;
			//}
			if (!_States.Contains(state))
			{
				_States.Add(state);
				return true;
			}
			else
			{
				Console.WriteLine("Can't do that.");
				return false;
			}
			
		}

		public void info()
		{
			Console.WriteLine("Finite State Machine is comprised of...");
			int iCount = 0;
			foreach (Enum s in _States)
			{
				Console.WriteLine("State " + iCount.ToString() + ": " + s.ToString());
				iCount++;
			}

			Console.WriteLine("Current State is: " + _currentState.ToString());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="transition">Must match the state->state format</param>
		/// <returns>False if this is not a valid transition</returns>
		public bool AddTransition(Enum from, Enum to)
		{
			Transition t = new Transition(from, to);
			if(TransitionTable[from].Contains(t))
			{

			}
			return true;
		}

		Dictionary<Enum, List<Transition>> TransitionTable;


	}

	class Program
	{
		enum PlayerStates
		{
			init,
			idle,
			walk,
			run,
		}
		static void Main(string[] args)
		{
			FiniteStateMachine fsm = new FiniteStateMachine(PlayerStates.init);
			//init -> idle
			//idle -> walk
			//walk -> run
			//run -> walk
			//walk -> idle
			fsm.AddState(PlayerStates.init);
			fsm.AddState(PlayerStates.idle);
			fsm.AddState(PlayerStates.walk);
			fsm.AddState(PlayerStates.run);
			fsm.AddState(PlayerStates.init);
			//fsm.AddTransition()
			//need to know current state
			//Pass on the constructor

			fsm.info();

			Console.ReadLine();
		}
	}
}
