using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace csharp_in_a_nutshell._04_Advanced
{
    internal class Attributes
    {
    }

    public class AttributesPlayground
    {
        public static void Play() 
        {
            
        }
    }

    /// <summary>
    /// Example of a class can have many attributes
    /// </summary>
    [Serializable, Obsolete, CLSCompliant(false)]
    public class Bar
    { 
    }

    public class AttrTest
    {
        public static void Foo(
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0
            )
        {
            Console.WriteLine(memberName);
            Console.WriteLine(filePath);
            Console.WriteLine(lineNumber);
        }
    }

    public interface INotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;
    }

    public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);

    public class PropertyChangedEventArgs : EventArgs
    {
        public virtual string PropertyName { get; }
        
        public PropertyChangedEventArgs(string propertyName)
        {
            PropertyName = propertyName;
        }
    }

    public class Boo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged =  delegate { };

        void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        string customerName;

        public string CustomerName
        { 
            get { return customerName; }
            set
            {
                if (value == customerName) return;
                customerName = value;
                RaisePropertyChanged();
            }
        }
    }


}
