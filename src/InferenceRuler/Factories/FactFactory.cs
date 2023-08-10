using InferenceRuler.Models;
using InferenceRuler.Utilities;
using System.Linq;
using System.Reflection.Metadata;

namespace InferenceRuler.Factories;

public class FactFactory
{
    ///// <summary>
    ///// Creates a Fact based on the explicit passed arguments
    ///// </summary>
    ///// <param name="name">Represents the name of the fact we want to create. It should not contain any special character</param>
    ///// <param name="value">Represents the boolean value of the actual fact</param>
    ///// <returns>The created fact</returns>
    ///// <exception cref="ArgumentException"></exception>
    //public static Fact MakeFact(string name, bool value)
    //{
    //    return (name.ContainsAny(Constants.SPECIAL_CHARACTERS.ToCharArray())) ? 
    //        throw new ArgumentException("A Fact name should not contain any special character like \n" + String.Join(' ', Constants.SPECIAL_CHARACTERS.ToCharArray())) : 
    //        new Fact(
    //            name,
    //            value);
    //}

    ///// <summary>
    ///// Creates a Fact based on a string correspondind to the pattern :
    ///// factname=value. value can be either true or false, and factname should not contain any special caracter
    ///// </summary>
    ///// <param name="factFormat"></param>
    ///// <returns></returns>
    ///// <exception cref="ArgumentException"></exception>
    //public static Fact MakeFact(string factFormat)
    //{
    //    var text = factFormat.Trim();
    //    var datas = text.Split('=');
    //    if (datas.Length < 2)
    //        throw new ArgumentException("The format does not match the required pattern");
    //    if(bool.TryParse(datas[1], out var value) && !datas[0].Contains('='))
    //        return new Fact(datas[0], value);
    //    else
    //        throw new ArgumentException("The format does not match the required pattern");
    //}
}
