
using System;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEditor.PackageManager.Requests;

public class StringElement
{
    private string _startTag;
    private string _content;
    private string _endTag;
    public string Text { get; set; }
    private List<object> _elements;


    public StringElement(string text, int hitIndex, out int proceedIndex)
    {
        while (hitIndex != -1)
        {
            int oldHitIndex = hitIndex;

            hitIndex = text.IndexOf("<", hitIndex);

            if (text.Substring(hitIndex + 1, 1) != "/" && oldHitIndex != hitIndex)
            {
                _elements.Add(Text.Substring(oldHitIndex, hitIndex - oldHitIndex));
                _elements.Add(new StringElement(text, hitIndex, out hitIndex));
            }
            else if (text.Substring(hitIndex + 1, 1) != "/" && oldHitIndex == hitIndex)
            {
                int startTagEnd = text.IndexOf(">");
                _startTag = text.Substring(hitIndex, startTagEnd);
                hitIndex = startTagEnd + 1;
            }
            else if (text.Substring(hitIndex + 1, 1) == "/")
            {
                _elements.Add(text.Substring(oldHitIndex, hitIndex));
                int endTagEnd = text.IndexOf(">", hitIndex);
                _endTag = text.Substring(hitIndex, endTagEnd - oldHitIndex);
                break;
            }
        }

        proceedIndex = hitIndex;
    }
}

