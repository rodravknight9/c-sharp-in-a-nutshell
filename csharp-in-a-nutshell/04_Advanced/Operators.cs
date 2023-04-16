using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_in_a_nutshell._04_Advanced
{
    public class Operators
    {
    }

    public class OperatorsPlayground
    {
        public static void Play()
        {
            // using the Operator '+'
            Note B = new Note(2);
            Note CSharp = B + 2;

            // Using the conversion overload (explicit, implicit)
            Note n = (Note)554.37; // explicit conversion
            double x = n; // implicit conversion

            Note A = new Note(0);
            OtherNote Alit = new OtherNote("0");
            OtherNote diffB = new OtherNote("1");


            // need to perform the same order as we defined.
            // other way we should apply the operators in both classes.
            if(Alit == A)
            {
                Console.WriteLine("The notes have the same Note");
            }

            if (diffB != A)
            {
                Console.WriteLine("This time they are different");
            }
        }


    }

    public struct Note
    {
        //-- We need to follow these rule to properly apply Operators
        // should be static and public
        // one of the operands must be the type in which the operator is declared

        int value;
        public int MyNote {  get { return value; } }
        public Note(int semitonesFromA)
        { 
            value = semitonesFromA;
        }
        public static Note operator +(Note x, int semitones)
        {
            return new Note(x.value + semitones);
        }

        /// <summary>
        /// Implicit Conversion to Hertz (double)
        /// </summary>
        /// <param name="x"></param>
        public static implicit operator double(Note x)
             => 440 * Math.Pow(2, (double)x.value / 12);

        /// <summary>
        /// Explicit Conversion to Note
        /// </summary>
        /// <param name="x"></param>
        public static explicit operator Note(double x)
            => new Note((int)(0.5 + 12 * (Math.Log(x / 440) / Math.Log(2))));
    }

    public struct OtherNote
    {
        string note;

        public string Note { get { return note; } }
        public OtherNote(string note)
        {
            this.note = note;
        }

        /// <summary>
        /// Overload for Operator ==.
        /// First goes the OtherNote and then Note
        /// The order matters
        /// </summary>
        /// <param name="x"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public static bool operator ==(OtherNote x, Note note)
        {
            return x.Note.Equals(note.MyNote.ToString());
        }

        /// <summary>
        /// Overload for Operator !=.
        /// First goes the OtherNote and then Note
        /// The order matters
        /// </summary>
        /// <param name="x"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public static bool operator !=(OtherNote x, Note note)
        {
            return !x.Note.Equals(note.MyNote.ToString());
        }

 
        //-- After overloading == and != the complier asks for overloading
        //-- Equals and GetHashCode
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
