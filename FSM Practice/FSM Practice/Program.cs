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
			INIT,
			IDLE,
			WALK,
			RUN
		}
		static void Main(string[] args)
		{
			FiniteStateMachine fsm = new FiniteStateMachine(PlayerStates.INIT);
			//INIT -> IDLE
			//IDLE -> WALK
			//WALK -> RUN
			//RUN -> WALK
			//WALK -> IDLE
			fsm.AddState(PlayerStates.INIT);
			fsm.AddState(PlayerStates.IDLE);
			fsm.AddState(PlayerStates.WALK);
			fsm.AddState(PlayerStates.RUN);

			fsm.AddTransition(PlayerStates.INIT, PlayerStates.IDLE);
			fsm.AddTransition(PlayerStates.IDLE, PlayerStates.WALK);
			fsm.AddTransition(PlayerStates.WALK, PlayerStates.RUN);
			fsm.AddTransition(PlayerStates.RUN, PlayerStates.WALK);
			fsm.AddTransition(PlayerStates.WALK, PlayerStates.IDLE);
			//fsm.AddTransition()
			//need to know current state
			//Pass on the constructor
			//fsm.info();
			fsm.ChangeState(PlayerStates.IDLE);
			fsm.ChangeState(PlayerStates.INIT);
			fsm.ChangeState(PlayerStates.WALK);
			fsm.ChangeState(PlayerStates.RUN);
			
			fsm.ChangeState(PlayerStates.IDLE);
			fsm.ChangeState(PlayerStates.RUN);
			fsm.ChangeState(PlayerStates.WALK);
			Console.ReadLine();
		}
	}
}
