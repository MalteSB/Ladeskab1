using Ladeskab1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeSkabTest
{
   public class UnitTestDisplay
   {

       private Display _uut;

       [SetUp]
       public void Setup()
       {
           _uut = new Display();
       }

       [Test]
       public void TestSetLockerDisplay()
       {
           try
           {
               _uut.SetLockerState();
           }
           catch (Exception e)
           {
               Assert.That(e, Is.TypeOf(typeof(NotImplementedException)));
           }
       }

       [Test]
       public void TestNoPhoneDisplay()
       {
           try
           {
               _uut.NoPhoneConnected();
           }
           catch (Exception e)
           {
               Assert.That(e, Is.TypeOf(typeof(NotImplementedException)));
           }
       }



       [Test]
       public void ShowFullyCharged_PrintCorrectMessage()
       {
           StringWriter _stringwriter = new StringWriter();
           Console.SetOut(_stringwriter);
           _uut.ShowFullyCharged();

           Assert.That(_stringwriter.ToString(), Is.EqualTo("Telefonen er fuldt opladt" + Console.Out.NewLine)); //NewLine da der i metoden er brugt WriteLine.
       }


       [Test]
       public void ShowChargeOngoing_PrintCorrectMessage()
       {
           StringWriter _stringwriter = new StringWriter();
           Console.SetOut(_stringwriter);
           _uut.ShowChargeOngoing();

           Assert.That(_stringwriter.ToString(), Is.EqualTo("Opladning i gang" + Console.Out.NewLine)); 
       }

       [Test]
       public void ShowChargeError_PrintCorrectMessage()
       {
           StringWriter _stringwriter = new StringWriter();
           Console.SetOut(_stringwriter);
           _uut.ShowChargeError();

           Assert.That(_stringwriter.ToString(), Is.EqualTo("Opladning fejl ==>> Opladning stoppes" + Console.Out.NewLine)); 
       }




       










    }
}
