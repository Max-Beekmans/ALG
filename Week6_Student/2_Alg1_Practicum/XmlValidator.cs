using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Exceptions;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class XmlValidator
    {
        private Stack xmlStack;

        public XmlValidator()
        {
            xmlStack = new Stack();
        }

        public bool Validate(string xml)
        {
            char[] xmlArray = xml.ToCharArray();
            Boolean record = false;
            String result = "";
            for (int i = 0; i < xmlArray.Length; i++)
            {
                if (record && !xmlArray[i].Equals('<') && !xmlArray[i].Equals('>'))
                {
                    result = result + xmlArray[i].ToString();
                }
                if (xmlArray[i].Equals('<') && !xmlArray[i + 1].Equals('/'))
                {
                    record = true;
                }
                else if (xmlArray[i].Equals('>'))
                {
                    xmlStack.Push(result);
                    result = "";
                }

                if (xmlArray[i].Equals('<') && xmlArray[i + 1].Equals('/'))
                {
                    int count = i;
                    String compare = "";
                    while (!xmlArray[count].Equals('>'))
                    {
                        if(!xmlArray[count].Equals('<') && !xmlArray[count].Equals('>') && !xmlArray[count].Equals('/'))
                        compare += xmlArray[count];
                        count++;
                    }
                    if (xmlStack.Peek().Equals(compare))
                    {
                        xmlStack.Pop();
                        i = count;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (xmlStack.IsEmpty())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


