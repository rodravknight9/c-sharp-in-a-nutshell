using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_in_a_nutshell._04_Advanced
{
    internal class Events
    {
        //-- questions
        // when do the compilers knows who needs to call.

        //-- TODOs
        // () check how EventArgs works and use them in the Mosh example.
    }

    /// <summary>
    /// Class used for the Event example
    /// </summary>
    public class Broadcaster
    {
        public event PriceChangedHandler PriceChanged;

        //-- the code below is an expicit implementation of the 
        //-- remove and add actions, typically C# will do this automatically
        //-- they can look like the following: add_PriceChanged and remove_PriceChanged

        //private EventHandler priceChanged;

        //public event EventHandler PriceChanged
        //{
        //    add { priceChanged += value; }
        //    remove { priceChanged -= value; }
        //}
    }

    /// <summary>
    /// Stock events, simulates the changes of prices
    /// This is used for 
    /// </summary>
    public class Stock
    {
        string _symbol;
        decimal _price;

        public Stock(string symbol)
        {
            _symbol = symbol;
        }

        /// <summary>
        /// it fires the PriceChanged event every time the Price of the Stock changes.
        /// </summary>
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price == value) return;
                decimal oldPrice = _price;
                _price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, _price)); // call the events if there is any
            }
        }

        /// <summary>
        /// EventHandler give us the event responsible to raise the events.
        /// We can use this type of method to avoid declaring a custom delegate
        /// </summary>
        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        /// <summary>
        /// This method is responsible to call the events if there is any.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            if (PriceChanged != null)
            {
                PriceChanged(this, e);
            }
        }

    }

    public class PriceChangedEventArgs : EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;

        public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }
    }

    public class AlertService
    {
        /// <summary>
        /// Method that applies the contract
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
                Console.WriteLine("Alert, 10% stock price increase!");
        }
    }

    /// <summary>
    /// Interface that has an event declaration
    /// </summary>
    public interface IFoo
    {
        event EventHandler ev;
    }

    public class Foo : IFoo
    {
        public event EventHandler ev;

        /// <summary>
        /// Explicitly add the "add" and "remove"
        /// </summary>
        event EventHandler IFoo.ev
        {
            add { ev += value;  }
            remove { ev -= value; }
        }

        //-- events can be virtual, overridden, abstract or sealed.
        public static event EventHandler<EventArgs> StaticEvent;
        public virtual event EventHandler<EventArgs> VirtualEvent;

    }

    //================================================================================
    //-- The following example is given by Programming with Mosh
    //-- https://youtu.be/jQgwEsJISy0

    /// <summary>
    /// This class is responsible to encode a video
    /// </summary>
    public class VideoEncoder
    {
        /// <summary>
        /// Delegates that is used as a contract
        /// </summary>
        /// <param name="source">The source the event has been called</param>
        /// <param name="e"></param>
        public delegate void VideoEncodedEventHandler(object source, EventArgs e);

        /// <summary>
        /// Event based on the delegate <b>VideoEncodedEventHandler</b> that raise the events
        /// </summary>
        public event VideoEncodedEventHandler VideoEncoded;

        /// <summary>
        /// Encodes the video.
        /// </summary>
        /// <param name="video"></param>
        public void Encode(Video video)
        {
            Console.WriteLine($"Encoding the video: {video.Title}");
            Thread.Sleep(2000);

            OnVideoEncoded(); // call the events if there is any.
        }

        /// <summary>
        /// Method resposible to raise the events
        /// </summary>
        protected virtual void OnVideoEncoded()
        {
            if (VideoEncoded != null)
            { 
                VideoEncoded(this, EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// Video class that contains a simple Title
    /// </summary>
    public class Video
    {
        public string Title { get; set; } = null!;
    }

    /// <summary>
    /// class responsible to send emails
    /// </summary>
    public class MailService
    {
        /// <summary>
        /// Subscriber method that accomplish the contract delegate with
        /// <b>VideoEncodedEventHandler</b>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnVideoEncoded(object source, EventArgs e)
        {
            Console.WriteLine("Mail Service: Sending an email...");
        }
        
    }

    public class SMSService
    {
        /// <summary>
        /// Subscriber method that accomplish the contract delegate with
        /// <b>VideoEncodedEventHandler</b>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnVideoEncoded(object source, EventArgs e)
        {
            Console.WriteLine("Text Service: Sending an email...");
        }
    }


}
