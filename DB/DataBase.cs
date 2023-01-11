using InferenceRuler.Abstractions;
using InferenceRuler.Utilities;

namespace InferenceRuler.DB;

public abstract class DataBase <T> where T : IData
{
    private readonly List<T> _datas;
    protected List<T> Datas => _datas;

    // CONSTRUCTOR
    protected DataBase()
    {
        _datas = new List<T>();
    }
    protected void Clear()
    {
        _datas.Clear();
    }
    protected void AddData(T newData)
    {
        Utils.CheckNull(newData, "The datas to append | Database.cs, line 22");
        _datas.Add(newData);
    }
    protected void AppendDatas(IEnumerable<T> newDatas)
    {
        Utils.CheckNull(newDatas, "The datas to append | Database.cs, line 27");
        _datas.AddRange(newDatas);
    }
    protected T SearchData(string dataName)
    {
        var data = _datas.FirstOrDefault(x => x.GetName() == dataName);
        return data;
    }
    protected abstract bool GetValueOfData(string dataName);
}
