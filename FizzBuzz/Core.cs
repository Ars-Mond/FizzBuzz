namespace FizzBuzz;

public class Core
{
    public string[] Data => _data;


    private string[] _data;
    private int _count;
    private readonly string _fizz = "Fizz";
    private readonly string _buzz = "Buzz";
    
    
    public Core(int count)
    {
        _count = count;
        _data = new string[count];
    }


    public string[] Generate()
    {
        for (int i = 0; i < _count; i++)
        {
            _data[i] = i.ToString();
            if(i%3 == 0) _data[i] = _fizz;
            else if(i%5 == 0) _data[i] = _buzz;
        }

        return _data;
    }

    public override string ToString()
    {
        return String.Join('\n', _data);
    }

    public string ToStringFast()
    {
        string a = "";
        for (int i = 0; i < _count; i++)
        {
            a += _data[i] + '\n';
        }
        return a;
    }
    
    public void ToStringSlow()
    {
        for (int i = 0; i < _count; i++)
        {
            Console.WriteLine(_data[i]);
        }
    }
    
    
    

}