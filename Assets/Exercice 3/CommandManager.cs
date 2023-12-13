using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    Stack<Command> executedCommands = new Stack<Command>();
    Stack<Command> undoneCommands = new Stack<Command>();

    public void ExecuteCommand(Command command)
    {
        command.Execute();

        if(command.IsSuccessful)
        {
            executedCommands.Push(command);
            undoneCommands.Clear();
            command.IsSuccessful= false;
        }


    }

    public void UndoLastCommand()
    {
        if(executedCommands.Count > 0)
        {
            Command command = executedCommands.Pop();
            command.Undo();
            undoneCommands.Push(command);
        }
    }

    public void RedoLastCommand()
    {
        if(undoneCommands.Count > 0)
        {
            Command command = undoneCommands.Pop();
            command.Execute();
            if (command.IsSuccessful)
            {
                executedCommands.Push(command);
            }
        }
    }
}
