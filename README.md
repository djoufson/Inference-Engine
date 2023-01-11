# **Inference Engine ⚙️**
This project is a C# clas Library made with .NET 6, that is for solving inferrence problems with an engine running the forward chaining algorithm.

This is the documentation provided to use this package

# **Installation**
Currently, to install the Package, you need to clone it locally in your device, run it and make a reference from the project you are working on, to the package you just downloaded

## **1.** **Clone the project**

In the desired location, open a terminal and type the command below 👇🏾 : 
``` git
git clone https://github.com/Djoufson/Inference-Engine
```

## **2.** **Build the project**

Once the project finishes to load, in the same terminal type the following commands
``` shell
> cd Inference-Engine
> dotnet build
```

- Open this path in your File Explorer
- Enter inside the **bin/Debug/net6.0/** folder an copy the full path to this location

## **3.** **Add the project Reference**
- Open your current project in Visual Studio
- In the solution Explorer, right click on the project and select Add Project Reference
- On the left edge of the displayed window, go to Browse and browse to the path you copied earlier
- Select OK and you are good to go !!

# **Package presentation**
Here are the main classes of this package explained with encapsulated methods

## **`Fact`**

A fact is an entity described by two properties, that implements the `IFact` interface

| Property    | Description |
| -------- | ------- |
| string **Name** { get; }  | The name of the fact    |
| bool **Value** { get; } |  The boolean value of the fact     |

To make a new Fact, there is a factory class provided with serveral manners of making new facts

## **`FactFactory`**

With this class, there are two static methods availables to make new facts

| Method Signature | Description |
| --------------- | --------------- | 
| Fact MakeFact(string name, bool value); | Takes the **name** and the **value** as parameters. Note that the name should not contain any of the special characters listed here =~`!@#$%^&\*()-+={}[]|/:;\"'<>,.? |
| Fact MakeFact(string factFormat); | Takes only one string parameter, that represents a formatted string matching some required pattern. |

## Example
*Note: The following examples emulate a cards game*

Here are some examples of how to use the FacfFactory class

``` cSharp
using static InferenceRuler.Factories.FactFactory;

var myFirstFact = MakeFact("IsRed", true); // Explicit arguments
var mySecondFact = MakeFact("IsJoker=false"); // Formated string

// For more safety, you should wrap the MakeFact that uses the formated string into a try - catch statement
```

Then you can use those facts.

## **`Rule`**
A **rule** is basically an expression like ***If (some conditionnal facts) Then (A new fact)***

The list of facts to satisfy is called **Premises**, while the inferred fact is the **Conclusion**

To illustrate this expression, a Rule object is provided the following properties

| Property | Description |
| -------- | ------- |
| string Name { get; set; } | The name of the rule |
| List\<IFact\> Premises { get; set;} | The list that contains all the facts to satisfy in order to deduce a new fact from this rule |
| IFact Conclusion { get; set; } | The conclusion to assert if every of the premises are satisfied |

## **`RuleFactory`**
To create new Rules, this static class is provided to the users of the package.
With this class, there are actually two ways of creating a rule, all of them through easy API.

| Method SSignature | Description |
| -------- | ------- |
| Rule MakeRule(Rule rule, string ruleName = "") | This method takes two arguments, a **rule** to copy, and an optional **ruleName** to override the provided one. It returns a copy of the provided rule in a new variable |
| `Rule` MakeRule(string ruleName, `IFact` conclusion, `params` `IFact`[] premises) | That method takes basically three arguments or more. The two firstones are respectively the **ruleName** we want to apply to the rule, and the **conclusion** we want to deduce if premises are satisfied. Also, the remaining **params** are an array of `IFacts` that will represents the premisses of the rules. They can be passed to the method each separated by commas.|

## Example
We will continue the code written for the previous example
``` cSharp
using static InferenceRuler.Factories.FactFactory;
using static InferenceRuler.Factories.RuleFactory;

var myFirstFact = MakeFact("IsRed", true); // Explicit arguments
var mySecondFact = MakeFact("IsJoker=true"); // Formated string

var conclusion = MakeFact("IsRedJoker", true);
// For more safety, you should wrap the MakeFact that uses the formated string into a try - catch statement

// We now create a rule using the second method provided by the API
var myRule = MakeRule("Rule1", conclusion, myFirstFact, mySecondFact);
// So IF (IsRed AND IsJoker) THEN IsRedJoker
```

## **`FactsBase`** & **`RulesBase`**
In order to store the known Facts and Rules, we provide some repositories classes to encapsulate operations like Adding a new Fact, removing one, Adding a range an so on. Those two classes inherit from a base generic **DataBase** with the following capabilities

The concrete implementations get several constructors to ensure that the usage is easy

| Method | Description |
| ------ | ------ |
| void Clear() | That remove all known statement. |
| void AddData(T newData) | `T` represents here either a Rule or a Fact. This method adds the new instance to the appropriate repository |
| void AddRangeDatas(IEnumerable\<T\> newDatas) | Same to thr previous one, `T` represents a Rule or a Fact. This method adds a range of items of the same type in the appropriate repository |
| T SearchData(string dataName) | This method retrieves an instance of data with the provided name in the appropriat repository |

## **`Engine`**
Finally, the core part of this package, is the Engine class that Enables to solve a certain collection of rules, given a collection of facts. 

*note: This class is to be instantiated, and does not contain any static member*

Here is the methods related to this class

**The Constructor**
``` cSharp
public Engine(FactsBase factsBase, RulesBase rulesBase)
{ 
  //... Instantiates an Engine with a provided FactsBase and RulesBase
}
```

| Method | Description |
|---- | ---- |
| IEnumerable<IFact> Solve(); | Solves the problem by inferring every new fact possible, and returns the list of facts |
| List<Fact> GetFacts(); | Gets the existing facts |
| string PrintFacts(); | Prints the current facts to the console |

## Example

``` cSharp
using static InferenceRuler.Factories.FactFactory;
using static InferenceRuler.Factories.RuleFactory;

var myFirstFact = MakeFact("IsRed", true); // Explicit arguments
var mySecondFact = MakeFact("IsJoker=true"); // Formated string

var conclusion = MakeFact("IsRedJoker", true);
// For more safety, you should wrap the MakeFact that uses the formated string into a try - catch statement

// We now create a rule using the second method provided by the API
var myRule = MakeRule("Rule1", conclusion, myFirstFact, mySecondFact);

// The fact base is initialized with just two facts
var factBase = new FactsBase(new[] {myFirstFact, mySecondFact});

var ruleBase = new RulesBase();

// We add the rule defined higher in the code
ruleBase.AddRule(myRule);

// We create the engine with the factBase and ruleBase (That contains only one rules)
var engine = new Engine(factBase, ruleBase);

// We print the existing facts before solving
Console.WriteLine("======== BEFORE ========");
Console.WriteLine(engine.PrintFacts());

engine.Solve();

// After solving the problem, we print the Facts. Logically, we can deduce the new fact according to the only rule we have, because all of its premises are true.

Console.WriteLine("======== AFTER ========");
Console.WriteLine(engine.PrintFacts());
```

*Output :*
```
======== BEFORE ========
IsRed | True
IsJoker | True

======== AFTER ========
IsRed | True
IsJoker | True
IsRedJoker | True
```