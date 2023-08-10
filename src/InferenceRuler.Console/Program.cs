using InferenceRuler;
using Rules_UI.Facts;
using Rules_UI.Rules;

var hasFeaver = new HasFeverFact();
var hasHeadaches = new HasHeadacheFact();

var malariaRule = new MalariaRule();

var engine = new EngineBuilder()
    .AddRule(malariaRule)
    .AddFact(hasFeaver)
    .AddFact(hasHeadaches)
    .Build();

Console.WriteLine("======== BEFORE ========");
Console.WriteLine(engine.PrintFacts());

engine.Solve();

Console.WriteLine("======== AFTER ========");
Console.WriteLine(engine.PrintFacts());
