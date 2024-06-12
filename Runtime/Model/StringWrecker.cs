using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


public class StringWrecker
{
    private string _text;

    public string Plain => _text;
    public StringWrecker(string value)
    {
        _text = value;
    }

    private StringElement[] Wreck()
    {
        
    }
}

