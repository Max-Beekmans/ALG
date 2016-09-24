using Alg1_Practicum;
using Alg1_Practicum_Test.TestExtensions;
using Alg1_Practicum_Utils.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test
{
    [TestClass]
    [MSTestExtensionsTest]
    public class XmlValidatorTest : ContextBoundObject
    {
        private XmlValidator validator { get; set; }
        
        #region Setup and Teardown
        [TestInitialize]
        public void Stack_Initialize()
        {
            validator = new XmlValidator();
        }
        #endregion
    }
}
