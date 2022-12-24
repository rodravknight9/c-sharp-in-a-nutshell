using csharp_in_a_nutshell._04_Advanced;



Action[] actions = new Action[3];
Action[] actions2 = new Action[3];

//-- each closure captures the same variable
//-- when the delegates are invoked, each delegate sees the i's value
//-- at the time of invocation (3)
for (int i = 0; i < 3; i++)
{
    actions[i] = () => Console.WriteLine(i);
}

foreach (Action action in actions)
{
    action();
}

//-- the solution to this is by using a scoped variable
for (int i = 0; i < 3; i++)
{
    int scopedI = i;
    actions2[i] = () => Console.WriteLine(scopedI);
}

foreach (Action action1 in actions2)
{
    action1();
}