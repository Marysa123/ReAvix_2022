using ClassLibraryReAvix;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestClassLibraryReAvix
{
    [TestClass]
    public class TestMethodsReAvix
    {
        [TestMethod]
        public void TestValidity_of_the_Name()
        {
            Students students = new Students();
            string Name = "fdfdfdfdfdfdfdfdfdfdfdfdfdfdfdfdfddfdfdfdfdfdfdfdfdf";
            string m_Name = "fdfdfdfdfdfdfdfdfdfdfdfdfdfdfdfdfddfdfdfdfdfdfdfdfdf";
            string l_Name = "fdfdfdfdfdfdfdfdfdfdfdfdfdfdfdfdfddfdfdfdfdfdfdfdfdf";

            students.Validity_of_the_Name(Name,m_Name,l_Name);
        }
    }
}
