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
       public void PhoneConnectionError_PrintCorrectMessage()
       {
           StringWriter _stringwriter = new StringWriter();
           Console.SetOut(_stringwriter);
           _uut.PhoneConnectionError();

           Assert.That(_stringwriter.ToString(), Is.EqualTo("Telefon er ikke ordentlig tilsluttet" + Console.Out.NewLine)); //NewLine da der i metoden er brugt WriteLine.
       }


       [Test]
       public void ShowLockerLocked_PrintCorrectMessage()
       {
           StringWriter _stringwriter = new StringWriter();
           Console.SetOut(_stringwriter);
           _uut.ShowLockerLocked();

           Assert.That(_stringwriter.ToString(), Is.EqualTo("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op." + Console.Out.NewLine)); //NewLine da der i metoden er brugt WriteLine.
       }


       [Test]
        public void ShowNotConnected_PrintCorrectMessage()
       {
           StringWriter _stringwriter = new StringWriter();
           Console.SetOut(_stringwriter);
           _uut.ShowNotConnected();

           Assert.That(_stringwriter.ToString(), Is.EqualTo("Din telefon er ikke ordentlig tilsluttet. Prøv igen." + Console.Out.NewLine)); //NewLine da der i metoden er brugt WriteLine.
       }


        [Test]
        public void ShowWrongRFID_PrintCorrectMessage()
       {
           StringWriter _stringwriter = new StringWriter();
           Console.SetOut(_stringwriter);
           _uut.ShowWrongRFID();

           Assert.That(_stringwriter.ToString(), Is.EqualTo("Forkert RFID tag" + Console.Out.NewLine)); //NewLine da der i metoden er brugt WriteLine.
       }


        [Test]
        public void ShowTakePhone_PrintCorrectMessage()
        {
            StringWriter _stringwriter = new StringWriter();
            Console.SetOut(_stringwriter);
            _uut.ShowTakePhone();

            Assert.That(_stringwriter.ToString(), Is.EqualTo("Tag din telefon ud af skabet og luk døren" + Console.Out.NewLine)); //NewLine da der i metoden er brugt WriteLine.
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
