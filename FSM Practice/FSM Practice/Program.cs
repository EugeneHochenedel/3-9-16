using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Practice
{
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
			//fsm.AddState(PlayerStates.init);
			fsm.AddTransition(PlayerStates.init, PlayerStates.idle);
			fsm.AddTransition(PlayerStates.idle, PlayerStates.walk);
			fsm.AddTransition(PlayerStates.walk, PlayerStates.run);
			fsm.AddTransition(PlayerStates.run, PlayerStates.walk);
			fsm.AddTransition(PlayerStates.walk, PlayerStates.idle);
			//fsm.AddTransition(PlayerStates.init, PlayerStates.idle);
			//fsm.AddTransition()
			//need to know current state
			//Pass on the constructor
			//fsm.info();
			fsm.ChangeState(PlayerStates.idle);
			fsm.ChangeState(PlayerStates.init);

			//fsm.info();

			fsm.ChangeState(PlayerStates.walk);
			//fsm.info();
			fsm.ChangeState(PlayerStates.idle);
			fsm.ChangeState(PlayerStates.run);
			
			Console.ReadLine();
		}
	}
}
